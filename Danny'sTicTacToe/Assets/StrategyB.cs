using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrategyB : MonoBehaviour
{
    public PieceInfo TakeTurn(int turn)
    {
        PieceInfo tempPiece = null;
        switch (turn)
        {
            case 1:
                tempPiece = TurnOne();
                break;
            case 2:
                tempPiece = TurnTwo();
                break;
            case 3:

            case 4:

            case 5:
                tempPiece = BoardManager.self.GetRandomPiece();
                break;
        }
        return tempPiece;
    }
    public PieceInfo TurnOne()
    {
        if (BoardManager.self.Board[0, 0].filled == false)
        {
            return BoardManager.self.Board[0, 0];
        }
        return BoardManager.self.GetRandomPiece();
    }

    public PieceInfo TurnTwo()
    {
        return null;
    }
}
