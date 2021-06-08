using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    [SerializeField] GameObject exitFade;
    [SerializeField] GameObject entryFade;

    bool exitFadeActivated, entryFadeActivated;
    
    void Awake()
    {
        entryFade.gameObject.SetActive(true);
        exitFade.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!exitFadeActivated && (HealthBar.planetDead && PlanetHealthBar.planetHealth <= 0) || (HealthBar.playerDead && Player.playerHealth <= 0)) {
            exitFadeActivated = true;
            exitFade.gameObject.SetActive(true);
        }
    }

    IEnumerator WaitAndEndIntroFade() {
        yield return new WaitForSeconds(1f);
        entryFade.gameObject.SetActive(false);
    }
}
