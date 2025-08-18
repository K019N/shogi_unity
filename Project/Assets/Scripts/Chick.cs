using UnityEngine;

public class Chick : IPiece
{
    public override bool IsLegalMove(int curX, int curZ, int tarX, int tarZ) {
        return tarX == curX && tarZ == curZ + 1;
    }
}
