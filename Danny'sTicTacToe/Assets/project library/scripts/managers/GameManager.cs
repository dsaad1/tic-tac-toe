using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : GameManagerBase {

    public static GameManager self;

    bool endGameHasBeenCalled;
    bool startGameHasBeenCalled;

    private void Awake()
    {
        self = this;
    }

    public new void StartGame()
    {
        if(!startGameHasBeenCalled)
        {
            startGameHasBeenCalled = true;
            base.StartGame();
            BoardManager.self.OnGameStart();
        }
    }

    public new void EndGame(string status)
    {
        if(!endGameHasBeenCalled)
        {
            endGameHasBeenCalled = true;
            base.EndGame(status);
        }
       
    }

}
