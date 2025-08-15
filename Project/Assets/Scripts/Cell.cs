using UnityEngine;


public class Cell : MonoBehaviour
{
    [SerializeField] private int x;
    [SerializeField] private int z;
    private Color originalColor;

    private IPiece currentPiece;

    public int getX => x;
    public int getZ => z;
    public IPiece getCurrentPiece => currentPiece;

    private void Start(){
        originalColor = GetComponent<MeshRenderer>().material.color;
    }

    public void Initialize(int x, int z)
    {
        this.x = x;
        this.z = z;
    }

    public void PlacePiece(IPiece piece)
    {
        currentPiece = piece;
    }

    public void ClearPiece()
    {
        currentPiece = null;
    }

    public bool IsOccupied()
    {
        return currentPiece != null;
    }
    
    public void Highlight(bool isHighlighted){
        if (isHighlighted){
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else{
            GetComponent<MeshRenderer>().material.color = originalColor;
        }
    }
}