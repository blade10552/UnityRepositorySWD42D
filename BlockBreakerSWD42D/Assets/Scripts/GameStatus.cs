using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [SerializeField] int currentScore = 0;
    [SerializeField] int pointsPerBlockDestroyed = 10;

    [SerializeField] TextMeshProUGUI scoreText;

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
