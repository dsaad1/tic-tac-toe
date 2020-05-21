using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSetter : MonoBehaviour {

    public static ColorSetter self;


    private void Awake()
    {
        self = this;
    }

    public void SetColor(ParticleSystem p, Color aColor)
    {
        p.GetComponent<ParticleSystem>().startColor = aColor;
    }

    public void SetColor(ParticleSystem[] p, Color aColor)
    {
        foreach(ParticleSystem parts in p)
        {
            parts.GetComponent<ParticleSystem>().startColor = aColor;
        }  
    }

    public void SetColor(GameObject g, Color aColor)
    {
        g.GetComponent<MeshRenderer>().material.color = aColor;
    }
    public void SetColor(GameObject[] g, Color aColor)
    {
        foreach(GameObject obj in g)
        {
            obj.GetComponent<MeshRenderer>().material.color = aColor;
        }    
    }

}
