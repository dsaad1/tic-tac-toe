using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulemMotion : MonoBehaviour {

    public Transform pivot;
    public float speed = 0.5f;
    private Vector3 v3Pivot;  // Pivot in screen space
    public bool move = true;
    private float startAngle = -50.0f;
    private float endAngle = 50.0f;
    private float fTimer = 0.0f;
    private float angleDiff;
    private Vector3 v3T = Vector3.zero;
    private float angle;
    public int currentSide;
    public float dir;
    float lastRot;


    void Start()
    {
        v3Pivot = Camera.main.WorldToScreenPoint(pivot.position);
    }

    void Update()
    {
        if (move)
        {
            float f = (Mathf.Sin(fTimer * speed - Mathf.PI / 2.0f) + 1.0f) / 2.0f;

            v3T.Set(0.0f, 0.0f, Mathf.Lerp(startAngle, endAngle, f));
            pivot.localEulerAngles = v3T;

            fTimer += Time.deltaTime * dir;
        }
    }
}
