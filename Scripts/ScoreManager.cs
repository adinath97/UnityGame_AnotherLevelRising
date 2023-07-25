using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameObject score_text;
    static int score = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score_text.GetComponent<TMP_Text>().text = "SCORE: " + score.ToString();

        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", Mathf.RoundToInt(score));
        }
    }

    public void IncrementScore() {
        score++;
    }

    public static int GetScore() { return score; }

    public static int GetHighScore() { return PlayerPrefs.GetInt("HighScore", 0); }

    
}
