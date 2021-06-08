using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTracker : MonoBehaviour
{
    [SerializeField] GameObject waveNumberBox;
    [SerializeField] GameObject movivationalTextBox;
    public static int includeCurrentWave;
    List<string> motivationalMessages = new List<string>{"FANTASTIC WORK!","MASTERFUL MANEUVERING!", "SPLENDID SHOOTING!", "PHENOMENAL PERFORMANCE!", "ABSOLUTELY SENSATIONAL!"};
    
    int randomSelection;
    public static bool messageSelected, finiteGameOver;
    // Start is called before the first frame update
    void Start()
    {
        movivationalTextBox.SetActive(false);
        finiteGameOver = false;
        messageSelected = false;
        includeCurrentWave = 0;
        waveNumberBox.GetComponent<Text>().text = "WAVE: 1 OF 20";
    }

    // Update is called once per frame
    void Update()
    {
        int updatedWave = includeCurrentWave + 1;
        if(includeCurrentWave >= 20) {
            finiteGameOver = true;
        }
        if(updatedWave > 20) {
            updatedWave = 20;
        }
        waveNumberBox.GetComponent<Text>().text = "WAVE: " + updatedWave + " OF 20";
        if(EnemyInstantiatingManager.waveGap && !finiteGameOver) {
            if(messageSelected == false) {
                randomSelection = Random.Range(0,motivationalMessages.Count);
                messageSelected = true;
            }
            movivationalTextBox.GetComponent<Text>().text = motivationalMessages[randomSelection];
            movivationalTextBox.SetActive(true);
        }
        else {
            movivationalTextBox.SetActive(false);
        }
    }
}
