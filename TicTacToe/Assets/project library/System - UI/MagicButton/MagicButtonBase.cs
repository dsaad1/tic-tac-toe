using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using FIMSpace;

public class MagicButtonBase : MonoBehaviour
{
    [Header("GENERAL")]
    [SerializeField] protected Button button;
    [SerializeField] protected Text text;
    [SerializeField] protected TextMeshProUGUI tmproText;
    [SerializeField] protected Image image;
    [SerializeField] protected Image imageLower;


    [Header("COLORS")]
    [SerializeField] protected MagicButtonColors colors;

    [Header("ANIMATION")]
    public MagicButtonAnimations animations;


  
    protected void OnPress()
    {
        animations.OnPress();
    }

    //TryToColor() - checks if an obj is null, then colors it
    #region
    protected void TryToColor(string type)
    {
        if (type == "enable")
        {
            TryToColor(imageLower, colors.GetEnabledColor("image lower"));
            TryToColor(image, colors.GetEnabledColor("image"));
            TryToColor(text, colors.GetEnabledColor("text"));
            TryToColor(tmproText, colors.GetEnabledColor("text"));
        }
        else
        {
            TryToColor(imageLower, colors.GetDisabledColors("image lower"));
            TryToColor(image, colors.GetDisabledColors("image"));
            TryToColor(text, colors.GetDisabledColors("text"));
            TryToColor(tmproText, colors.GetDisabledColors("text"));
        }
      
    }
    void TryToColor(Image anImage, Color aColor)
    {
        if (anImage != null)
        {
            anImage.color = aColor;
        }
    }
    void TryToColor(Text aText, Color aColor)
    {
        if (aText != null)
        {
            aText.color = aColor;
        }
    }
    void TryToColor(TextMeshProUGUI aText, Color aColor)
    {
        if (aText != null)
        {
            aText.color = aColor;
        }
    }
    #endregion

}
