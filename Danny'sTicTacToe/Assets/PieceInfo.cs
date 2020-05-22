using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class PieceInfo : MonoBehaviour
{
    private int x;
    private int y;
    private bool filled;
    private string player;
    [SerializeField] Image icon;

    public void Initialize(int x1, int y1)
    {
        x = x1;
        y = y1;
        filled = false;
        player = "";
        icon.gameObject.SetActive(false);
        BoardManager.self.availablePieces.Add(this);
    }

    public void assignSquare(string player1, Sprite icon1)
    {
        player = player1;

        icon.sprite = icon1;
        if (icon.sprite.name == "x")
        {
            icon.GetComponent<RectTransform>().sizeDelta = new Vector2(350,350);
        }
        else
        {
            icon.GetComponent<RectTransform>().sizeDelta = new Vector2(150, 150);
        }
        icon.gameObject.SetActive(true);

        filled = true;
        GetComponent<Button>().interactable = false;
        BoardManager.self.availablePieces.Remove(this);
        BoardManager.self.CheckBoard();

    }

    public void assignSquare()
    {
        if (BoardManager.self.PlayerCanGo)
        {
            assignSquare("player", Player.self.icon);
            BoardManager.self.AITurn();
        }


    }















}

