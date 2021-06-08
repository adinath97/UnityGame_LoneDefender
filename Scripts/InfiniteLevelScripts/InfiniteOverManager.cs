using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfiniteOverManager : MonoBehaviour
{
    [SerializeField] GameObject scoreText;
    [SerializeField] GameObject highScoreText;
    [SerializeField] GameObject wavesDefeatedText;
    [SerializeField] GameObject maximumWavesDefeatedText;
    [SerializeField] GameObject gameOverText;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText.GetComponent<Text>().text = "SCORE: " + Mathf.RoundToInt(ScoreManager.currentScore).ToString();
        highScoreText.GetComponent<Text>().text = "HIGH SCORE: " + Mathf.RoundToInt(PlayerPrefs.GetFloat("HighScore", 0f)).ToString();
        wavesDefeatedText.GetComponent<Text>().text = "WAVES DEFEATED: " + WavesDefeatedManager.wavesDefeated.ToString();
        maximumWavesDefeatedText.GetComponent<Text>().text = "MAX WAVES DEFEATED: " + PlayerPrefs.GetInt("MaxWaves", 0).ToString();
        if(WavesDefeatedManager.wavesDefeatedHighScore && !ScoreManager.newHighScore) {
            gameOverText.GetComponent<Text>().text = "PERSONAL RECORD IN MAXIMUM WAVES DEFEATED!";
            WavesDefeatedManager.wavesDefeatedHighScore = false;
            return;
        }
        if(!WavesDefeatedManager.wavesDefeatedHighScore && ScoreManager.newHighScore) {
            gameOverText.GetComponent<Text>().text = "NEW HIGH SCORE!";
            ScoreManager.newHighScore = false;
            return;
        }
        if(WavesDefeatedManager.wavesDefeatedHighScore && ScoreManager.newHighScore) {
            gameOverText.GetComponent<Text>().text = "PERSONAL RECORD IN MAXIMUM WAVES DEFEATED AND NEW HIGH SCORE!";
            ScoreManager.newHighScore = false;
            WavesDefeatedManager.wavesDefeatedHighScore = false;
            return;
        }
        if(!WavesDefeatedManager.wavesDefeatedHighScore && !ScoreManager.newHighScore) {
            gameOverText.GetComponent<Text>().text = "FANTASTIC WORK!";
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
