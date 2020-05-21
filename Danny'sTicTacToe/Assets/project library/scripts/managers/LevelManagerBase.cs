using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerBase : MonoBehaviour
{
    public bool UsingPrefabs;
    public bool UsingScenes;
    public bool testing;
    
    [SerializeField] int levelToTest;

    [SerializeField] Level[] levels;
    [SerializeField] Level activeLevel;

    string levelPlayerPref = "level";
    string runningLevelPlayerPref = "running level";
    //this is where levels will start to loop, 1 = starting at level 1 for each loop 
    int levelToStartTheLoopAt = 1; 

    private void Start()
    {
        if (testing)
        {
            SetLevel(levelToTest);
        }
        else
        {
            SetLevel(GetLevel());
        }

        LoadLevel();
    }

    void LoadLevel()
    {
        if (UsingPrefabs)
        {
            if (activeLevel == null)
            {
                activeLevel = Instantiate(levels[GetLevel()]);
            }
        }
        else if (UsingScenes)
        {
            SceneManager.LoadScene(GetLevel() + 1, LoadSceneMode.Additive);
        }

    }

    public void SetLevel(int aLevel)
    {
        if (aLevel >= levels.Length)
        {
            aLevel = aLevel % levels.Length + levelToStartTheLoopAt;

            PlayerPrefs.SetInt("level", aLevel);
        }
        else
        {
            PlayerPrefs.SetInt("level", aLevel);
        }

        PlayerPrefs.SetInt(levelPlayerPref, aLevel);

        if(UsingPrefabs)
        {
            activeLevel = levels[aLevel];
            activeLevel.gameObject.SetActive(true);
        }
    }

    public void SetLevel(Level aLevel)
    {
        activeLevel = aLevel;
    }

    public void IncreaseLevel()
    {
        PlayerPrefs.SetInt(levelPlayerPref, GetLevel() + 1);
        IncreaseRunningLevel();
    }

    public int GetLevel()
    {
        return PlayerPrefs.GetInt(levelPlayerPref);
    }


    public int GetRunningLevel()
    {
        return PlayerPrefs.GetInt(runningLevelPlayerPref);
    }

    void IncreaseRunningLevel()
    {
        PlayerPrefs.SetInt(runningLevelPlayerPref, GetRunningLevel() + 1);
    }


    public Level GetActiveLevel()
    {
        return activeLevel;
    }


    public string GetLevelTextToDisplay()
    {
        if (GetLevel() == 0)
            return "tutorial";
        else
            return GetLevel() + "";
    }


    protected void OnGameEnd(string status)
    {
        if(status == "win")
        {
            IncreaseLevel();
        }
        else
        {

        }
    }
}
