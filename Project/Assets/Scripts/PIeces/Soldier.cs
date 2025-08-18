using UnityEngine;

public class Soldier : IPiece
{
    public override bool IsLegalMove(int curX, int curZ, int tarX, int tarZ) {
        // Soldiers can move only forward
        return tarX == curX && tarZ == curZ + 1;
    }
}
