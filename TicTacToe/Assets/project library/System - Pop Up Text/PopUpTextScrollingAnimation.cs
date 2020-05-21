using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 


public class PopUpTextScrollingAnimation : MonoBehaviour
{
    [SerializeField] PopUpText popUpText; 
    [SerializeField] TextMeshPro text;
    [SerializeField] int start; 

    public void Play()
    {
        StartCoroutine(P());
        popUpText.OnActivation("scrolling in");
    }

    IEnumerator P()
    {
        int iters = 50;

        for(int i = 0; i < iters; i++)
        {
            start+=2;
            text.text = "" + start;
            yield return new WaitForEndOfFrame();
        }
        
        text.text = "100";
        yield return new WaitForSeconds(.05f);
        popUpText.PlayAnimation("scrolling out");
    }

}
