using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Kiem soat cac thuoc tinh cua qua bong
 * Luu lai Danh sach tat ca qua bong
 */
public class BallController : MonoBehaviour
{
    [SerializeField] private GameObject parent;

    private Color color;

    public Color Color
    {
        get => color;
        set => color = value;
    }

    public GameObject Parent
    {
        get => parent;
    }
}
