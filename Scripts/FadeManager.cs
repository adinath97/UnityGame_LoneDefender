using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeAndIntroExitMessageManager : MonoBehaviour
{
    [SerializeField] GameObject exitFade;
    [SerializeField] GameObject entryFade;
    [SerializeField] GameObject introMessage;
    [SerializeField] GameObject exitMessage;

    bool exitFadeActivated, entryFadeActivated, playerWon;
    
    void Awake()
    {
        entryFade.gameObject.SetActive(true);
        exitFade.gameObject.SetActive(false);
        introMessage.gameObject.SetActive(true);
        playerWon = false;
    }

    void Start()
    {
        StartCoroutine(WaitAndRemoveIntroMessage());
    }

    // Update is called once per frame
    void Update()
    {
        if(!exitFadeActivated) {
            if(playerWon || (HealthBar.planetDead && PlanetHealthBar.planetHealth <= 0) || (HealthBar.playerDead && Player.playerHealth <= 0)) {
                exitFadeActivated = true;
                exitFade.gameObject.SetActive(true);
            }
        }
        if(EnemyInstantiatingManager.gameOver) {
            exitMessage.gameObject.SetActive(true);
            StartCoroutine(DisplayExitMessageRoutine());
        }
    }

    IEnumerator WaitAndEndIntroFade() {
        yield return new WaitForSeconds(1f);
        entryFade.gameObject.SetActive(false);
    }

    IEnumerator DisplayExitMessageRoutine() {
        yield return new WaitForSeconds(5f);
        playerWon = true;
    }

    IEnumerator WaitAndRemoveIntroMessage() {
        yield return new WaitForSeconds(5f);
        introMessage.gameObject.SetActive(false);
    }
}
