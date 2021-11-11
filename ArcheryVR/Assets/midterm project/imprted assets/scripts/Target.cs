using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    //public ScoreManager scoreManager; 
    public int points = 10; 
    public void AddScore()
    {
        Debug.Log("Adding points " + points);
        ScoreManager.Instance.AddScore(points);
        Destroy(gameObject);

    }
}
