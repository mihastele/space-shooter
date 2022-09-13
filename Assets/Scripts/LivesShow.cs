using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesShow : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI livesText;
    // Start is called before the first frame update
    void Awake()
    {
        RefreshLives();
    }

    void Update()
    {
        RefreshLives();
    }

    public void RefreshLives()
    {
        livesText.text = $"Lives Left:\n{LevelManager.lives.ToString()}";
    }
}
