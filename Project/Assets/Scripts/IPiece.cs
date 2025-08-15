using UnityEngine;


public abstract class IPiece : MonoBehaviour
{
    [SerializeField] private int boardX;
    [SerializeField] private int boardZ;

    //FIXME
    private float selfY = 0.5f;
    [SerializeField] private GameObject selectionIndicator;

    public int getBoardX => boardX;
    public int getBoardZ => boardZ;

    private void Start(){
        selfY = gameObject.transform.position.y;
        Debug.Log($"selfY: {selfY}");
    }

    public void UpdatePosition(int newX, int newZ){
        boardX = newX;
        boardZ = newZ;
        transform.position = new Vector3(newX, selfY, newZ);
    }

    public void move(){
        // TODO: mabye drag'n'drop moving
        // or click to figure, than to cell
    }

    public void SetSelected(bool isSelected){
        selectionIndicator?.SetActive(isSelected);
    }
}
