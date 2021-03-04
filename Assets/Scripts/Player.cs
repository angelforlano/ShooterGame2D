using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int hp = 100;
    public int energy = 75;
    public int ammo = 30;
    public float fireRate = 1;
    public float speed = 4.5f;
    public Animator animator;
    public SpriteRenderer renderer;

    public GameObject bulletPrefab;
    public Transform shootSpawn;

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

        HUDController.Instance.player = this;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isRunning", false);
        
        if(HUDController.Instance.pause) return;

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

        // Disparar con enter y config animacion...
        if(Input.GetKey(KeyCode.Return))
        {
            animator.SetBool("isShooting", true);
        } else {
            animator.SetBool("isShooting", false);
        }

        if(Input.GetKey(KeyCode.Return) && ammo > 0 && Time.time > nextFire)
        {
            ammo--;
            nextFire = Time.time + fireRate;

            var bullet = Instantiate(bulletPrefab, shootSpawn.position, Quaternion.identity);

            if(renderer.flipX == true)
            {
                bullet.transform.Rotate(new Vector3(0, 0, 180));
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ammo"))
        {
            ammo += 45;
            Destroy(other.gameObject);
        }
    }
}