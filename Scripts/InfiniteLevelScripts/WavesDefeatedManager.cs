using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WavesDefeatedManager : MonoBehaviour
{
    public static int wavesDefeated = 0;
    public static bool wavesDefeatedHighScore;
    [SerializeField] GameObject WaveTrackerBox;
    
    // Start is called before the first frame update
    void Start()
    {
        wavesDefeated = 0;
        wavesDefeatedHighScore = false;
    }

    // Update is called once per frame
    void Update()
    {
        WaveTrackerBox.GetComponent<Text>().text = "WAVES CLEARED: " + wavesDefeated.ToString();
        if(wavesDefeated > PlayerPrefs.GetInt("MaxWaves", 0))
        { 
            wavesDefeatedHighScore = true;
            PlayerPrefs.SetInt("MaxWaves", wavesDefeated);
        }
    }
}
