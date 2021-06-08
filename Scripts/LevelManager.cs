using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject startFade;
    [SerializeField] GameObject endFade;
    public static bool readyForNextScene;
    
    void Awake()
    {
        readyForNextScene = false;
        endFade.SetActive(false);
        startFade.SetActive(true);
        StartCoroutine(WaitAndRemoveStartFade());
    }

    // Update is called once per frame
    public void StartEndFade() {
        StartCoroutine(WaitAndStartEndFade());
    }

    private IEnumerator WaitAndRemoveStartFade() {
        yield return new WaitForSeconds(1f);
        startFade.SetActive(false);
    }

    private IEnumerator WaitAndStartEndFade() {
        endFade.SetActive(true);
        yield return new WaitForSeconds(1f);
        readyForNextScene = true;
    }
}
