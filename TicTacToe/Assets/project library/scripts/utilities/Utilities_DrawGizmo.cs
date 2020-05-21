using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities_DrawGizmo : MonoBehaviour {

    [Header("Colors")]
    public bool red;
    public bool blue;
    public bool green;
    public bool yellow;
    public bool cyan;
    public bool white;
    public bool grey; 

    void OnDrawGizmos()
    {
        SetColor(); 
        Gizmos.DrawWireCube(transform.position,new Vector3(transform.lossyScale.x,transform.lossyScale.y,transform.lossyScale.z)); 
    }

    void SetColor()
    {
        if (red)
        {
            Gizmos.color = Color.red; 
        }
        else if (blue)
        {
            Gizmos.color = Color.blue;
        }
        else if (green)
        {
            Gizmos.color = Color.green;
        }
        else if (yellow)
        {
            Gizmos.color = Color.yellow;
        }
        else if (cyan)
        {
            Gizmos.color = Color.cyan;
        }
        else if (white)
        {
            Gizmos.color = Color.white;
        }
        else if (grey)
        {
            Gizmos.color = Color.grey;
        }
        else
        {
            Gizmos.color = Color.red;
        }
    }
	
}
