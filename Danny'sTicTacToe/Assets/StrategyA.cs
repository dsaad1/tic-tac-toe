using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrategyA : MonoBehaviour
{
    public bool canStrat = false;
    public List<string> activeStrategy = new List<string>();
    public List<string> strategyA = new List<string>();
    public List<string> strategyB = new List<string>();
    public List<string> strategyC = new List<string>();
    public List<string> strategyD = new List<string>();
    private int corner;
    private int whichAlg;
    private bool winFound;
    private PieceInfo tempPiece;


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
                tempPiece = TurnThree();
                break;

            case 4:
                tempPiece = TurnFour();
                break;
            case 5:
                tempPiece = BoardManager.self.GetRandomPiece();
                break;
        }
        return tempPiece;
    }

    bool PlayerHasCenter()
    {
        if (BoardManager.self.Board[0, 0].player == "player")
            return true;
        return false;
    }

    PieceInfo GetBoardPiece()
    {
        int y = int.Parse(activeStrategy[0].Substring(0, 1));
        int x = int.Parse(activeStrategy[0].Substring(1, 1));
        activeStrategy.Remove(activeStrategy[0]);
        Debug.Log(x);
        Debug.Log(y);
        return BoardManager.self.Board[x, y];
    }

    public PieceInfo TurnOne()
    {
        if (!BoardManager.self.Board[0, 0].filled)
        {
            canStrat = true;
            return BoardManager.self.Board[0, 0];
        }
        return BoardManager.self.Board[1, 1];
    }

    public PieceInfo TurnTwo()
    {
        if ((tempPiece = CheckForWin()) != null)
        {
            return tempPiece;
        }
        if (!canStrat || PlayerHasCenter())
            return BoardManager.self.GetRandomPiece();
        else  
        {
            if(!BoardManager.self.Board[0, 2].filled && !BoardManager.self.Board[0, 1].filled)
            {
                corner = 1;
                return BoardManager.self.Board[0, 2];
            }

            else if (!BoardManager.self.Board[2, 0].filled && !BoardManager.self.Board[1, 0].filled)
            {
                corner = 2;
                return BoardManager.self.Board[2, 0];
            }
           
            else if (!BoardManager.self.Board[2, 2].filled && !BoardManager.self.Board[2, 1].filled)
            {
                corner = 3;
                return BoardManager.self.Board[2, 2];
            }
            return BoardManager.self.GetRandomPiece();

        }
    }

    public PieceInfo TurnThree()
    {
        if ((tempPiece = CheckForWin()) != null)
        {
            return tempPiece;
        }

        if (!canStrat || PlayerHasCenter())
            return BoardManager.self.GetRandomPiece();
        else
        {
            if (corner == 1)
            {
                if (!BoardManager.self.Board[2, 2].filled && !BoardManager.self.Board[1, 2].filled)
                {
                    whichAlg = 1;
                    return BoardManager.self.Board[2, 2];
                }
                else if (!BoardManager.self.Board[2, 0].filled)
                {
                    whichAlg = 2;
                    return BoardManager.self.Board[2, 0];
                }
                return BoardManager.self.GetRandomPiece();
            }

            else if (corner == 2)
            {
                if (!BoardManager.self.Board[0, 2].filled && !BoardManager.self.Board[0, 1].filled)
                {
                    whichAlg = 1;
                    return BoardManager.self.Board[0, 2];
                }
                else if (!BoardManager.self.Board[2, 2].filled)
                {
                    whichAlg = 2;
                    return BoardManager.self.Board[2, 2];
                }
                return BoardManager.self.GetRandomPiece();
            }

            else if (corner == 3)
            {
                if (!BoardManager.self.Board[0, 2].filled && !BoardManager.self.Board[1, 2].filled)
                {
                    whichAlg = 1;
                    return BoardManager.self.Board[0, 2];
                }
                else if (!BoardManager.self.Board[2, 0].filled)
                {
                    whichAlg = 2;
                    return BoardManager.self.Board[2, 0];
                }
                return BoardManager.self.GetRandomPiece();
            }
            return BoardManager.self.GetRandomPiece();
        }
    }

    public PieceInfo TurnFour()
    {
        if ((tempPiece = CheckForWin()) != null)
        {
            return tempPiece;
        }
        return BoardManager.self.GetRandomPiece();
    }

    public PieceInfo CheckForWin()
    {

        // check for AI win

        if (BoardManager.self.Board[0, 0].filled && BoardManager.self.Board[0, 2].filled 
            && BoardManager.self.Board[0, 0].player == "AI" && BoardManager.self.Board[0, 2].player == "AI")
        {
            if (!BoardManager.self.Board[0, 1].filled)
                return BoardManager.self.Board[0, 1];
        }
        if (BoardManager.self.Board[0, 0].filled && BoardManager.self.Board[2, 0].filled
            && BoardManager.self.Board[0, 0].player == "AI" && BoardManager.self.Board[2, 0].player == "AI")
        {
            if (!BoardManager.self.Board[1, 0].filled)
                return BoardManager.self.Board[1, 0];
        }
        if (BoardManager.self.Board[2, 0].filled && BoardManager.self.Board[2, 2].filled
            && BoardManager.self.Board[2, 0].player == "AI" && BoardManager.self.Board[2, 2].player == "AI")
        {
            if (!BoardManager.self.Board[2, 1].filled)
                return BoardManager.self.Board[2, 1];
        }
        if (BoardManager.self.Board[2, 2].filled && BoardManager.self.Board[0, 2].filled
            && BoardManager.self.Board[2, 2].player == "AI" && BoardManager.self.Board[0, 2].player == "AI")
        {
            if (!BoardManager.self.Board[1, 2].filled)
                return BoardManager.self.Board[1, 2];
        }
        if (BoardManager.self.Board[2, 1].filled && BoardManager.self.Board[0, 1].filled
            && BoardManager.self.Board[2, 1].player == "AI" && BoardManager.self.Board[0, 1].player == "AI")
        {
            if (!BoardManager.self.Board[1, 1].filled)
                return BoardManager.self.Board[1, 1];
        }
        if (BoardManager.self.Board[1, 0].filled && BoardManager.self.Board[1, 2].filled
            && BoardManager.self.Board[1, 0].player == "AI" && BoardManager.self.Board[1, 2].player == "AI")
        {
            if (!BoardManager.self.Board[1, 1].filled)
                return BoardManager.self.Board[1, 1];
        }
        if (BoardManager.self.Board[0, 0].filled && BoardManager.self.Board[2, 2].filled
            && BoardManager.self.Board[0, 0].player == "AI" && BoardManager.self.Board[2, 2].player == "AI")
        {
            if (!BoardManager.self.Board[1, 1].filled)
                return BoardManager.self.Board[1, 1];
        }
        if (BoardManager.self.Board[2, 0].filled && BoardManager.self.Board[0, 2].filled
            && BoardManager.self.Board[2, 0].player == "AI" && BoardManager.self.Board[0, 2].player == "AI")
        {
            if (!BoardManager.self.Board[1, 1].filled)
                return BoardManager.self.Board[1, 1];
        }
        if (BoardManager.self.Board[0, 0].filled && BoardManager.self.Board[1, 0].filled
            && BoardManager.self.Board[0, 0].player == "AI" && BoardManager.self.Board[1, 0].player == "AI")
        {
            if (!BoardManager.self.Board[2, 0].filled)
                return BoardManager.self.Board[2, 0];
        }
        if (BoardManager.self.Board[2, 0].filled && BoardManager.self.Board[1, 0].filled
            && BoardManager.self.Board[2, 0].player == "AI" && BoardManager.self.Board[1, 0].player == "AI")
        {
            if (!BoardManager.self.Board[0, 0].filled)
                return BoardManager.self.Board[0, 0];
        }
        if (BoardManager.self.Board[2, 1].filled && BoardManager.self.Board[1, 1].filled
            && BoardManager.self.Board[1, 1].player == "AI" && BoardManager.self.Board[1, 1].player == "AI")
        {
            if (!BoardManager.self.Board[0, 1].filled)
                return BoardManager.self.Board[0, 1];
        }
        if (BoardManager.self.Board[0, 1].filled && BoardManager.self.Board[1, 1].filled
            && BoardManager.self.Board[0, 1].player == "AI" && BoardManager.self.Board[1, 1].player == "AI")
        {
            if (!BoardManager.self.Board[2, 1].filled)
                return BoardManager.self.Board[2, 1];
        }
        if (BoardManager.self.Board[2, 2].filled && BoardManager.self.Board[1, 2].filled
            && BoardManager.self.Board[2, 2].player == "AI" && BoardManager.self.Board[1, 2].player == "AI")
        {
            if (!BoardManager.self.Board[0, 2].filled)
                return BoardManager.self.Board[0, 2];
        }
        if (BoardManager.self.Board[0, 2].filled && BoardManager.self.Board[1, 2].filled
            && BoardManager.self.Board[0, 2].player == "AI" && BoardManager.self.Board[1, 2].player == "AI")
        {
            if (!BoardManager.self.Board[2, 2].filled)
                return BoardManager.self.Board[2, 2];
        }
        if (BoardManager.self.Board[0, 0].filled && BoardManager.self.Board[0, 1].filled
            && BoardManager.self.Board[0, 0].player == "AI" && BoardManager.self.Board[0, 1].player == "AI")
        {
            if (!BoardManager.self.Board[0, 2].filled)
                return BoardManager.self.Board[0, 2];
        }
        if (BoardManager.self.Board[0, 1].filled && BoardManager.self.Board[0, 2].filled
            && BoardManager.self.Board[0, 1].player == "AI" && BoardManager.self.Board[0, 2].player == "AI")
        {
            if (!BoardManager.self.Board[0, 0].filled)
                return BoardManager.self.Board[0, 0];
        }
        if (BoardManager.self.Board[1, 1].filled && BoardManager.self.Board[1, 2].filled
            && BoardManager.self.Board[1, 1].player == "AI" && BoardManager.self.Board[1, 2].player == "AI")
        {
            if (!BoardManager.self.Board[1, 0].filled)
                return BoardManager.self.Board[1, 0];
        }
        if (BoardManager.self.Board[1, 0].filled && BoardManager.self.Board[1, 1].filled
            && BoardManager.self.Board[1, 0].player == "AI" && BoardManager.self.Board[1, 1].player == "AI")
        {
            if (!BoardManager.self.Board[1, 2].filled)
                return BoardManager.self.Board[1, 2];
        }
        if (BoardManager.self.Board[2, 0].filled && BoardManager.self.Board[2, 1].filled
            && BoardManager.self.Board[2, 0].player == "AI" && BoardManager.self.Board[2, 1].player == "AI")
        {
            if (!BoardManager.self.Board[2, 2].filled)
                return BoardManager.self.Board[2, 2];
        }
        if (BoardManager.self.Board[2, 1].filled && BoardManager.self.Board[2, 2].filled
            && BoardManager.self.Board[2, 1].player == "AI" && BoardManager.self.Board[2, 2].player == "AI")
        {
            if (!BoardManager.self.Board[2, 0].filled)
                return BoardManager.self.Board[2, 0];
        }
        if (BoardManager.self.Board[2, 0].filled && BoardManager.self.Board[1, 1].filled
           && BoardManager.self.Board[2, 0].player == "AI" && BoardManager.self.Board[1, 1].player == "AI")
        {
            if (!BoardManager.self.Board[0, 2].filled)
                return BoardManager.self.Board[0, 2];
        }
        if (BoardManager.self.Board[1, 1].filled && BoardManager.self.Board[0, 2].filled
          && BoardManager.self.Board[1, 1].player == "AI" && BoardManager.self.Board[0, 2].player == "AI")
        {
            if (!BoardManager.self.Board[2, 0].filled)
                return BoardManager.self.Board[2, 0];
        }
        if (BoardManager.self.Board[0, 0].filled && BoardManager.self.Board[1, 1].filled
          && BoardManager.self.Board[0, 0].player == "AI" && BoardManager.self.Board[1, 1].player == "AI")
        {
            if (!BoardManager.self.Board[2, 2].filled)
                return BoardManager.self.Board[2, 2];
        }
        if (BoardManager.self.Board[2, 2].filled && BoardManager.self.Board[1, 1].filled
          && BoardManager.self.Board[2, 2].player == "AI" && BoardManager.self.Board[1, 1].player == "AI")
        {
            if (!BoardManager.self.Board[0, 0].filled)
                return BoardManager.self.Board[0, 0];
        }


        // check for player wins

        if (BoardManager.self.Board[0, 0].filled && BoardManager.self.Board[0, 2].filled
           && BoardManager.self.Board[0, 0].player == "player" && BoardManager.self.Board[0, 2].player == "player")
        {
            if (!BoardManager.self.Board[0, 1].filled)
                return BoardManager.self.Board[0, 1];
        }
        if (BoardManager.self.Board[0, 0].filled && BoardManager.self.Board[2, 0].filled
            && BoardManager.self.Board[0, 0].player == "player" && BoardManager.self.Board[2, 0].player == "player")
        {
            if (!BoardManager.self.Board[1, 0].filled)
                return BoardManager.self.Board[1, 0];
        }
        if (BoardManager.self.Board[2, 0].filled && BoardManager.self.Board[2, 2].filled
            && BoardManager.self.Board[2, 0].player == "player" && BoardManager.self.Board[2, 2].player == "player")
        {
            if (!BoardManager.self.Board[2, 1].filled)
                return BoardManager.self.Board[2, 1];
        }
        if (BoardManager.self.Board[2, 2].filled && BoardManager.self.Board[0, 2].filled
            && BoardManager.self.Board[2, 2].player == "player" && BoardManager.self.Board[0, 2].player == "player")
        {
            if (!BoardManager.self.Board[1, 2].filled)
                return BoardManager.self.Board[1, 2];
        }
        if (BoardManager.self.Board[2, 1].filled && BoardManager.self.Board[0, 1].filled
            && BoardManager.self.Board[2, 1].player == "player" && BoardManager.self.Board[0, 1].player == "player")
        {
            if (!BoardManager.self.Board[1, 1].filled)
                return BoardManager.self.Board[1, 1];
        }
        if (BoardManager.self.Board[1, 0].filled && BoardManager.self.Board[1, 2].filled
            && BoardManager.self.Board[1, 0].player == "player" && BoardManager.self.Board[1, 2].player == "player")
        {
            if (!BoardManager.self.Board[1, 1].filled)
                return BoardManager.self.Board[1, 1];
        }
        if (BoardManager.self.Board[0, 0].filled && BoardManager.self.Board[2, 2].filled
            && BoardManager.self.Board[0, 0].player == "player" && BoardManager.self.Board[2, 2].player == "player")
        {
            if (!BoardManager.self.Board[1, 1].filled)
                return BoardManager.self.Board[1, 1];
        }
        if (BoardManager.self.Board[2, 0].filled && BoardManager.self.Board[0, 2].filled
            && BoardManager.self.Board[2, 0].player == "player" && BoardManager.self.Board[0, 2].player == "player")
        {
            if (!BoardManager.self.Board[1, 1].filled)
                return BoardManager.self.Board[1, 1];
        }
        if (BoardManager.self.Board[0, 0].filled && BoardManager.self.Board[1, 0].filled
           && BoardManager.self.Board[0, 0].player == "player" && BoardManager.self.Board[1, 0].player == "player")
        {
            if (!BoardManager.self.Board[2, 0].filled)
                return BoardManager.self.Board[2, 0];
        }
        if (BoardManager.self.Board[2, 0].filled && BoardManager.self.Board[1, 0].filled
            && BoardManager.self.Board[2, 0].player == "player" && BoardManager.self.Board[1, 0].player == "player")
        {
            if (!BoardManager.self.Board[0, 0].filled)
                return BoardManager.self.Board[0, 0];
        }
        if (BoardManager.self.Board[2, 1].filled && BoardManager.self.Board[1, 1].filled
            && BoardManager.self.Board[1, 1].player == "player" && BoardManager.self.Board[1, 1].player == "player")
        {
            if (!BoardManager.self.Board[0, 1].filled)
                return BoardManager.self.Board[0, 1];
        }
        if (BoardManager.self.Board[0, 1].filled && BoardManager.self.Board[1, 1].filled
            && BoardManager.self.Board[0, 1].player == "player" && BoardManager.self.Board[1, 1].player == "player")
        {
            if (!BoardManager.self.Board[2, 1].filled)
                return BoardManager.self.Board[2, 1];
        }
        if (BoardManager.self.Board[2, 2].filled && BoardManager.self.Board[1, 2].filled
            && BoardManager.self.Board[2, 2].player == "player" && BoardManager.self.Board[1, 2].player == "player")
        {
            if (!BoardManager.self.Board[0, 2].filled)
                return BoardManager.self.Board[0, 2];
        }
        if (BoardManager.self.Board[0, 2].filled && BoardManager.self.Board[1, 2].filled
            && BoardManager.self.Board[0, 2].player == "player" && BoardManager.self.Board[1, 2].player == "player")
        {
            if (!BoardManager.self.Board[2, 2].filled)
                return BoardManager.self.Board[2, 2];
        }
        if (BoardManager.self.Board[0, 0].filled && BoardManager.self.Board[0, 1].filled
            && BoardManager.self.Board[0, 0].player == "player" && BoardManager.self.Board[0, 1].player == "player")
        {
            if (!BoardManager.self.Board[0, 2].filled)
                return BoardManager.self.Board[0, 2];
        }
        if (BoardManager.self.Board[0, 1].filled && BoardManager.self.Board[0, 2].filled
            && BoardManager.self.Board[0, 1].player == "player" && BoardManager.self.Board[0, 2].player == "player")
        {
            if (!BoardManager.self.Board[0, 0].filled)
                return BoardManager.self.Board[0, 0];
        }
        if (BoardManager.self.Board[1, 1].filled && BoardManager.self.Board[1, 2].filled
            && BoardManager.self.Board[1, 1].player == "player" && BoardManager.self.Board[1, 2].player == "player")
        {
            if (!BoardManager.self.Board[1, 0].filled)
                return BoardManager.self.Board[1, 0];
        }
        if (BoardManager.self.Board[1, 0].filled && BoardManager.self.Board[1, 1].filled
            && BoardManager.self.Board[1, 0].player == "player" && BoardManager.self.Board[1, 1].player == "player")
        {
            if (!BoardManager.self.Board[1, 2].filled)
                return BoardManager.self.Board[1, 2];
        }
        if (BoardManager.self.Board[2, 0].filled && BoardManager.self.Board[2, 1].filled
            && BoardManager.self.Board[2, 0].player == "player" && BoardManager.self.Board[2, 1].player == "player")
        {
            if (!BoardManager.self.Board[2, 2].filled)
                return BoardManager.self.Board[2, 2];
        }
        if (BoardManager.self.Board[2, 1].filled && BoardManager.self.Board[2, 2].filled
            && BoardManager.self.Board[2, 1].player == "player" && BoardManager.self.Board[2, 2].player == "player")
        {
            if (!BoardManager.self.Board[2, 0].filled)
                return BoardManager.self.Board[2, 0];
        }
        if (BoardManager.self.Board[2, 0].filled && BoardManager.self.Board[1, 1].filled
           && BoardManager.self.Board[2, 0].player == "player" && BoardManager.self.Board[1, 1].player == "player")
        {
            if (!BoardManager.self.Board[0, 2].filled)
                return BoardManager.self.Board[0, 2];
        }
        if (BoardManager.self.Board[1, 1].filled && BoardManager.self.Board[0, 2].filled
          && BoardManager.self.Board[1, 1].player == "player" && BoardManager.self.Board[0, 2].player == "player")
        {
            if (!BoardManager.self.Board[2, 0].filled)
                return BoardManager.self.Board[2, 0];
        }
        if (BoardManager.self.Board[0, 0].filled && BoardManager.self.Board[1, 1].filled
          && BoardManager.self.Board[0, 0].player == "player" && BoardManager.self.Board[1, 1].player == "player")
        {
            if (!BoardManager.self.Board[2, 2].filled)
                return BoardManager.self.Board[2, 2];
        }
        if (BoardManager.self.Board[2, 2].filled && BoardManager.self.Board[1, 1].filled
          && BoardManager.self.Board[2, 2].player == "player" && BoardManager.self.Board[1, 1].player == "player")
        {
            if (!BoardManager.self.Board[0, 0].filled)
                return BoardManager.self.Board[0, 0];
        }


        return null;

    }


}
