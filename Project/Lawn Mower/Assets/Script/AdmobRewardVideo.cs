using UnityEngine.Events;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine.UI;
using UnityEngine.Analytics;
using System;
using System.Collections.Generic;

public class AdmobRewardVideo : MonoBehaviour
{
	
    private RewardedAd rewardedAd;
	private GameManager gm;
	private InGameUI gameUI;
	public Text logtext;
	
	
	bool isAdClosed = false;
	bool isRewarded = false;	
	public void Update(){
		if (isAdClosed)
    {
        if (isRewarded)
        {
            // do all the actions
            // reward the player
			logtext.text = "REWARDED";
			gm.SpawnPowerReward();
            isRewarded = false;
        }
        else
        {
            // Ad closed but user skipped ads, so no reward 
           // Ad your action here 
        }
        isAdClosed = false;  // to make sure this action will happen only once.
    }
	}
	
    public void Start()
    {
		gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
		gameUI = GameObject.FindGameObjectWithTag("GameManager").GetComponent<InGameUI>();
         string adUnitId;
        #if UNITY_ANDROID
            adUnitId = "ca-app-pub-3940256099942544/5224354917";
        #elif UNITY_IPHONE
            adUnitId = "ca-app-pub-3940256099942544/1712485313";
        #else
            adUnitId = "unexpected_platform";
        #endif

        this.rewardedAd = new RewardedAd(adUnitId);

        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;
		// Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
        
    }
	public  void ShowAd(){
		Analytics.CustomEvent("Accept Reward Ad");
		 if (rewardedAd.IsLoaded()) {
				rewardedAd.Show();
				gameUI.Resume();
			}
	}
	public void LoadAd(){
		string adUnitId;
		#if UNITY_ANDROID
            adUnitId = "ca-app-pub-3940256099942544/5224354917";
        #elif UNITY_IPHONE
            adUnitId = "ca-app-pub-3940256099942544/1712485313";
        #else
            adUnitId = "unexpected_platform";
        #endif

        this.rewardedAd = new RewardedAd(adUnitId);
		// Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
	}
    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
		//logtext.text = "HandleRewardedAdLoaded event received";
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);
							 
							// logtext.text =  "HandleRewardedAdFailedToLoad event received with message: ";
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
		 //logtext.text =  "HandleRewardedAdOpening event received";
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
							 
							// logtext.text =  "HandleRewardedAdFailedToShow event received with message: ";
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
		//logtext.text =  "HandleRewardedAdClosed event received";
		isAdClosed = true;
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);
						isRewarded = true;
    }
}