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

    void Awake()
    {
        GameController.Instance = this;
    }
    
    void Start()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        Debug.Log("Game Start");

        while (timeToWin > 0)
        {
            timeToWin -= 1;
            yield return new WaitForSeconds(1);
        }

        Debug.Log("Game End");
        onGameEndEvent.Invoke();
    }

    public void PlantaAdded(int playerPlants)
    {
        if (playerPlants >= 3)
        {
            onPlant1Event.Invoke();

            SceneManager.LoadScene("Level_" + currentLevel+1);
        }
    }
}
