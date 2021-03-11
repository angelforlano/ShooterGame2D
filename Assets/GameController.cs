using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public int timeToWin = 180;

    public UnityEvent onGameEndEvent;
    public UnityEvent onPlant1Event;
    public static GameController Instance;

    void Awake()
    {
        GameController.Instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Timer()
    {
        Debug.Log("Game Start");

        while (timeToWin > 0)
        {
            timeToWin -= 1;
            yield return new WaitForSeconds(1);
            Debug.Log("Time To Win > " + timeToWin);
        }

        Debug.Log("Game End");
        onGameEndEvent.Invoke();
    }

    public void PlantaAdded(int playerPlants)
    {
        if (playerPlants >= 3)
        {
            onPlant1Event.Invoke();
        }
    }
}
