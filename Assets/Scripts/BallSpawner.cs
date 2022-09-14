using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallSpawner : MonoBehaviour
{
    [Tooltip("Ball prefab")][SerializeField] private GameObject ballPrefab;
    
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minZ;
    [SerializeField] private float maxZ;
    [SerializeField] private float spawnTime;
    public List<GameObject> ballList;
    public float SpawnTime
    {
        get { return spawnTime; }
        set { spawnTime = value; }
    }
    public void Awake()
    {
        ballList = new List<GameObject>();
        CreateBall(Color.red);
        CreateBall(Color.blue);
        CreateBall(Color.green);
    }

    private void Update()
    {
        Debug.Log("Number of balls " + ballList.Count);
    }

    public GameObject CreateBall(Color color)
    {
        int posX = Mathf.FloorToInt(Random.Range(minX, maxX));
        int posY = 40;
        int posZ = Mathf.FloorToInt(Random.Range(minZ, maxZ));
        GameObject ball = Instantiate(ballPrefab, new Vector3(posX, posY, posZ), Quaternion.identity);
        ball.GetComponent<Renderer>().material.color = color;
        ball.GetComponent<BallController>().Color = color;

        ballList.Add(ball);
        Debug.Log(ballList);
        return ball;
    }

    public void RemoveBall(GameObject ball)
    {
        if (ballList.Contains(ball))
            ballList.Remove(ball);
    }
    
}
