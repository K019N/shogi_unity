using UnityEngine;

public class Board : MonoBehaviour
{
    [Header("Board Settings")]
    [SerializeField] private int width = 3;
    [SerializeField] private int height = 4;
    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private Transform boardParent;

    [Header("Cell Materials")]
    [SerializeField] private Material darkCellMaterial;
    [SerializeField] private Material lightCellMaterial;

    // x y
    private Cell[,] grid;

    public int Width => width;
    public int Height => height;
    public Cell[,] Grid => grid;

    private void Start() {
        InitializeBoard();
    }

    private void InitializeBoard(){
        grid = new Cell[width, height];
        
        for (int x = 0; x < width; x++){
            for (int y = 0; y < height; y++){
                CreateCell(x, y);
            }
        }
    }

    private void CreateCell(int x, int y){
        GameObject cellObj = Instantiate(cellPrefab, boardParent);
        cellObj.transform.position = new Vector3(x, 0, y);
        cellObj.name = $"Cell ({x},{y})";
        
        Cell cell = cellObj.GetComponent<Cell>();
        cell.Initialize(x, y);
        
        SetCellMaterial(cell, x, y);
        
        grid[x, y] = cell;
    }

    private void SetCellMaterial(Cell cell, int x, int y){
        Renderer renderer = cell.GetComponent<Renderer>();
        if (renderer == null) return;
        
        bool isDark = (x + y) % 2 == 0;
        renderer.material = isDark ? darkCellMaterial : lightCellMaterial;
    }

    public Cell GetCell(int x, int y){
        if (x >= 0 && x < width && y >= 0 && y < height){
            return grid[x, y];
        }
        Debug.LogError($"Invalid cell coordinates: ({x},{y})");
        return null;
    }

    public bool IsValidPosition(int x, int y){
        return x >= 0 && x < width && y >= 0 && y < height;
    }

    public void MovePiece(Cell from, Cell to){
        if (from.IsOccupied() && !to.IsOccupied()){
            IPiece piece = from.getCurrentPiece;
            to.PlacePiece(piece);
            from.ClearPiece();
            
            piece.UpdatePosition(to.getX, to.getY);
        }
    }
}