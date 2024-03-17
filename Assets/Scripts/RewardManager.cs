using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    public GameObject admob;
    AdmobAdsScript admobAdsScript;
    public int adInterval = 0;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.GetInt("adInterval", 0);
        adInterval = 0;
        admobAdsScript = admob.GetComponent<AdmobAdsScript>();
        admobAdsScript.LoadRewardedAd();
        admobAdsScript.LoadInterstitialAd();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickAdInterval()
    {
        adInterval++;
        if(adInterval==6)
        {
            
            admobAdsScript.ShowInterstitialAd();
            admobAdsScript.LoadInterstitialAd(); 
            adInterval = 0;
        }
    }
}
