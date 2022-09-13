using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

// 4.3.0
public class AdManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
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
    [SerializeField] string placementId = "rwd";



    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        Advertisement.Load(placementId, this);
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    public void ShowAd()
    {
        Advertisement.Show(placementId, this);
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
            Advertisement.Initialize(gameId, testMode, this);
        }
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log($"Unity Ads Loaded: ${placementId}");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Unity Ad Load Failed: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Unity Ad Show Failed: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log($"Unity Ads Show Started: ${placementId}");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {

        int randomNumber = Random.Range(0, 20);

        Debug.Log(placementId);
        Debug.Log(showCompletionState);


        switch (showCompletionState)
        {
            case UnityAdsShowCompletionState.COMPLETED:
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
            case UnityAdsShowCompletionState.SKIPPED:
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
            case UnityAdsShowCompletionState.UNKNOWN:
                Debug.Log("AD FAILED");
                break;

        }

        Advertisement.Load(placementId, this);
    }

    /*
        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            ((IUnityAdsInitializationListener)Instance).OnInitializationFailed(error, message);
        }
        */
}
