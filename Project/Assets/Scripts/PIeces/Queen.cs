using System;
using UnityEngine;

public class Queen : IPiece
{
    public override bool IsLegalMove(int curX, int curZ, int tarX, int tarZ){
        // Queen can move one space horizontally or vertically
        return (Math.Abs(curX - tarX) == 1 && curZ == tarZ) || (curX == tarX && Math.Abs(curZ - tarZ) == 1);
    }
}
