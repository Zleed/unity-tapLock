using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GoogleMobileAds.Api;
using System;

public class GoogleMobileAdsScript : MonoBehaviour
{
    static string App_ID = "ca-app-pub-3355636666331917~9591703111";
    static string Interstitial_AD_ID = "ca-app-pub-3940256099942544/1033173712";
    static string Banner_AD_ID = "ca-app-pub-3940256099942544/6300978111";

    private static InterstitialAd interstitial;
    private static BannerView bannerView;

    public void Start()
    {
        MobileAds.Initialize(App_ID);
        RequestInterstitial();
        RequestBanner();
    }

    public static void RequestInterstitial()
    {
        interstitial = new InterstitialAd(Interstitial_AD_ID);

        // Called when an ad request has successfully loaded.
        interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        AdRequest request = new AdRequest.Builder().Build();
        interstitial.LoadAd(request);
    }

    private static void RequestBanner()
    {
        bannerView = new BannerView(Banner_AD_ID, AdSize.Banner, AdPosition.Bottom);
    }

    public static void ShowBannerAd()
    {
        AdRequest request = new AdRequest.Builder().Build();
        bannerView.LoadAd(request);
        bannerView.Show();
    }

    public static void HideBannerAd()
    {
        bannerView.Hide();
    }

    public static void ShowInterstitial()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }

    public static void HandleOnAdLoaded(object sender, EventArgs args)
    {
        Debug.Log("LOADED");
    }

    public static void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log("FAILED_TO_LOAD");
    }

    public static void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public static void HandleOnAdClosed(object sender, EventArgs args)
    {
        RequestInterstitial();
    }

    public static void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }
}
