using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public ScoreBuilder scoreBuilder;
    public List<GameObject> digits;
    private static int score;

    private static bool isUpdateNeeded;

    private void Start()
    {
        score = 0;
        isUpdateNeeded = true;
    }

    private void Update()
    {
        if (isUpdateNeeded)
        {
            foreach (GameObject digit in digits) Destroy(digit);
            digits = scoreBuilder.Build(score, new Vector2(3.8f, 7.8f));
            isUpdateNeeded = false;
        }
    }

    public static void UpdateScore()
    {
        score++;
        isUpdateNeeded = true;
    }

    private void OnDestroy()
    {
        int highScore = PlayerPrefs.GetInt("highScore");
        if (score > highScore)
            PlayerPrefs.SetInt("highScore", score);
        PlayerPrefs.SetInt("lastScore", score);
        foreach (GameObject digit in digits) Destroy(digit);
    }

}
