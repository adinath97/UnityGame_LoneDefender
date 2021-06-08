using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameObject scoreTextBox;
    [SerializeField] GameObject highScoreText;
    [SerializeField] GameObject introText;
    [SerializeField] GameObject meteorWarningText;
    [SerializeField] GameObject InfiniteInstantiatingManagerObject;
    private Text scoreText;
    public static bool newHighScore, activateMeteorWarning;
    public static float currentScore;

    int random1;

    void Awake()
    {
        highScoreText.SetActive(false);
        newHighScore = false;
        activateMeteorWarning = false;
        StartCoroutine(WaitAndRemoveIntroText());
    }
    
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        random1 = 0;
        scoreText = scoreTextBox.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        currentScore += Time.deltaTime * 10f;
        scoreText.text = "SCORE: " + Mathf.RoundToInt(currentScore).ToString();
        if(currentScore > PlayerPrefs.GetFloat("HighScore", 0f))
        {
            if(random1 == 0) {
                random1++;
                InfinitePlayer.newHighScore = true;
                StartCoroutine(PlayerHighScoreRoutine());
            }
            newHighScore = true;
            PlayerPrefs.SetFloat("HighScore", currentScore);
        }
        if(activateMeteorWarning) {
            StartCoroutine(WaitAndRemoveMeteorWarning());
        }
    }

    IEnumerator WaitAndRemoveMeteorWarning() {
        activateMeteorWarning = false;
        meteorWarningText.SetActive(true);
        yield return new WaitForSeconds(3f);
        meteorWarningText.SetActive(false);
    }

    IEnumerator PlayerHighScoreRoutine() {
        highScoreText.SetActive(true);
        yield return new WaitForSeconds(3f);
        highScoreText.SetActive(false);
    }

    IEnumerator WaitAndRemoveIntroText() {
        yield return new WaitForSeconds(5f);
        GamePlayManager.beginGame = true;
    }
}
