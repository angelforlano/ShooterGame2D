using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDController : MonoBehaviour
{
    public Image playerHpImage;
    public Image playerEnergyImage;
    public TextMeshProUGUI ammoText;

    public GameObject pausePanel;

    public Player player;
    
    // Singleton!
    public static HUDController Instance;
    
    public bool pause;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            pause = !pause;
            pausePanel.SetActive(pause);
        }

        playerHpImage.fillAmount = player.hpPercet;
        playerEnergyImage.fillAmount = player.energyPercet;

        ammoText.text = player.ammo.ToString();

        if(player.ammo > 0)
        {
            ammoText.color = Color.white;
        } else {
            ammoText.color = Color.red;
        }
    }
}
