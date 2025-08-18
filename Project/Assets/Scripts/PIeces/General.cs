using System;
using UnityEngine;

public class General : IPiece
{
    public override bool IsLegalMove(int curX, int curZ, int tarX, int tarZ) {
        // Generals can move one space diagonally
        return Math.Abs(curX - tarX) == 1 && Math.Abs(curZ - tarZ) == 1;
    }
}
