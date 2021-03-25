using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int currentLevel = 1;
    public int timeToWin = 180;

    public UnityEvent onGameEndEvent;
    public UnityEvent onPlant1Event;
    public static GameController Instance;

    bool pause;

    public bool Pause
    {
        get {return pause;}
    }

    void Awake()
    {
        if (GameController.Instance == null)
        {
           GameController.Instance = this; 
        } else {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        StartCoroutine(Timer());
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            pause = !pause;
            HUDController.Instance.SetPausePanel(pause);
        }
    }

    IEnumerator Timer()
    {
        Debug.Log("Game Start");

        while (timeToWin > 1 && !pause)
        {
            timeToWin -= 1;
            yield return new WaitForSeconds(1);
        }

        Debug.Log("Game End");
        GameOver();
    }

    void GameOver()
    {
        timeToWin = 0;
        onGameEndEvent.Invoke();
        HUDController.Instance.SetGameOverPanel();
    }

    public void PlantaAdded(int playerPlants)
    {
        if (playerPlants >= 3)
        {
            onPlant1Event.Invoke();

            SceneManager.LoadScene("Level_" + currentLevel+1);
        }
    }

    public void ReStartGame()
    {
        SceneManager.LoadScene("Level_" + currentLevel);
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
