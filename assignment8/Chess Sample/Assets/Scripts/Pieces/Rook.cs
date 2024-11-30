using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Rook.cs
public class Rook : Piece
{
    public override MoveInfo[] GetMoves()
    {
        // --- TODO ---
        int horizontal = Utils.FieldWidth - 1;
        int vertical = Utils.FieldHeight - 1;

        MoveInfo[] moves = new MoveInfo[4];
        moves[0] = new MoveInfo( 0,  1, vertical);
        moves[1] = new MoveInfo( 1,  0, horizontal);
        moves[2] = new MoveInfo( 0, -1, vertical);
        moves[3] = new MoveInfo(-1,  0, horizontal);
        return moves;
        // ------
    }
}
