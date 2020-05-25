using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    public static WinManager self;
    [SerializeField] List<PieceInfo> diagonal1 = new List<PieceInfo>();
    [SerializeField] List<PieceInfo> diagonal2 = new List<PieceInfo>();
    [SerializeField] List<PieceInfo> vertical1 = new List<PieceInfo>();
    [SerializeField] List<PieceInfo> vertical2 = new List<PieceInfo>();
    [SerializeField] List<PieceInfo> vertical3 = new List<PieceInfo>();
    [SerializeField] List<PieceInfo> horizontal1 = new List<PieceInfo>();
    [SerializeField] List<PieceInfo> horizontal2 = new List<PieceInfo>();
    [SerializeField] List<PieceInfo> horizontal3 = new List<PieceInfo>();
    public string whoWon = "";

    private void Awake()
    {
        self = this;
    }

    public bool CheckPieces(List<PieceInfo> piecesToCheck)
    {
        bool returnValue = true;

        string belongsTo = "";

        for (int i = 0; i < piecesToCheck.Count; i++)
        {
            if (i == 0 && piecesToCheck[i].filled == true)
                belongsTo = piecesToCheck[i].player;
            
            if (!piecesToCheck[i].filled || piecesToCheck[i].player != belongsTo)
            {
                return false;
            }  
        }

        if (returnValue == true)
            whoWon = belongsTo;

        return returnValue;
    }

    public bool CheckForWin()
    {
        Debug.Log("run");
        if (CheckPieces(diagonal1) || CheckPieces(diagonal2))
            return true;
        else if (CheckPieces(vertical1) || CheckPieces(vertical2) || CheckPieces(vertical3))
            return true;
        else if (CheckPieces(horizontal1) || CheckPieces(horizontal2) || CheckPieces(horizontal3))
            return true;

        return false;
    }



}
