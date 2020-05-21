using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [HideInInspector] [SerializeField] List<Vector3> ogPositions = new List<Vector3>();
    [SerializeField] Vector3 defaultPos;
    [SerializeField] Transform coinParent;
    [SerializeField] List<GameObject> coins = new List<GameObject>();

    GameObject coinPrefab;


    public void AddCoin()
    {
        if (coinPrefab == null)
            GetCoinPrefab();

        GameObject newCoin = Instantiate(coinPrefab, Vector3.zero, Quaternion.identity);
        if (coinParent == null)
            coinParent = transform;
        newCoin.transform.SetParent(coinParent);
        ResetObj(newCoin);
        newCoin.transform.localPosition = defaultPos;
        coins.Add(newCoin);
    }

    public void DeleteAllCoins()
    {
        int size = coins.Count;
        for (int i = 0; i < size; i++)
        {
            GameObject tmp = coins[0];
            coins.Remove(coins[0]);
            DestroyImmediate(tmp.gameObject);
        }

        coins.Clear();
    }

    public void DeleteLastCoin()
    {
        GameObject tmp = coins[coins.Count - 1];
        coins.Remove(coins[coins.Count - 1]);
        DestroyImmediate(tmp);
    }

    void ResetObj(GameObject obj)
    {
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localEulerAngles = Vector3.zero;
        obj.transform.localScale = Vector3.one;
    }

    public void ReplaceAll()
    {
        int size = coins.Count;

        foreach (GameObject g in coins)
        {
            ogPositions.Add(g.transform.localPosition);
        }

        DeleteAllCoins();
        for (int i = 0; i < size; i++)
        {
            AddCoin();
        }
        for (int i = 0; i < size; i++)
        {
            coins[i].transform.localPosition = ogPositions[i];
        }
        ogPositions.Clear();
    }


    public void GetCoinPrefab()
    {
        GameObject[] statics = GameObject.FindGameObjectsWithTag("static");
        foreach (GameObject g in statics)
        {
            if (g.name == "Currency Manager")
            {
                coinPrefab = g.GetComponent<Currency>().currencyObj;
            }
        }
    }
}
