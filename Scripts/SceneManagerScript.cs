using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    [SerializeField] GameObject startFade;
    [SerializeField] GameObject endFade;
    AudioSource myAudioSource;

    void Awake()
    {
        myAudioSource = this.GetComponent<AudioSource>();
        StartCoroutine(WaitAndRemoveStartFade());
    }

    IEnumerator WaitAndRemoveStartFade() {
        yield return new WaitForSeconds(1f);
        startFade.SetActive(false);
    }

    public void StartFiniteLevel() {
        myAudioSource.Play();
        StartCoroutine(WaitAndLoadFiniteLevel());
    }

    IEnumerator WaitAndLoadFiniteLevel() {
        endFade.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("FiniteGameScene");
    }

    public void StartInfiniteLevel() {
        myAudioSource.Play();
        StartCoroutine(WaitAndLoadInfiniteLevel());
    }

    IEnumerator WaitAndLoadInfiniteLevel() {
        endFade.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("InfiniteGameScene");
    }

    public void LoadCredits() {
        myAudioSource.Play();
        StartCoroutine(WaitAndLoadCredits());
    }

    IEnumerator WaitAndLoadCredits() {
        endFade.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("CreditsScene");
    }

    public void LoadStartMenu() {
        myAudioSource.Play();
        StartCoroutine(WaitAndLoadStartMenu());
    }

    IEnumerator WaitAndLoadStartMenu() {
        endFade.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("StartMenu");
    }


    public void QuitGame() {
        myAudioSource.Play();
        Application.Quit();
    }
    
    
}
