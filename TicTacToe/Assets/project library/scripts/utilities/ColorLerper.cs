using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorLerper : MonoBehaviour {

    public static ColorLerper self;



    private void Awake()
    {
        self = this;
    }

    //STANDARD FUNCTIONS
    #region
    // COLOR LERPING ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    #region
    //use this to lerp a UI asset
    public void LerpUIImage(Image anImage, Color colorToLerpTo, int iterations, float timeBetweenLerps)
    {
        StartCoroutine(LUII(anImage, colorToLerpTo, iterations, timeBetweenLerps));
    }

    IEnumerator LUII(Image anImage, Color colorToLerpTo, int iterations, float timeBetweenLerps)
    {
        //store a reference to the image component
        Image imageComp = anImage.GetComponent<Image>();
        //store the image's current color
        Color currentColor = imageComp.color;

        //calculate the differences between the current color and the color you want to lerp to 
        float rDiff = (currentColor.r - colorToLerpTo.r) / (float)iterations;
        float gDiff = (currentColor.g - colorToLerpTo.g) / (float)iterations;
        float bDiff = (currentColor.b - colorToLerpTo.b) / (float)iterations;
        float aDiff = (currentColor.a - colorToLerpTo.a) / (float)iterations;

        //lerp the color over the amount of iterations
        for (int i = 0; i < iterations; i++)
        {
            Color newColor = new Color(imageComp.color.r - rDiff, imageComp.color.g - gDiff, imageComp.color.b - bDiff, imageComp.color.a - aDiff);
            imageComp.color = newColor;
            yield return new WaitForSeconds(timeBetweenLerps);
        }
    }

    public void LerpUIImage(Text aText, Color colorToLerpTo, int iterations, float timeBetweenLerps)
    {
        StartCoroutine(LUIT(aText, colorToLerpTo, iterations, timeBetweenLerps));
    }

    IEnumerator LUIT(Text aText, Color colorToLerpTo, int iterations, float timeBetweenLerps)
    {
        //store a reference to the image component
        Text textComp = aText.GetComponent<Text>();
        //store the image's current color
        Color currentColor = textComp.color;

        //calculate the differences between the current color and the color you want to lerp to 
        float rDiff = (currentColor.r - colorToLerpTo.r) / (float)iterations;
        float gDiff = (currentColor.g - colorToLerpTo.g) / (float)iterations;
        float bDiff = (currentColor.b - colorToLerpTo.b) / (float)iterations;
        float aDiff = (currentColor.a - colorToLerpTo.a) / (float)iterations;

        //lerp the color over the amount of iterations
        for (int i = 0; i < iterations; i++)
        {
            Color newColor = new Color(textComp.color.r - rDiff, textComp.color.g - gDiff, textComp.color.b - bDiff, textComp.color.a - aDiff);
            textComp.color = newColor;
            yield return new WaitForSeconds(timeBetweenLerps);
        }
    }

    public void LerpSprite(SpriteRenderer aSprite, Color colorToLerpTo, int iterations, float timeBetweenLerps)
    {
        StartCoroutine(LUIS(aSprite, colorToLerpTo, iterations, timeBetweenLerps));
    }

    IEnumerator LUIS(SpriteRenderer aSprite, Color colorToLerpTo, int iterations, float timeBetweenLerps)
    {
        //store the image's current color
        Color currentColor = aSprite.color;

        //calculate the differences between the current color and the color you want to lerp to 
        float rDiff = (currentColor.r - colorToLerpTo.r) / (float)iterations;
        float gDiff = (currentColor.g - colorToLerpTo.g) / (float)iterations;
        float bDiff = (currentColor.b - colorToLerpTo.b) / (float)iterations;
        float aDiff = (currentColor.a - colorToLerpTo.a) / (float)iterations;

        //lerp the color over the amount of iterations
        for (int i = 0; i < iterations; i++)
        {
            Color newColor = new Color(aSprite.color.r - rDiff, aSprite.color.g - gDiff, aSprite.color.b - bDiff, aSprite.color.a - aDiff);
            aSprite.color = newColor;
            yield return new WaitForSeconds(timeBetweenLerps);
        }
    }

    public void Lerp(TrailRenderer aTrail, Color colorToLerpTo, int iterations, float timeBetweenLerps)
    {
        StartCoroutine(LTR(aTrail, colorToLerpTo, iterations, timeBetweenLerps));
    }

    IEnumerator LTR(TrailRenderer aTrail, Color colorToLerpTo, int iterations, float timeBetweenLerps)
    {
        //store the image's current color
        Color currentColor = aTrail.startColor;

        //calculate the differences between the current color and the color you want to lerp to 
        float rDiff = (currentColor.r - colorToLerpTo.r) / (float)iterations;
        float gDiff = (currentColor.g - colorToLerpTo.g) / (float)iterations;
        float bDiff = (currentColor.b - colorToLerpTo.b) / (float)iterations;
        float aDiff = (currentColor.a - colorToLerpTo.a) / (float)iterations;

        //lerp the color over the amount of iterations
        for (int i = 0; i < iterations; i++)
        {
            Color newColor = new Color(aTrail.startColor.r - rDiff, aTrail.startColor.g - gDiff, aTrail.startColor.b - bDiff, aTrail.startColor.a - aDiff);
            aTrail.startColor = newColor;
            aTrail.endColor = newColor;
            yield return new WaitForSeconds(timeBetweenLerps);
        }
    }

    public void LerpMaterial(MeshRenderer aMesh, Color colorToLerpTo, int iterations, float timeBetweenLerps)
    {
        StartCoroutine(LMR(aMesh, colorToLerpTo, iterations, timeBetweenLerps));
    }

    IEnumerator LMR(MeshRenderer aMesh, Color colorToLerpTo, int iterations, float timeBetweenLerps)
    {
        //store the image's current color
        Color currentColor = aMesh.material.color;

        //calculate the differences between the current color and the color you want to lerp to 
        float rDiff = (currentColor.r - colorToLerpTo.r) / (float)iterations;
        float gDiff = (currentColor.g - colorToLerpTo.g) / (float)iterations;
        float bDiff = (currentColor.b - colorToLerpTo.b) / (float)iterations;
        float aDiff = (currentColor.a - colorToLerpTo.a) / (float)iterations;

        //lerp the color over the amount of iterations
        for (int i = 0; i < iterations; i++)
        {
            Color newColor = new Color(aMesh.material.color.r - rDiff, aMesh.material.color.g - gDiff, aMesh.material.color.b - bDiff, aMesh.material.color.a - aDiff);
            aMesh.material.color = newColor;
            yield return new WaitForSeconds(timeBetweenLerps);
        }
    }


    #endregion
    // COLOR EFFECTS ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    #region
    public void FlashWhite(SpriteRenderer aSprite)
    {
        StartCoroutine(FWS(aSprite));
    }

    IEnumerator FWS(SpriteRenderer aSprite)
    {
        int iterations = 15;
        float timeBetweenLerps = .001f;

        //LERP TO WHITE
        //store the image's current color
        Color currentColor = aSprite.color;

        //calculate the differences between the current color and the color you want to lerp to 
        float rDiff = (currentColor.r - Color.white.r) / (float)iterations;
        float gDiff = (currentColor.g - Color.white.g) / (float)iterations;
        float bDiff = (currentColor.b - Color.white.b) / (float)iterations;
        float aDiff = (currentColor.a - .65f) / (float)iterations;

        //lerp the color over the amount of iterations
        for (int i = 0; i < iterations; i++)
        {
            Color newColor = new Color(aSprite.color.r - rDiff, aSprite.color.g - gDiff, aSprite.color.b - bDiff, aSprite.color.a - aDiff);
            aSprite.color = newColor;
            yield return new WaitForSeconds(timeBetweenLerps);
        }

        //store the image's current color
        currentColor = aSprite.color;

        //calculate the differences between the current color and the color you want to lerp to 
        aDiff = (currentColor.a) / (float)iterations;

        //lerp the color over the amount of iterations
        for (int i = 0; i < iterations; i++)
        {
            Color newColor = new Color(aSprite.color.r, aSprite.color.g, aSprite.color.b, aSprite.color.a - aDiff);
            aSprite.color = newColor;
            yield return new WaitForSeconds(timeBetweenLerps);
        }
    }


    #endregion

    #endregion

    //custom functions
    #region



    #endregion
}
