using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPISettings : MonoBehaviour
{
    public static CPISettings self;


    private void Awake()
    {
        self = this;
    }
}
