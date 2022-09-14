using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private Rigidbody rb;

    [Tooltip("Toc do di chuyen nguoi choi")] [SerializeField] private float speedControl;

    private float sideOffset;
    private float fowardOffset;
    private Vector3 currentPos;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        sideOffset = Input.GetAxis("Horizontal") * Time.deltaTime * speedControl;
        fowardOffset = Input.GetAxis("Vertical") * Time.deltaTime * speedControl;
        // ProcessMove();  
    }

    private void FixedUpdate()
    {
        ProcessMove();
    }

    public void ProcessMove()
    {
        
        
        // Debug.Log(sideOffset + " " + fowardOffset);
        
        currentPos = rb.position;
        rb.MovePosition(new Vector3(currentPos.x + sideOffset, currentPos.y, currentPos.z + fowardOffset));
    }
}
