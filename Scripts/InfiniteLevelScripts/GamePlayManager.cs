using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField] GameObject startFade;
    [SerializeField] GameObject endFade;
    public static bool beginGame;
    public static bool gameOver;
    void Awake()
    {
        beginGame = false;
        gameOver = false;
        endFade.SetActive(false);
        StartCoroutine(WaitAndRemoveStartFade());
    }

    // Update is called once per frame
    void Update()
    {
       if(gameOver) {
           StartCoroutine(WaitAndRemoveEndFade());
       } 
    }

    private IEnumerator WaitAndRemoveStartFade() {
        yield return new WaitForSeconds(1f);
        startFade.SetActive(false);
    }
    private IEnumerator WaitAndRemoveEndFade() {
        endFade.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("InfiniteOverScene");
    }
}
