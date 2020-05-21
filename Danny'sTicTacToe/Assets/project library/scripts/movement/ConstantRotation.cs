using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotation : MonoBehaviour
{

    public float rotSpeed;
    public Vector3 axis;
    public bool rot;

    [SerializeField] bool randomizeDirection;
    [SerializeField] bool randomizeSpeed;
    [SerializeField] float[] speedRange;


    private void Start()
    {
        if (randomizeDirection)
            RandomizeDirection();

        if (randomizeSpeed)
            RandomizeSpeed();

    }

    void RandomizeSpeed()
    {
        rotSpeed = Random.Range(speedRange[0], speedRange[1]);
    }

    void RandomizeDirection()
    {
        int random = Random.Range(0, 2);
        if (random == 1)
        {
            if (axis.x != 0)
            {
                axis.x *= -1;
            }
            else if (axis.y != 0)
            {
                axis.y *= -1;
            }
            else if (axis.z != 0)
            {
                axis.z *= -1;
            }
        }

    }

    public void Go()
    {
        rot = true;
    }

    public void Stop()
    {
        rot = false;
    }

    public void SetSpeed(float aSpeed)
    {
        rotSpeed = aSpeed;
    }

    private void FixedUpdate()
    {
        if (rot)
        {
            transform.Rotate(axis * rotSpeed * Time.deltaTime);
        }
    }
}
