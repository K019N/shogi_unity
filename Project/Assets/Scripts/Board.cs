using UnityEngine;
using System;

public class Board : MonoBehaviour
{
    [Header("Board Settings")]
    [SerializeField] private int width = 3;
    [SerializeField] private int height = 4;
    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private Transform boardParent;
    private Vector3 boardPosition;

    [Header("Cell Materials")]
    [SerializeField] private Material darkCellMaterial;
    [SerializeField] private Material lightCellMaterial;

    private Cell[,] grid;

    public int Width => width;
    public int Height => height;
    public Cell[,] Grid => grid;

    private void Start() {
        boardPosition = boardParent.GetComponent<Transform>().position;
        InitializeBoard();
    }

    private void InitializeBoard()
    {
        grid = new Cell[width, height];

        int startX = (int)Math.Round(boardPosition.x);
        int startZ = (int)Math.Round(boardPosition.z);
        for (int x = startX; x < startX + width; x++)
        {
            for (int z = startZ; z < startZ + height; z++)
            {
                CreateCell(x, z, startX, startZ);
            }
        }
    }

    private void CreateCell(int x, int z, int startX, int startZ){
        GameObject cellObj = Instantiate(cellPrefab, boardParent);
        cellObj.transform.position = new Vector3(x, 0, z);
        cellObj.name = $"Cell ({x},{z})";
        
        Cell cell = cellObj.GetComponent<Cell>();
        cell.Initialize(x, z);
        
        SetCellMaterial(cell, x, z);
        
        grid[x - startX, z - startZ] = cell;
    }

    private void SetCellMaterial(Cell cell, int x, int z){
        Renderer renderer = cell.GetComponent<Renderer>();
        if (renderer == null) return;
        
        bool isDark = (x + z) % 2 == 0;
        renderer.material = isDark ? darkCellMaterial : lightCellMaterial;
    }

    public Cell GetCell(int x, int z){
        if (x >= 0 && x < width && z >= 0 && z < height){
            return grid[x, z];
        }
        Debug.LogError($"Invalid cell coordinates: ({x},{z})");
        return null;
    }

    public bool IsValidPosition(int x, int z){
        return x >= 0 && x < width && z >= 0 && z < height;
    }

    public void MovePiece(Cell from, Cell to){
        if (from.IsOccupied() && !to.IsOccupied()){
            IPiece piece = from.getCurrentPiece;
            to.PlacePiece(piece);
            from.ClearPiece();
            
            piece.UpdatePosition(to.getX, to.getZ);
        }
    }
}