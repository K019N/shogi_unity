using UnityEngine;


public class Cell : MonoBehaviour
{
    [SerializeField] private int x;
    [SerializeField] private int y;

    private IPiece currentPiece;

    public int getX => x;
    public int getY => y;
    public IPiece getCurrentPiece => currentPiece;

    public void Initialize(int x, int y){
        this.x = x;
        this.y = y;
    }

    public void PlacePiece(IPiece piece){
        currentPiece = piece;
    }

    public void ClearPiece(){
        currentPiece = null;
    }

    public bool IsOccupied(){
        return currentPiece != null;
    }
}