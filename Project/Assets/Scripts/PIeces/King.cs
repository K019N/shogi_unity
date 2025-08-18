using System;
using UnityEngine;

public class King : IPiece
{
    public override bool IsLegalMove(int curX, int curZ, int tarX, int tarZ) {
        // King can move only one cell in any direction
        return !(Math.Abs(curX - tarX) > 1 || Math.Abs(curZ - tarZ) > 1);
    }
}
