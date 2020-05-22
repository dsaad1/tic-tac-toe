using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerBase : MonoBehaviour
{
    [Header("DEBUGGING")]
    [SerializeField] bool gameIsActive;
    [SerializeField] bool debug; 



    protected void StartGame()
    {
        Controls.self.OnGameStart();
        UIManager.self.OnGameStart();
        PlayerMovement.self.OnGameStart();
        CameraMovement.self.OnGameStart();
        GASuite.self.OnGameStart();


        if (LevelManager.self.GetLevel() == 0)
        {
            Tutorial.self.OnStart();
        }

        gameIsActive = true;
        if(debug)
            Debug.Log("game started");
    }


    protected void EndGame(string status)
    {
        gameIsActive = false;
        UIManager.self.OnGameEnd(status);
        LevelManager.self.OnGameEnd(status);
        FXManager.self.OnGameEnd(status);
        PlayerMovement.self.OnGameEnd(status);
        CameraMovement.self.OnGameEnd(status);
        Player.self.OnGameEnd(status);
        Controls.self.OnGameEnd();
        GASuite.self.OnGameOver(status);

        if (status == "win")
        {
            

           

        }
        else if (status == "tie")
        {
            Debug.Log("tie");

         

        }
        else
        {




        }
    }


    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
    }

    public bool GameIsActive()
    {
        return gameIsActive;
    }

    public bool GameIsNotActive()
    {
        return !gameIsActive;
    }
}
