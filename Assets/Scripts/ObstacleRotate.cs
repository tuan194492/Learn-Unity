using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotate : MonoBehaviour
{
    [SerializeField] private float speedControl;
    void Update()
    {
        float y = Mathf.Sin(Time.time / speedControl * 2 * (float) Math.PI);
        Quaternion quaternion = transform.localRotation;
        transform.Rotate(new Vector3(0, y, 0));
    }
}
