using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkinsManagerBase : MonoBehaviour
{
    public List<PlayerSkin> skins = new List<PlayerSkin>();

    [Header("DEBUGGING")]
    [SerializeField] protected PlayerSkin activeSkin;


    public PlayerSkin GetActiveSkin()
    {
        return activeSkin;
    }

    public PlayerSkin GetRandomSkin()
    {
        return skins[Random.Range(0, skins.Count)];
    }

    public void SetActiveSkin(PlayerSkin skin)
    {
        activeSkin = skin;
        SetActiveSkinIndex(skin.GetIndex());
    }

    protected void SetActiveSkinIndex(int val)
    {
        PlayerPrefs.SetInt("active skin index", val);
    }

    protected int GetActiveSkinIndex()
    {
        return PlayerPrefs.GetInt("active skin index");
    }

    public void UnlockAll()
    {
        foreach (PlayerSkin skin in skins)
        {
            skin.Unlock();
        }
    }

    public void LockAll()
    {
        foreach (PlayerSkin skin in skins)
        {
            skin.Lock();
        }
    }

    public void ClearAll()
    {
        foreach (PlayerSkin skin in skins)
        {
            skin.Clear();
        }
    }
}
