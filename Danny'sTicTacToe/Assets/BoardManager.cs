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
    public Sprite x;
    public Sprite o;
    bool hasSelectedIcon;
    bool hasSelectedDifficulty;
    public AIBase easyAI;
    public AIBase hardAI;


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

        if (Player.self.icon.name == "x")
        {
            activeAI.SetIcon(o);
        }
        else
        {
            activeAI.SetIcon(x);
        }

    }

    public void CheckBoard()
    {
        if (WinManager.self.CheckForWin() && WinManager.self.whoWon == "player")
        {
            GameManager.self.EndGame("win");
        }
        else if (WinManager.self.CheckForWin() && WinManager.self.whoWon == "AI")
        {
            GameManager.self.EndGame("lose");
        }
        else if (availablePieces.Count == 0)
        {
            GameManager.self.EndGame("tie");
            UIManager.self.drawText.SetActive(true);

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

    public void SelectIcon(string anIcon)
    {
        if (anIcon == "x")
        {
            Player.self.icon = x;
        }
        else
        {
            Player.self.icon = o;
        }

        hasSelectedIcon = true;
        ActivatePlayButton();
    }

    public void SelectDifficulty(string aDifficulty)
    {
        if (aDifficulty == "easy")
        {
            activeAI = easyAI;
        }
        else
        {
            activeAI = hardAI;
        }

        hasSelectedDifficulty = true;
        ActivatePlayButton();
    }

    void ActivatePlayButton()
    {
        if (hasSelectedIcon && hasSelectedDifficulty)
            UIManager.self.playButton.SetActive(true);
    }


}
