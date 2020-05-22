using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BoardManager : MonoBehaviour
{
    public static BoardManager self;
    public List<PieceInfo> availablePieces = new List<PieceInfo> ();
    public PieceInfo[,] Board = new PieceInfo[3,3];
    public List<PieceInfo> originalPieces = new List<PieceInfo>();
    public bool PlayerCanGo = true;
    public AIBase activeAI;


    void Awake ()
    {
        self = this;
    }

    public void OnGameStart()
    {
        for (int c = 0; c < 3; c++)
        {
            for (int r = 0; r < 3; r++)
            {
                PieceInfo currentPiece = originalPieces[(c * 3) + r];
                Board[c, r] = currentPiece;
                currentPiece.Initialize(r, c); 

            }

        }

    }

    public void CheckBoard()
    {
        if (availablePieces.Count == 0)
        {
            GameManager.self.EndGame("tie");

        }

    }

    public PieceInfo GetRandomPiece()
    {
        PieceInfo tempPiece = null;
        if (availablePieces.Count > 0)
        {
            tempPiece = availablePieces[Random.Range(0, availablePieces.Count)];
        }
        return tempPiece;
    }

    public void PlayerTurn()
    {
        PlayerCanGo = true;
    }

    public void AITurn()
    {
        PlayerCanGo = false;
        activeAI.TakeTurn();
    }
}
