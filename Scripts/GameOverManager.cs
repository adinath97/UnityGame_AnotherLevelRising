using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] GameObject score_text;
    [SerializeField] GameObject high_score_text;
    
    // Start is called before the first frame update
    void Start()
    {
        score_text.GetComponent<TMP_Text>().text = "SCORE: " + ScoreManager.GetScore().ToString();
        high_score_text.GetComponent<TMP_Text>().text = "HIGH SCORE: " + ScoreManager.GetHighScore().ToString();
    }
}
