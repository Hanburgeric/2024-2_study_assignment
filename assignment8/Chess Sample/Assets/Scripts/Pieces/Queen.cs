using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Piece
{
    public override MoveInfo[] GetMoves()
    {
        // --- TODO ---
        int horizontal = Utils.FieldWidth - 1;
        int vertical = Utils.FieldHeight - 1;
        int diagonal = Mathf.Min(horizontal, vertical);

        MoveInfo[] moves = new MoveInfo[8];
        moves[0] = new MoveInfo( 0,  1, vertical);
        moves[1] = new MoveInfo( 1,  1, diagonal);
        moves[2] = new MoveInfo( 1,  0, horizontal);
        moves[3] = new MoveInfo( 1, -1, diagonal);
        moves[4] = new MoveInfo( 0, -1, vertical);
        moves[5] = new MoveInfo(-1, -1, diagonal);
        moves[6] = new MoveInfo(-1,  0, horizontal);
        moves[7] = new MoveInfo(-1,  1, diagonal);
        return moves;
        // ------
    }
}