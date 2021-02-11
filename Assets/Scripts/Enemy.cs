using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 3;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
    }
}