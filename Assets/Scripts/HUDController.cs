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
    public TextMeshProUGUI timerText;

    public GameObject pausePanel;
    public GameObject gameOverPanel;

    // Singleton!
    public static HUDController Instance;
    
    // Privates!
    Player player;

    public bool Pause
    {
        get {return pause;}
    }

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        timerText.text = GameController.Instance.timeToWin.ToString();
        
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

    public void SetPlayer(Player _player)
    {
        player = _player;
    }

    public void SetGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
    
    public void SetPausePanel(bool pauseValue)
    {
        pausePanel.SetActive(pauseValue);
    }

    public void RetryBtn()
    {
        GameController.Instance.ReStartGame();
    }

    public void MainMenuBtn()
    {
        GameController.Instance.GoMainMenu();
    }

    public void QuitBtn()
    {
        Application.Quit();
    }
}
