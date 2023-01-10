using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreControl : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    static public int score;
    private void Update()
    {
        scoreText.text = " " + score;
    }
    static public void SetScore(int points)
    {
        score += points;
        if (score<0)
        {
            score = 0;
        }
    }
}
