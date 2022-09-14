using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameStat : MonoBehaviour
{
    [SerializeField] private GameObject player;


    public void Start()
    {
        UpdateStat();
    }

    public void UpdateStat()
    {
        Debug.Log("Hello world");
        if (player.tag.Equals("Player"))
        {
            GetComponent<TextMeshProUGUI>().text = "Score " + player.GetComponent<PlayerController>().Point.ToString() + Environment.NewLine
                                                   + "Health: " + player.GetComponent<PlayerController>().Health.ToString();
        }
        else
        {
            GetComponent<TextMeshProUGUI>().text =
                "Enemy Score " + player.GetComponent<PlayerController>().Point.ToString();
        }

        
        // GetComponent<TextMeshPro>().text = "Score " + player.GetComponent<PlayerController>().Point.ToString() + "/n"
        // + "Health: " + player.GetComponent<PlayerController>().Health.ToString();
    }

}
