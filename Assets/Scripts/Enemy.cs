using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int hp = 3;
    public Image hpImage;

    int startHp;
    bool direction;

    void Start()
    {
        startHp = hp;

        StartCoroutine(Move());
    }

    void Update()
    {
        if (direction)
        {
            transform.Translate(new Vector3(4 * Time.deltaTime, 0, 0));
        } else {
            transform.Translate(new Vector3(-4 * Time.deltaTime, 0, 0));
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            hp--;
            hpImage.fillAmount = (float) hp / startHp;
            
            if (hp <= 0)
            {
               Destroy(gameObject); 
            }
        }
    }

    IEnumerator Move()
    {
        while (true)
        {
            direction = true;
            yield return new WaitForSeconds(1f);
            direction = false;
            yield return new WaitForSeconds(1f);
        }
    }
}