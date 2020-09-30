using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject start;
    public GameObject highScore;
    public GameObject HighScoreLabel;
    public GameObject LastScoreLabel;
    public GameObject logo;

    public ScoreBuilder scoreBuilder;

    void Start()
    {
        GoogleMobileAdsScript.ShowBannerAd();
        highScore = Instantiate(highScore);
        HighScoreLabel = Instantiate(HighScoreLabel);
        LastScoreLabel = Instantiate(LastScoreLabel);
        logo = Instantiate(logo);
        start = Instantiate(start);
        start.GetComponent<StartGame>().menu = gameObject;
    }

    private void OnDestroy()
    {
        DestroyImmediate(start);
        DestroyImmediate(logo);
        DestroyImmediate(highScore);
        DestroyImmediate(HighScoreLabel);
        DestroyImmediate(LastScoreLabel);
    }
}
