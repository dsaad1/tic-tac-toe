using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAtBottomOfScreenControls : MonoBehaviour {

    public static DragAtBottomOfScreenControls self;

    bool active;

    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    Vector3 startPos;
    public float sensitivity;
    public GameObject objToMove;
    public float minXPos;
    public float maxXPos;

    float dist;

    void Awake()
    {
        self = this;
    }

    private void Start()
    {

    }


    void Update()
    {
        if (Input.touchCount == 1 && active)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                lp = touch.position;
                dist = fp.x - lp.x;
                //  Debug.Log("dist: " + dist);
                startPos = objToMove.transform.localPosition;

                objToMove.transform.localPosition = new Vector3(startPos.x + (-dist / Screen.width) * sensitivity, objToMove.transform.localPosition.y, objToMove.transform.localPosition.z);
                objToMove.transform.localPosition = new Vector3(Mathf.Clamp(objToMove.transform.localPosition.x, minXPos, maxXPos), objToMove.transform.localPosition.y, objToMove.transform.localPosition.z);

            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                lp = touch.position;
                dist = fp.x - lp.x;
                //Debug.Log("dist: " + dist);

                objToMove.transform.localPosition = new Vector3(startPos.x + (-dist / Screen.width) * sensitivity, objToMove.transform.localPosition.y, objToMove.transform.localPosition.z);
                objToMove.transform.localPosition = new Vector3(Mathf.Clamp(objToMove.transform.localPosition.x, minXPos, maxXPos), objToMove.transform.localPosition.y, objToMove.transform.localPosition.z);
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                lp = touch.position;
                dist = fp.x - lp.x;
                //    Debug.Log("dist: " + dist);

                objToMove.transform.localPosition = new Vector3(startPos.x + (-dist / Screen.width) * sensitivity, objToMove.transform.localPosition.y, objToMove.transform.localPosition.z);
                objToMove.transform.localPosition = new Vector3(Mathf.Clamp(objToMove.transform.localPosition.x, minXPos, maxXPos), objToMove.transform.localPosition.y, objToMove.transform.localPosition.z);

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
