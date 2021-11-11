using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    public int score = 0; 

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("The score is " + score);

    }
}
