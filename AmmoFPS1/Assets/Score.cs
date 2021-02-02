using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int CurrentScore;
    public int HighScore;
    void Start()
    {

        CurrentScore = 0;
        
    }

    public void AddScore(int scoreToAdd)
    {
        CurrentScore += scoreToAdd;
    }
}
