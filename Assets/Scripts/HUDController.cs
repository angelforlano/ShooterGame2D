using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public Player player;
    public Image playerHpImage;
    
    // Singleton!
    public static HUDController Instance;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        playerHpImage.fillAmount = (float) player.hp / 100;
    }
}
