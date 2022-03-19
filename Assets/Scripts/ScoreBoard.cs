using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    int score;
    public void ScoreCount(int ScoreToIncrease)
    {
        score += ScoreToIncrease;
        Debug.Log($"Score is : {score}");
    }
}
