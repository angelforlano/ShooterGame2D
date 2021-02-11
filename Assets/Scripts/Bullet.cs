using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;
    public float speed = 12;
    public AudioSource audioSource;

    void Awake()
    {
        audioSource.volume = audioSource.volume + Random.Range(-0.5f, 0.5f);
        audioSource.pitch = audioSource.pitch + Random.Range(-0.075f, 0.075f);
    }

    void Update()
    {
        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
    }
}