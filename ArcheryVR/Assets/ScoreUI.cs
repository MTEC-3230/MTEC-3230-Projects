using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class ScoreUI : MonoBehaviour
{

    public TextMeshProUGUI scoreText; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ScoreManager.Instance.score);
        scoreText.text = "Score : " + ScoreManager.Instance.score.ToString(); 
    }
}
