using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject ballController;
    [SerializeField] private float speed;
    private Rigidbody rb;
    private GameObject currentTarget;
    private Vector3 lastPositon;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastPositon = rb.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTarget.IsDestroyed()) currentTarget = null;
        FindTarget();
        MoveToTarget();
    }

    void FindTarget()
    {
        List<GameObject> ballList = ballController.GetComponent<BallSpawner>().ballList;
        Color currentColor = GetComponent<Renderer>().material.color;
        for (int i = 0; i < ballList.Count; i++)
        {
            if (ballList[i].GetComponent<Renderer>().material.color == currentColor)
            {
                currentTarget = ballList[i];
                break;
            }
        }
        
    }
    void MoveToTarget()
    {
        if (currentTarget != null && !currentTarget.IsDestroyed())
        {
            Vector3 vector = currentTarget.transform.position - rb.position;
            lastPositon = transform.position;
            rb.MovePosition(vector * speed / 1000f + rb.position);
            if (Vector3.Magnitude(rb.position - lastPositon) <= 0.01f)
            {
                rb.AddRelativeForce(Vector3.up * 20);
            } 
        }
        
    }
    
    
}
