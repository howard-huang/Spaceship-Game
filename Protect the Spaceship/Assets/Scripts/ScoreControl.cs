using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour
{
    public int Score;

    private Text ScoreText;

    private void Start()
    {
        ScoreText = GetComponent<Text>();
    }

    public void IncreaseScore(int points)
    {
        Score += points;
        ScoreText.text = Score.ToString();
    }

    public void ResetScore()
    {
        Score = 0;
        ScoreText.text = Score.ToString();
    }
}
