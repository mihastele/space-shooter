using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 2f;
    [SerializeField] public static int lives = 1;


    public void LoadGame()
    {

        // Debug.Log(scoreKeeper);
        // if (scoreKeeper)
        // {
        // Debug.Log(ScoreKeeper.GetInstance());
        // ScoreKeeper.GetInstance().ResetScore();
        // }
        // string reference to the scene object (Via the Name)
        // SceneManager.LoadScene("Game");

        ScoreKeeper.GetInstance().ResetScore();
        SceneManager.LoadScene("Game");

    }

    public void ShowAd()
    {
        AdManager.Instance.ShowAd();
    }

    public void LoadAdScreen()
    {
        SceneManager.LoadScene("LivesScreen");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameOver()
    {
        LevelManager.lives -= 1;
        StartCoroutine(WaitAndLoad("GameOver", sceneLoadDelay));
    }

    public void QuitGame()
    {
        Debug.Log("Quitted");
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
