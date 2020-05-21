﻿using UnityEngine;
using System.Collections;

public class SwipeControls : MonoBehaviour
{
    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered

    public static SwipeControls self;

    void Awake()
    {
        self = this; 
    }

    void Start()
    {
        dragDistance = Screen.height * 15 / 100; //dragDistance is 15% height of the screen
    }

    void Update()
    {
        
        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch

            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                lp = touch.position;
                /*covert to world space if needed
                lpC = cam.ScreenToWorldPoint(lp);
                lpC.z = 0;*/
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                lp = touch.position;
                /*covert to world space if needed
                lpC = cam.ScreenToWorldPoint(lp);
                lpC.z = 0;*/

                //Check if drag distance is greater than 20% of the screen height
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {//It's a drag
                    //check if the drag is vertical or horizontal
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {   //If the horizontal movement is greater than the vertical movement...
                        if ((lp.x > fp.x))  //If the movement was to the right)
                        {   //Right swipe

                        }
                        else
                        {   //Left swipe

                        }
                    }
                    else
                    {   //the vertical movement is greater than the horizontal movement                 
                        if (lp.y > fp.y)  //If the movement was up
                        {   //Up swipe

                        }
                        else
                        {   //Down swipe

                        }
                    }
                }
            }
            else
            {   //It's a tap as the drag distance is less than 20% of the screen height

            }       
        }        
    }
}

