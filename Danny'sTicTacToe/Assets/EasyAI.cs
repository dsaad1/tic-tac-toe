using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyAI : AIBase
{
    public new void TakeTurn()
    {
        PieceInfo tempPiece = BoardManager.self.GetRandomPiece();
        if (tempPiece != null)
        {
            tempPiece.assignSquare("AI", icon);
        }
    }



}
