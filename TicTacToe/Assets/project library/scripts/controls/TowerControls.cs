using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerControls : MonoBehaviour
{
    public static TowerControls self; 

    Vector3 fp;         //First touch position
    Vector3 lp;         //Last touch position
 
    public GameObject objToRotate;
    public float sensitivity;


    private void Awake()
    {
        self = this;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                fp = touch.position;
                lp = touch.position;
            }

            else if (touch.phase == TouchPhase.Moved)
            {
                lp = touch.position;

                float distance = Mathf.Abs(lp.x - fp.x) / Screen.width;

                if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                {   //If the horizontal movement is greater than the vertical movement...
                    if ((lp.x > fp.x))  //If the movement was to the right)
                    {   //Right swipe
                        objToRotate.transform.Rotate(0, sensitivity * distance, 0);

                    }
                    else
                    {   //Left swipe
                        objToRotate.transform.Rotate(0, -sensitivity * distance, 0);
                    }
                }
                fp = touch.position;
            }


            else if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                lp = touch.position;
            }
    
        }
    }
}

