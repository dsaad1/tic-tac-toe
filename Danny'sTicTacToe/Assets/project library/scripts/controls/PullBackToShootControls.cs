using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullBackToShootControls : MonoBehaviour
{

    public Camera cam;
    public GameObject indicator;
    public float scaleDenom;

    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    bool active; 


    void Update()
    {
        if (Input.touchCount == 1 && active)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                fp.z = 23;
                lp = touch.position;
                Vector3 dir = cam.ScreenToWorldPoint(lp) - cam.ScreenToWorldPoint(fp);
                float angle = Vector3.Angle(Vector3.right, dir) - 90;
                indicator.transform.localScale = Vector3.one;
                indicator.SetActive(true);
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                lp = touch.position;
                lp.z = 23;
                //   ballModel.SetActive(true);
                Vector3 dir = cam.ScreenToWorldPoint(lp) - cam.ScreenToWorldPoint(fp);
                float angle = Vector3.Angle(Vector3.right, dir) - 90;
                indicator.transform.localRotation = Quaternion.Euler(0, angle, 0);
                float swipeLength = dir.magnitude;
                indicator.transform.localScale = new Vector3(1, 1, swipeLength / scaleDenom);

            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                lp = touch.position;
                lp.z = 23;

                Vector3 dir = cam.ScreenToWorldPoint(lp) - cam.ScreenToWorldPoint(fp);
                float angle = Vector3.Angle(Vector3.right, dir) - 90;
                indicator.transform.localRotation = Quaternion.Euler(0, angle, 0);
                indicator.SetActive(false);
                Vector3 direction = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;

                float swipeLength = dir.magnitude;

           
                // verticalForce = Mathf.Pow(1.1f, swipeLength);


            }


        }
    }





    public void Enable()
    {
        active = true;
        Debug.Log("controls enabled!");
    }

    public void Disable()
    {
        active = false;
        Debug.Log("controls disabeled!");
    }

}
