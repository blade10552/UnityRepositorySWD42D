using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [SerializeField] int currentScore = 0;
    [SerializeField] int pointsPerBlockDestroyed = 10;

    [SerializeField] TextMeshProUGUI scoreText;

    /* Awake() is a built-in method and it is the first method executed for the 
     * current object.
     * In this method we are going to check that there is only ONE instance of 
     * GameStatus and we need to ensure that this object is not destroyed when 
     * loading new levels
     */ 
    void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        // fetching the amount of GameStatus' which are currently in our hierarchy

        if (gameStatusCount > 1)
        {
            //any other gameStatus apart from the first one, will be destroyed 
            Destroy(gameObject); // Destroy the last one which has been created
        }
        else
        {   /* The compiler will enter this else statment in the first Level, when
             * we don't have any other GameStatus (just one).
             * Since this is the first GameStatus we don't want it to be destroyed
             */
            DontDestroyOnLoad(gameObject);
            //gameObject keyword refers to the whole game object which contains this
            //script. In this case the game object is the GameStatus
        }
    
    }

    void Start()
    {
        scoreText = FindObjectOfType<TextMeshProUGUI>();
        scoreText.text = currentScore.ToString();
    }
    
    //This method needs to be called whenever a block is destroyed
    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        //currentScore = currentScore + pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }
}
