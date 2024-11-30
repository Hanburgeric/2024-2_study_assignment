using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Piece
{
    public override MoveInfo[] GetMoves()
    {
        // --- TODO ---
        int diagonal = Mathf.Min(Utils.FieldWidth, Utils.FieldHeight) - 1;

        MoveInfo[] moves = new MoveInfo[4];
        moves[0] = new MoveInfo( 1,  1, diagonal);
        moves[1] = new MoveInfo( 1, -1, diagonal);
        moves[2] = new MoveInfo(-1, -1, diagonal);
        moves[3] = new MoveInfo(-1,  1, diagonal);
        return moves;
        // ------
    }
}