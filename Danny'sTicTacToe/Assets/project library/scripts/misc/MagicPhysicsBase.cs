using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MagicPhysicsBase : MonoBehaviour
{
    [SerializeField] Rigidbody rb;


    public void AddForce(float force, Vector3 direction)
    {
        rb.AddForce(direction * force, ForceMode.Impulse);
    }

    public void AdddTorque(float force, Vector3 direction)
    {
        rb.AddTorque(direction * force, ForceMode.Impulse);
    }

    public void ResetRb()
    {
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
    }

    public void PauseRb()
    {
        rb.useGravity = false;
        rb.isKinematic = true;
    }

    public void ResumeRb()
    {
        rb.isKinematic = false;
        rb.useGravity = true;
    }

    public void ClearRb()
    {
        rb.velocity = Vector3.zero;
    }

    public void SetVelocity(Vector3 aSpeed)
    {
        rb.velocity = aSpeed;
    }

    public float GetVelocity()
    {
        return rb.velocity.magnitude;
    }

    public void RemoveAllConstraints()
    {
        rb.constraints = RigidbodyConstraints.None;
    }

    public void FreezeRotations()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
}
