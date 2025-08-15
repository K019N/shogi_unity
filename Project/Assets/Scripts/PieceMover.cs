using UnityEngine;

public class PieceMover : MonoBehaviour
{
    [SerializeField] private Board board;
    private IPiece selectedPiece;
    private Cell selectedCell;

    private void Update(){
        if (Input.GetMouseButtonDown(0)){
            HandleSelection();
        }
    }

    private void HandleSelection(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit)){
            Cell cell = hit.collider.GetComponent<Cell>();
            if (cell != null){
                ProcessCellClick(cell);
                return;
            }

            IPiece piece = hit.collider.GetComponent<IPiece>();
            if (piece != null){
                ProcessPieceClick(piece);
            }
        }
    }

    private void ProcessCellClick(Cell cell){
        if (selectedPiece != null){
            MoveSelectedPiece(cell);
            return;
        }

        if (selectedCell != null){
            DeselectCell();
        }

        if (cell.IsOccupied()){
            SelectCell(cell);
        }
    }

    private void ProcessPieceClick(IPiece piece){
        if (selectedPiece == piece){
            DeselectPiece();
            return;
        }

        if (selectedPiece != null){
            DeselectPiece();
        }

        SelectPiece(piece);
    }

    private void SelectPiece(IPiece piece){
        selectedPiece = piece;
        selectedPiece.SetSelected(true);
        Debug.Log($"Selected piece at ({piece.getBoardX}, {piece.getBoardZ})");
    }

    private void DeselectPiece(){
        if (selectedPiece is null) return;

        selectedPiece.SetSelected(false);
        selectedPiece = null;
    }

    private void SelectCell(Cell cell){
        selectedCell = cell;
        selectedCell.Highlight(true);
        Debug.Log($"Selected cell at ({cell.getX}, {cell.getZ})");
    }

    private void DeselectCell(){
        if (selectedPiece is null) return;

        selectedCell.Highlight(false);
        selectedCell = null;
    }

    private void MoveSelectedPiece(Cell targetCell){
        if (selectedPiece == null) return;

        Cell currentCell = board.GetCell(selectedPiece.getBoardX, selectedPiece.getBoardZ);
        board.MovePiece(currentCell, targetCell);
        selectedPiece.UpdatePosition(targetCell.getX, targetCell.getZ);

        selectedPiece.SetSelected(false);
        selectedPiece = null;
        
        Debug.Log($"Moved piece to ({targetCell.getX}, {targetCell.getZ})");
    }
}
