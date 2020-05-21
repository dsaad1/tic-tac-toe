using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResizer : MonoBehaviour
{

    private void Start()
    {
        float desiredAspectRatio = 9f / 16f;
        float aspectRatio = (float)Screen.width / (float)Screen.height;
        float difference = aspectRatio - desiredAspectRatio;
        float adjustment = difference * 100;
        adjustment = Mathf.Clamp(adjustment, adjustment, 0);
        transform.localPosition = new Vector3(0, 0, adjustment);
    }

  
}
