using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardAI : AIBase
{
    int turn = 1;
    public List<GameObject> strategies = new List<GameObject>();
    private GameObject currentStrategy;

    private void Start()
    {
        currentStrategy = strategies[Random.Range(0, strategies.Count)];
    }


    public new void TakeTurn()
    {
       PieceInfo tempPiece = null;
       if (currentStrategy.GetComponent<StrategyA>() != null)
        {
            tempPiece = currentStrategy.GetComponent<StrategyA>().TakeTurn(turn);
        }

        else if (currentStrategy.GetComponent<StrategyB>() != null)
        {
            tempPiece = currentStrategy.GetComponent<StrategyB>().TakeTurn(turn);
        }


        if (tempPiece != null)
        {
            tempPiece.assignSquare("AI", icon);
            turn++;
        }
    }
    
    


}
