using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener, IUnityAdsInitializationListener
{
    public static AdManager Instance;

    [SerializeField] bool testMode = true;

    /*
    #if UNITY_ANDROID
        private string gameId = "4925677";
        // #elif UNITY_IOS // TODO ADD if you have IOS
        //     private string gameId = "4925676";
    #else
        private string gameId = "4925677";
    #endif
    */

    //hack below for now
    [SerializeField] string gameId = 4925677.ToString();


    public void OnUnityAdsDidError(string message)
    {
        Debug.Log($"Unity Ads Error: ${message}");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        int randomNumber = Random.Range(0, 20);

        Debug.Log(placementId);
        Debug.Log(showResult);


        switch (showResult)
        {
            case ShowResult.Finished:
                if (randomNumber < 11)
                {
                    LevelManager.lives += 3;
                }
                else if (randomNumber < 17)
                {
                    LevelManager.lives += 4;
                }
                else
                {
                    LevelManager.lives += 5;
                }
                break;
            case ShowResult.Skipped:
                if (randomNumber < 2)
                {
                    LevelManager.lives += 0;
                }
                else if (randomNumber < 16)
                {
                    LevelManager.lives += 1;
                }
                else
                {
                    LevelManager.lives += 2;
                }
                break;
            case ShowResult.Failed:
                Debug.Log("AD FAILED");
                break;

        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log($"Unity Ads Started: ${placementId}");
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log($"Unity Ads Ready: ${placementId}");
    }


    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    public void ShowAd()
    {
        Advertisement.Show("rwd");
    }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // 4925677 ANDROID, 4925676 iOS

            // Debug.Log("INITIALIZE FOR :::::::::::::::::::");
            Advertisement.Initialize(gameId, testMode);
            Advertisement.AddListener(this);
        }
    }

    /*
        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            ((IUnityAdsInitializationListener)Instance).OnInitializationFailed(error, message);
        }
        */
}
