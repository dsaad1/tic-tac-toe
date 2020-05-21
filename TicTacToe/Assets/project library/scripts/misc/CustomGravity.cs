using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGravity : MonoBehaviour
{
    [SerializeField] bool disableAfterSeconds;
    [SerializeField] float duration;
    [SerializeField] float gravityModifier = 15;
    [SerializeField] Rigidbody rb;


    private void OnEnable()
    {
        if (disableAfterSeconds)
            Invoke("Disable", duration);
    }

    void Disable()
    {
        this.enabled = false;
    }


    private void FixedUpdate()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (gravityModifier) * Time.deltaTime;
        }
    }
}
