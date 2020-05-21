using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueLerper : MonoBehaviour
{
    public static ValueLerper self;


    private void Awake()
    {
        self = this;
    }

    public void LerpValue(Image anImage, float aValue, float aValueToLerpTo)
    {
        StartCoroutine(Lerp(anImage, aValue, aValueToLerpTo));
    }

    IEnumerator Lerp(Image anImage, float aValue, float aValueToLerpTo)
    {
        int iterations = 20;
        float timeBetweenLerps = .001f;

        //calculate the differences between the current color and the color you want to lerp to 
        float diff = (aValueToLerpTo - aValue) / (float)iterations;


        //lerp the color over the amount of iterations
        for (int i = 0; i < iterations; i++)
        {
            anImage.fillAmount += diff;
            yield return new WaitForSeconds(timeBetweenLerps);
        }
    }

    public void LerpValue(float aValue, float aValueToLerpTo, float seconds)
    {
        StartCoroutine(Lerp(aValue, aValueToLerpTo, seconds));
    }

    IEnumerator Lerp(float aValue, float aValueToLerpTo, float seconds)
    {
        int iterations = 20;
        float timeBetweenLerps = seconds;



        //calculate the differences between the current color and the color you want to lerp to 
        float diff = (aValueToLerpTo - aValue) / (float)iterations;


        //lerp the color over the amount of iterations
        for (int i = 0; i < iterations; i++)
        {

            aValue += diff;
            yield return new WaitForSeconds(timeBetweenLerps);
        }
    }
}