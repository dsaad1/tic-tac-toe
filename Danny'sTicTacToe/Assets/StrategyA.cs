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
        if (BoardManager.self.Board[0, 0].filled == false)
        {
            canStrat = true;
            return BoardManager.self.Board[0, 0];
        }
        return BoardManager.self.GetRandomPiece();
    }

    public PieceInfo TurnTwo()
    {
        if (!canStrat || PlayerHasCenter())
            return BoardManager.self.GetRandomPiece();
        else  
        {
            if(!BoardManager.self.Board[0, 2].filled)
            {
                corner = 1;
                return BoardManager.self.Board[0, 2];
            }

            else if (!BoardManager.self.Board[2, 0].filled)
            {
                corner = 2;
                return BoardManager.self.Board[2, 0];
            }
           
            else if (!BoardManager.self.Board[2, 2].filled)
            {
                corner = 3;
                return BoardManager.self.Board[2, 2];
            }
            return BoardManager.self.GetRandomPiece();

        }
    }

    public PieceInfo TurnThree()
    {
        if (!canStrat || PlayerHasCenter())
            return BoardManager.self.GetRandomPiece();
        else
        {
            if (corner == 1)
            {
                if (!BoardManager.self.Board[2, 2].filled)
                    return BoardManager.self.Board[2, 2];
                else if (!BoardManager.self.Board[2, 0].filled)
                {
                    return BoardManager.self.Board[2, 0];
                }
                return BoardManager.self.GetRandomPiece();
            }

            else if (corner == 2)
            {
                if (!BoardManager.self.Board[0, 2].filled)
                    return BoardManager.self.Board[0, 2];
                else if (!BoardManager.self.Board[2, 2].filled)
                {
                    return BoardManager.self.Board[2, 2];
                }
                return BoardManager.self.GetRandomPiece();
            }

            else if (corner == 3)
            {
                if (!BoardManager.self.Board[0, 2].filled)
                    return BoardManager.self.Board[0, 2];
                else if (!BoardManager.self.Board[2, 0].filled)
                {
                    return BoardManager.self.Board[2, 0];
                }
                return BoardManager.self.GetRandomPiece();
            }


            return BoardManager.self.GetRandomPiece();
        }
        
        
        

    }

    void CopyList(List<string> aList)
    {
        foreach(string s in aList)
        {
            activeStrategy.Add(s);
        }
    }



}
