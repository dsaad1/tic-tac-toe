using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationRandomizer : MonoBehaviour {


    public static RotationRandomizer self;


    private void Awake()
    {
        self = this;
    }

    public void RandomizeLocalRotation(GameObject g, Vector2 range, char axis)
    {
        switch (axis)
        {
            case 'x':
                g.transform.localEulerAngles = new Vector3(Random.Range(range.x, range.y), g.transform.localEulerAngles.y, g.transform.localEulerAngles.z);
                break;
            case 'y':
                g.transform.localEulerAngles = new Vector3(g.transform.localEulerAngles.x, Random.Range(range.x, range.y), g.transform.localEulerAngles.z);
                break;
            case 'z':
                g.transform.localEulerAngles = new Vector3(g.transform.localEulerAngles.x, g.transform.localEulerAngles.y, Random.Range(range.x, range.y));
                break;
        }
    }

    public void RandomizeWorldRotation(GameObject g, Vector2 range, char axis)
    {
        switch (axis)
        {
            case 'x':
                g.transform.localEulerAngles = new Vector3(Random.Range(range.x, range.y), g.transform.localEulerAngles.y, g.transform.localEulerAngles.z);
                break;
            case 'y':
                g.transform.localEulerAngles = new Vector3(g.transform.localEulerAngles.x, Random.Range(range.x, range.y), g.transform.localEulerAngles.z);
                break;
            case 'z':
                g.transform.localEulerAngles = new Vector3(g.transform.localEulerAngles.x, g.transform.localEulerAngles.y, Random.Range(range.x, range.y));
                break;
        }
    }
}
