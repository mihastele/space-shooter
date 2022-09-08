using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;



    void Start()
    {
        scoreText.text = "You Scored:\n" + ScoreKeeper.GetInstance().GetScore();
    }


}
