using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollision : MonoBehaviour
{
    public Coin coin;

    [SerializeField] Collider col;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "coin trigger")
        {
            DisableCollision();
            coin.gameObject.SetActive(false);
            if (GameSettings.self.UseHaptics())
                iOSHapticController.instance.TriggerImpactLight();
            Currency.self.IncreasePlayerCurrencyBy(1);
        }
    }

    public void EnableCollision()
    {
        col.enabled = true;
    }

    public void DisableCollision()
    {
        col.enabled = false;
    }
}
