using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public Image playerHpImage;
    public Image playerEnergyImage;

    public Player player;
    
    // Singleton!
    public static HUDController Instance;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        playerHpImage.fillAmount = player.hpPercet;
        playerEnergyImage.fillAmount = player.energyPercet;
    }
}
