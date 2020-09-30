using System;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public ScoreBuilder scoreBuilder;
    public List<GameObject> highDigits;
    public List<GameObject> lastDigits;

    private void Start()
    {
        int highScore = PlayerPrefs.GetInt("highScore");
        highDigits = scoreBuilder.Build(highScore, GetPosition(highScore, 3f));
        
        int lastScore = PlayerPrefs.GetInt("lastScore");
        lastDigits = scoreBuilder.Build(lastScore, GetPosition(lastScore, 4.5f));
    }

    private void OnDestroy()
    {
        foreach (GameObject digit in highDigits) Destroy(digit);
        foreach (GameObject digit in lastDigits) Destroy(digit);
    }

    private Vector2 GetPosition(int score, float y)
    {
        float x = 0;
        int len = (int) Math.Floor(Math.Log10(score) + 1);
        if (len < 0) len = 0;
        if (len % 2 == 0 && len != 0)
        {
            x += 0.25f + 0.5f * (len / 2 - 1);
        }
        else
        {
            x += 0.5f * (len / 2);
        }
        return new Vector2(2f + x, y);
    }
}
