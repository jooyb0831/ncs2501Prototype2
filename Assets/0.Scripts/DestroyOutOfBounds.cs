using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverAction : UnityEngine.Events.UnityEvent{}

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -10f;

    //private SpawnManager sm;

    public delegate void GameOverHandler();
    public static event GameOverHandler OnGameOver;

    //public static GameOverAction OnGameOver = new GameOverAction();
    // Start is called before the first frame update
    void Start()
    {
        //sm = GameObject.FindGameObjectWithTag("GameController").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            //sm.DisplayGameOver();
            OnGameOver();
            //OnGameOver.Invoke();
            Destroy(gameObject);
        }
    }
}
