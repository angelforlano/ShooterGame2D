﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int hp = 100;
    public int energy = 75;
    public int ammo = 30;
    public int plants;
    
    [Range(10, 40)]
    public float jumpForce = 20;

    public float fireRate = 1;
    public float speed = 4.5f;
    public Animator animator;
    public SpriteRenderer renderer;
    public Rigidbody2D rb;

    public GameObject bulletPrefab;
    
    public Transform shootSpawn1;
    public Transform shootSpawn2;

    float nextFire;

    int startHp;
    int startEnergy;

    public float hpPercet
    {
        get { return (float) hp / startHp;}
    }

    public float energyPercet
    {
        get { return (float) energy / startEnergy;}
    }

    void Start()
    {
        startHp = hp;
        startEnergy = energy;

        HUDController.Instance.SetPlayer(this);
    }

    void Update()
    {
        animator.SetBool("isRunning", false);

        if(GameController.Instance.Pause) return;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            renderer.flipX = false;
            animator.SetBool("isRunning", true);
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime *-1, 0, 0));
            renderer.flipX = true;
            animator.SetBool("isRunning", true);
        }

        if(Input.GetKey(KeyCode.Return) && ammo > 0)
        {
            animator.SetBool("isShooting", true);
        } else {
            animator.SetBool("isShooting", false);
        }

        if(Input.GetKey(KeyCode.Return) && ammo > 0 && Time.time > nextFire)
        {
            ammo--;
            nextFire = Time.time + fireRate;
            
            if(renderer.flipX == true)
            {
                var bullet = Instantiate(bulletPrefab, shootSpawn2.position, Quaternion.identity);
                bullet.transform.Rotate(new Vector3(0, 0, 180));
            } else {
                Instantiate(bulletPrefab, shootSpawn1.position, Quaternion.identity);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Plant"))
        {
            plants++;
            Destroy(other.gameObject);
            GameController.Instance.PlantaAdded(plants);
        }

        if (other.gameObject.CompareTag("Ammo"))
        {
            ammo += 45;
            Destroy(other.gameObject);
        }
    }

    void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        animator.SetTrigger("jump");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        animator.SetTrigger("jumpGround");
    }
}