using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int hp = 3;
    public Image hpImage;

    int startHp;

    private void Start()
    {
        startHp = hp;
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
}