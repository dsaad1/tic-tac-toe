using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTools : MonoBehaviour
{
    public Color selectedColor;
    [SerializeField] Image button;
    [SerializeField] Image otherButton;

    public void OnSelect()
    {
        button.color = selectedColor;
        otherButton.color = Color.white;
    }
}
