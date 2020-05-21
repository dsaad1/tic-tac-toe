using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PlayerSkinBase: MonoBehaviour 
{
    [Tooltip("name of the skin referenced in code")] [SerializeField] string id;
    [Tooltip("index of the skin referenced in code")] [SerializeField] int index;
    [Header("STATUS")]
    [SerializeField] bool unlockedByDefault;
    [SerializeField] bool unlocked; 

    private void Awake()
    {
        CheckForIfDefault();
        CheckUnlockStatus();
    }

    void CheckUnlockStatus()
    {
        if(isUnlocked())
        {
            unlocked = true;
        }
        else
        {
            unlocked = false; 
        }
    }

    void CheckForIfDefault()
    {
        if (unlockedByDefault && !isUnlocked())
        {
            Unlock();
        }

    }

    public bool isUnlocked()
    {
        if (PlayerPrefs.GetInt(id + " unlocked") == 1)
        {
            return true;
        }
        return false;
    }

    public void Unlock()
    {
        PlayerPrefs.SetInt(id + " unlocked", 1);
        CheckUnlockStatus();
    }

    public void Lock()
    {
        PlayerPrefs.SetInt(id + " unlocked", 0);
        CheckUnlockStatus();
    }

    public void Clear()
    {
        PlayerPrefs.SetInt(id + " unlocked", 0);
        CheckUnlockStatus();
    }

    void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteKey(id + " unlocked");
    }

    public void Delete()
    {
        DeletePlayerPrefs();
        DestroyImmediate(gameObject);
    }

    //PROPERTIES
    #region
    public string GetName()
    {
        return id;
    }
    public void SetName(string val)
    {
        id = val;
    }
    public int GetIndex()
    {
        return index;
    }
    public void SetIndex(int val)
    {
        index = val;
    }
    #endregion
}
