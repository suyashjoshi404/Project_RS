using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    TMP_Text scoreDisplay;
    int score;

    void Start() 
    {
        scoreDisplay = GetComponent<TMP_Text>();
        scoreDisplay.text = "Start";
    }

    public void ScoreCount(int ScoreToIncrease)
    {
        score += ScoreToIncrease;
        scoreDisplay.text = score.ToString();
    }
}
