using UnityEngine;


public abstract class IPiece : MonoBehaviour
{
    [SerializeField] private int boardX;
    [SerializeField] private int boardY;
    
    public int getBoardX => boardX;
    public int getBoardY => boardY;
    
    public void UpdatePosition(int newX, int newY){
        boardX = newX;
        boardY = newY;
    }
    
    public void move(){
        // TODO: mabye drag'n'drop moving
        // or click to figure, than to cell
    }
}
