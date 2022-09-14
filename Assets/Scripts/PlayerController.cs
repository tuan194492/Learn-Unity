using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private int point;
    [SerializeField] private GameObject ingameStatDisplay;
    [SerializeField] private GameObject gameController;
    public int Point
    {
        get { return point; }
    }

    public int Health
    {
        get { return hp; }
    }
    private Color[] colorList = { Color.red, Color.blue, Color.green };

    private void Start()
    {
        ChangeRandomColor();
    }

    public void ChangeColor(Color color)
    {
        GetComponent<Renderer>().material.color = color;
    }

    public void ChangeHealth(int delta)
    {
        hp = hp + delta;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ball"))
        {
            Color ballColor = collision.gameObject.GetComponent<Renderer>().material.color;
            if (GetComponent<Renderer>().material.color == ballColor)
            {
                point++;
            }
            else
            {
                ChangeHealth(-1);
            }
            ChangeRandomColor();
            Debug.Log("Current hp " + hp);
            Debug.Log("Current point " + point);
            
            ingameStatDisplay.GetComponent<InGameStat>().UpdateStat();
            CheckEndGame();
        }
    }

    public void ChangeRandomColor()
    {
        int colorIndex = Random.Range(0, 3);
        Color randomColor = colorList[colorIndex];
        GetComponent<Renderer>().material.color = randomColor;
    }

    public void CheckEndGame()
    {
        if (hp <= 0)
        {
            gameController.GetComponent<MainMenu>().ShowEndGameMenu(false);
        }
        else if (point >= 10)
        {
            gameController.GetComponent<MainMenu>().ShowEndGameMenu(true);
        }
    }
}
