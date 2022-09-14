using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    private Color[] colorList = { Color.red, Color.blue, Color.green };
    
    public Color generateColor;

    private GameObject parent;

    public void Awake()
    {
        parent = GetComponent<BallController>().Parent;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player") || collision.gameObject.tag.Equals("Enemy"))
        {
            generateColor = GetComponent<Renderer>().material.color;
            gameObject.SetActive(false);
            // CreateNewBall();
            Invoke("CreateNewBall", 1f);
        }
    }

    private void CreateNewBall()
    {
        parent.GetComponent<BallSpawner>().RemoveBall(gameObject);
        parent.GetComponent<BallSpawner>().CreateBall(generateColor);
        Destroy(gameObject);
    }
    
    
}
