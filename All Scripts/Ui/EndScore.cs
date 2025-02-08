using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScore : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;
    ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score = scoreManager.score;
        scoreText.text = "Score: " + score;
    }
}
