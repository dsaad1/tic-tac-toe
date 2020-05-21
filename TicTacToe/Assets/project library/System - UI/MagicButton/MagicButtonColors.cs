using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicButtonColors : MonoBehaviour
{
    public MagicButtonColorPalette colors;

    public Color GetEnabledColor(string type)
    {
        switch (type)
        {
            case "image lower":
                return colors.enabledColors[0];
            case "image":
                return colors.enabledColors[1];
            case "text":
                return colors.enabledColors[2];
        }
        Debug.Log("magic button does not have an enabled color set up for: " + type);
        return Color.clear;
    }

    public Color GetDisabledColors(string type)
    {
        switch (type)
        {
            case "image lower":
                return colors.disabledColors[0];
            case "image":
                return colors.disabledColors[1];
            case "text":
                return colors.disabledColors[2];
        }
        Debug.Log("magic button does not have an enabled color set up for: " + type);
        return Color.clear;
    }


}
