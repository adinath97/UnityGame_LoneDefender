using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyInstantiatingManager : MonoBehaviour
{
    [SerializeField] GameObject enemyBlack1Prefab;

    [SerializeField] GameObject enemyBlack2Prefab;

    [SerializeField] GameObject enemyBlack3Prefab;
    [SerializeField] GameObject enemyBlack4Prefab;
    [SerializeField] GameObject enemyBlack5Prefab;
    [SerializeField] List<GameObject> enemyGreens;
    [SerializeField] List<GameObject> enemyBlues;
    [SerializeField] List<GameObject> enemyOranges;

    [SerializeField] float instantiationTime = .2f;

    float waitTime;

    public static int wavesCompleted, wave1Total, wave2Total, wave3Total, wave4Total, wave5Total,
    wave3TotalLaunched,wave4TotalLaunched,wave2TotalLaunched, wave1TotalLaunched, wave5TotalLaunched, legionsCompleted;
    
    public static bool playerWon, startWave, waveGap, blackNow, greenNow, blueNow, orangeNow, gameOver, finiteLevelOver;
    
    void Awake()
    {
        //resetting static bools
        playerWon = false;
        waveGap = false;
        startWave = false;
        blackNow = true;
        greenNow = false;
        blueNow = false;
        orangeNow = false;
        gameOver = false;
        finiteLevelOver = false;

        //resetting static ints
        wavesCompleted = 0;
        wave1Total = 0;
        wave2Total = 0;
        wave3Total = 0;
        wave4Total = 0;
        wave5Total = 0;
        wave1TotalLaunched = 0;
        wave2TotalLaunched = 0;
        wave3TotalLaunched = 0;
        wave4TotalLaunched = 0;
        wave5TotalLaunched = 0;
        legionsCompleted = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        waitTime = 5f;
        StartCoroutine(WaitAndInstantiate1());
        StartCoroutine(WaitAndInstantiate2());
        StartCoroutine(WaitAndInstantiate3());
        
    }

    void Update()
    {
        if(gameOver) {
            playerWon = true;
            finiteLevelOver = true;
        }
        if(finiteLevelOver) {
            finiteLevelOver = false;
            StartCoroutine(WaitAndLoadOverFiniteScene());
        }
        //blacks
        if(wave1Total == 12 && wavesCompleted == 0) {
            GameTracker.messageSelected = false;
            waveGap = true;
            wavesCompleted++;
            GameTracker.includeCurrentWave++;
            startWave = true;
            wave1Total = 0;
        }
        if(wavesCompleted == 1 && startWave) {
            waitTime = 3f;
            StartCoroutine(EnemyBlack2Routine());
        }

        if(wave2Total == 7 && wavesCompleted == 1) {
            GameTracker.messageSelected = false;
            waveGap = true;
            ////Debug.Log("HELLO 3");
            wavesCompleted++;
            GameTracker.includeCurrentWave++;
            startWave = true;
            wave2Total = 0;
        }
        if(wavesCompleted == 2 && startWave) {
            StartCoroutine(EnemyBlack3Routine());
        }

        if(wave3Total == 5 && wavesCompleted == 2) {
            GameTracker.messageSelected = false;
            waveGap = true;
            wavesCompleted++;
            GameTracker.includeCurrentWave++;
            startWave = true;
            wave3Total = 0;
        }
        if(wavesCompleted == 3 && startWave) {
            StartCoroutine(EnemyBlack4Routine());
        }

        if(wave4Total == 10 && wavesCompleted == 3) {
            GameTracker.messageSelected = false;
            waveGap = true;
            wavesCompleted++;
            GameTracker.includeCurrentWave++;
            startWave = true;
            wave4Total = 0;
        }

        if(wavesCompleted == 4 && startWave) {
            StartCoroutine(EnemyBlack5Routine());
        }

        if(wave5Total == 5 && wavesCompleted == 4) {
            ////Debug.Log("TIMEEEEEEE");
            GameTracker.messageSelected = false;
            waveGap = true;
            wavesCompleted++;
            GameTracker.includeCurrentWave++;
            startWave = true;
            wave5Total = 0;
        }
        if(wavesCompleted == 5 && startWave && !gameOver) {
            GameTracker.messageSelected = false;
            legionsCompleted++;
            wave1TotalLaunched = 0;
            wave3TotalLaunched = 0;
            wave4TotalLaunched = 0;
            wave2TotalLaunched = 0;
            wave5TotalLaunched = 0;
            if(legionsCompleted == 1) {
                blackNow = false;
                greenNow = true;
                blueNow = false;
                orangeNow = false;
            }
            else if(legionsCompleted == 2) {
                blackNow = false;
                greenNow = false;
                blueNow = true;
                orangeNow = false;
            }
            else if(legionsCompleted == 3) {
                blackNow = false;
                greenNow = false;
                blueNow = false;
                orangeNow = true;
            }
            else if(legionsCompleted == 4) {
                blackNow = false;
                greenNow = false;
                blueNow = false;
                orangeNow = false;
                gameOver = true;
                finiteLevelOver = true;
            }
            StartCoroutine(WaitAndInstantiate1());
            StartCoroutine(WaitAndInstantiate2());
            StartCoroutine(WaitAndInstantiate3());
            wavesCompleted = 0;
        }
    }

    IEnumerator WaitAndLoadOverFiniteScene() {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("FiniteOverScene");
    }

    IEnumerator EnemyBlack5Routine() {

        startWave = false;
        yield return new WaitForSeconds(waitTime);
        waveGap = false;
        if(blackNow) {
            GameObject enemyBlack5Instance1 = Instantiate(enemyBlack5Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack5Instance1.GetComponent<EnemyPathingBlack5>().first1 = true;
            enemyBlack5Instance1.GetComponent<EnemyPathingBlack5>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack5Instance2 = Instantiate(enemyBlack5Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack5Instance2.GetComponent<EnemyPathingBlack5>().second1 = true;
            enemyBlack5Instance2.GetComponent<EnemyPathingBlack5>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack5Instance3 = Instantiate(enemyBlack5Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack5Instance3.GetComponent<EnemyPathingBlack5>().third1 = true;
            enemyBlack5Instance3.GetComponent<EnemyPathingBlack5>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack5Instance4 = Instantiate(enemyBlack5Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack5Instance4.GetComponent<EnemyPathingBlack5>().fourth1 = true;
            enemyBlack5Instance4.GetComponent<EnemyPathingBlack5>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack5Instance5 = Instantiate(enemyBlack5Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack5Instance5.GetComponent<EnemyPathingBlack5>().fifth1 = true;
            enemyBlack5Instance5.GetComponent<EnemyPathingBlack5>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
        }
        if(greenNow) {
            GameObject enemyBlack5Instance1 = Instantiate(enemyGreens[4],transform.position,Quaternion.identity) as GameObject;
            enemyBlack5Instance1.GetComponent<EnemyPathingBlack5>().first1 = true;
            enemyBlack5Instance1.GetComponent<EnemyPathingBlack5>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack5Instance2 = Instantiate(enemyGreens[4],transform.position,Quaternion.identity) as GameObject;
            enemyBlack5Instance2.GetComponent<EnemyPathingBlack5>().second1 = true;
            enemyBlack5Instance2.GetComponent<EnemyPathingBlack5>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack5Instance3 = Instantiate(enemyGreens[4],transform.position,Quaternion.identity) as GameObject;
            enemyBlack5Instance3.GetComponent<EnemyPathingBlack5>().third1 = true;
            enemyBlack5Instance3.GetComponent<EnemyPathingBlack5>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack5Instance4 = Instantiate(enemyGreens[4],transform.position,Quaternion.identity) as GameObject;
            enemyBlack5Instance4.GetComponent<EnemyPathingBlack5>().fourth1 = true;
            enemyBlack5Instance4.GetComponent<EnemyPathingBlack5>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack5Instance5 = Instantiate(enemyGreens[4],transform.position,Quaternion.identity) as GameObject;
            enemyBlack5Instance5.GetComponent<EnemyPathingBlack5>().fifth1 = true;
            enemyBlack5Instance5.GetComponent<EnemyPathingBlack5>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
        }
        if(blueNow) {
            GameObject enemyBlack5Instance1 = Instantiate(enemyBlues[4],transform.position,Quaternion.identity) as GameObject;
            enemyBlack5Instance1.GetComponent<EnemyPathingBlack5>().first1 = true;
            enemyBlack5Instance1.GetComponent<EnemyPathingBlack5>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack5Instance2 = Instantiate(enemyBlues[4],transform.position,Quaternion.identity) as GameObject;
            enemyBlack5Instance2.GetComponent<EnemyPathingBlack5>().second1 = true;
            enemyBlack5Instance2.GetComponent<EnemyPathingBlack5>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack5Instance3 = Instantiate(enemyBlues[4],transform.position,Quaternion.identity) as GameObject;
            enemyBlack5Instance3.GetComponent<EnemyPathingBlack5>().third1 = true;
            enemyBlack5Instance3.GetComponent<EnemyPathingBlack5>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack5Instance4 = Instantiate(enemyBlues[4],transform.position,Quaternion.identity) as GameObject;
            enemyBlack5Instance4.GetComponent<EnemyPathingBlack5>().fourth1 = true;
            enemyBlack5Instance4.GetComponent<EnemyPathingBlack5>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack5Instance5 = Instantiate(enemyBlues[4],transform.position,Quaternion.identity) as GameObject;
            enemyBlack5Instance5.GetComponent<EnemyPathingBlack5>().fifth1 = true;
            enemyBlack5Instance5.GetComponent<EnemyPathingBlack5>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
        }
        if(orangeNow) {
            GameObject enemyBlack5Instance1 = Instantiate(enemyOranges[4],transform.position,Quaternion.identity) as GameObject;
            enemyBlack5Instance1.GetComponent<EnemyPathingBlack5>().first1 = true;
            enemyBlack5Instance1.GetComponent<EnemyPathingBlack5>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack5Instance2 = Instantiate(enemyOranges[4],transform.position,Quaternion.identity) as GameObject;
            enemyBlack5Instance2.GetComponent<EnemyPathingBlack5>().second1 = true;
            enemyBlack5Instance2.GetComponent<EnemyPathingBlack5>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack5Instance3 = Instantiate(enemyOranges[4],transform.position,Quaternion.identity) as GameObject;
            enemyBlack5Instance3.GetComponent<EnemyPathingBlack5>().third1 = true;
            enemyBlack5Instance3.GetComponent<EnemyPathingBlack5>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack5Instance4 = Instantiate(enemyOranges[4],transform.position,Quaternion.identity) as GameObject;
            enemyBlack5Instance4.GetComponent<EnemyPathingBlack5>().fourth1 = true;
            enemyBlack5Instance4.GetComponent<EnemyPathingBlack5>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack5Instance5 = Instantiate(enemyOranges[4],transform.position,Quaternion.identity) as GameObject;
            enemyBlack5Instance5.GetComponent<EnemyPathingBlack5>().fifth1 = true;
            enemyBlack5Instance5.GetComponent<EnemyPathingBlack5>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
        }
        
    }

    IEnumerator EnemyBlack4Routine() {
        startWave = false;
        yield return new WaitForSeconds(waitTime);
        waveGap = false;
        StartCoroutine(WaitAndInstantiate7());
        StartCoroutine(WaitAndInstantiate8());
    }

    IEnumerator EnemyBlack3Routine() {
        ////Debug.Log("HELLO 2");
        ////Debug.Log(wavesCompleted);
        startWave = false;
        yield return new WaitForSeconds(waitTime);
        waveGap = false;
        //launch wave 3
        StartCoroutine(WaitAndInstantiate6());
    }

    IEnumerator EnemyBlack2Routine() {
        startWave = false;
        yield return new WaitForSeconds(waitTime);
        waveGap = false;
        ////Debug.Log("HELLO 1");
        //launch wave 2
        StartCoroutine(WaitAndInstantiate4());
        StartCoroutine(WaitAndInstantiate5());
    }

    IEnumerator WaitAndInstantiate1() {
        startWave = false;
        yield return new WaitForSeconds(waitTime);
        waveGap = false;
        if(blackNow) {
            GameObject enemyBlack1Instance1 = Instantiate(enemyBlack1Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance1.GetComponent<EnemyPathingBlack1>().first1 = true;
            enemyBlack1Instance1.GetComponent<EnemyPathingBlack1>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack1Instance2 = Instantiate(enemyBlack1Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance2.GetComponent<EnemyPathingBlack1>().second1 = true;
            enemyBlack1Instance2.GetComponent<EnemyPathingBlack1>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack1Instance3 = Instantiate(enemyBlack1Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance3.GetComponent<EnemyPathingBlack1>().third1 = true;
            enemyBlack1Instance3.GetComponent<EnemyPathingBlack1>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack1Instance4 = Instantiate(enemyBlack1Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance4.GetComponent<EnemyPathingBlack1>().fourth1 = true;
            enemyBlack1Instance4.GetComponent<EnemyPathingBlack1>().instantiated = true;
        }
        if(greenNow) {
            ////Debug.Log("HERE NOW");
            GameObject enemyBlack1Instance1 = Instantiate(enemyGreens[0],transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance1.GetComponent<EnemyPathingBlack1>().first1 = true;
            enemyBlack1Instance1.GetComponent<EnemyPathingBlack1>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack1Instance2 = Instantiate(enemyGreens[0],transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance2.GetComponent<EnemyPathingBlack1>().second1 = true;
            enemyBlack1Instance2.GetComponent<EnemyPathingBlack1>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack1Instance3 = Instantiate(enemyGreens[0],transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance3.GetComponent<EnemyPathingBlack1>().third1 = true;
            enemyBlack1Instance3.GetComponent<EnemyPathingBlack1>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack1Instance4 = Instantiate(enemyGreens[0],transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance4.GetComponent<EnemyPathingBlack1>().fourth1 = true;
            enemyBlack1Instance4.GetComponent<EnemyPathingBlack1>().instantiated = true;
        }
        if(orangeNow) {
            GameObject enemyBlack1Instance1 = Instantiate(enemyOranges[0],transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance1.GetComponent<EnemyPathingBlack1>().first1 = true;
            enemyBlack1Instance1.GetComponent<EnemyPathingBlack1>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack1Instance2 = Instantiate(enemyOranges[0],transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance2.GetComponent<EnemyPathingBlack1>().second1 = true;
            enemyBlack1Instance2.GetComponent<EnemyPathingBlack1>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack1Instance3 = Instantiate(enemyOranges[0],transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance3.GetComponent<EnemyPathingBlack1>().third1 = true;
            enemyBlack1Instance3.GetComponent<EnemyPathingBlack1>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack1Instance4 = Instantiate(enemyOranges[0],transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance4.GetComponent<EnemyPathingBlack1>().fourth1 = true;
            enemyBlack1Instance4.GetComponent<EnemyPathingBlack1>().instantiated = true;
        }
        if(blueNow) {
            GameObject enemyBlack1Instance1 = Instantiate(enemyBlues[0],transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance1.GetComponent<EnemyPathingBlack1>().first1 = true;
            enemyBlack1Instance1.GetComponent<EnemyPathingBlack1>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack1Instance2 = Instantiate(enemyBlues[0],transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance2.GetComponent<EnemyPathingBlack1>().second1 = true;
            enemyBlack1Instance2.GetComponent<EnemyPathingBlack1>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack1Instance3 = Instantiate(enemyBlues[0],transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance3.GetComponent<EnemyPathingBlack1>().third1 = true;
            enemyBlack1Instance3.GetComponent<EnemyPathingBlack1>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack1Instance4 = Instantiate(enemyBlues[0],transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance4.GetComponent<EnemyPathingBlack1>().fourth1 = true;
            enemyBlack1Instance4.GetComponent<EnemyPathingBlack1>().instantiated = true;
        }
        
    }

    IEnumerator WaitAndInstantiate2() {
        startWave = false;
        yield return new WaitForSeconds(waitTime);
        waveGap = false;
        if(blackNow) {
            GameObject enemyBlack1Instance1 = Instantiate(enemyBlack1Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance1.GetComponent<EnemyPathingBlack1>().first2 = true;
            enemyBlack1Instance1.GetComponent<EnemyPathingBlack1>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack1Instance2 = Instantiate(enemyBlack1Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance2.GetComponent<EnemyPathingBlack1>().second2 = true;
            enemyBlack1Instance2.GetComponent<EnemyPathingBlack1>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack1Instance3 = Instantiate(enemyBlack1Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance3.GetComponent<EnemyPathingBlack1>().third2 = true;
            enemyBlack1Instance3.GetComponent<EnemyPathingBlack1>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack1Instance4 = Instantiate(enemyBlack1Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance4.GetComponent<EnemyPathingBlack1>().fourth2 = true;
            enemyBlack1Instance4.GetComponent<EnemyPathingBlack1>().instantiated = true;
        }
        if(greenNow) {
            GameObject enemyBlack1Instance1 = Instantiate(enemyGreens[0],transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance1.GetComponent<EnemyPathingBlack1>().first2 = true;
            enemyBlack1Instance1.GetComponent<EnemyPathingBlack1>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack1Instance2 = Instantiate(enemyGreens[0],transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance2.GetComponent<EnemyPathingBlack1>().second2 = true;
            enemyBlack1Instance2.GetComponent<EnemyPathingBlack1>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack1Instance3 = Instantiate(enemyGreens[0],transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance3.GetComponent<EnemyPathingBlack1>().third2 = true;
            enemyBlack1Instance3.GetComponent<EnemyPathingBlack1>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack1Instance4 = Instantiate(enemyGreens[0],transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance4.GetComponent<EnemyPathingBlack1>().fourth2 = true;
            enemyBlack1Instance4.GetComponent<EnemyPathingBlack1>().instantiated = true;
        }
        if(orangeNow) {
            GameObject enemyBlack1Instance1 = Instantiate(enemyOranges[0],transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance1.GetComponent<EnemyPathingBlack1>().first2 = true;
            enemyBlack1Instance1.GetComponent<EnemyPathingBlack1>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack1Instance2 = Instantiate(enemyOranges[0],transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance2.GetComponent<EnemyPathingBlack1>().second2 = true;
            enemyBlack1Instance2.GetComponent<EnemyPathingBlack1>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack1Instance3 = Instantiate(enemyOranges[0],transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance3.GetComponent<EnemyPathingBlack1>().third2 = true;
            enemyBlack1Instance3.GetComponent<EnemyPathingBlack1>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack1Instance4 = Instantiate(enemyOranges[0],transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance4.GetComponent<EnemyPathingBlack1>().fourth2 = true;
            enemyBlack1Instance4.GetComponent<EnemyPathingBlack1>().instantiated = true;
        }
        if(blueNow) {
            GameObject enemyBlack1Instance1 = Instantiate(enemyBlues[0],transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance1.GetComponent<EnemyPathingBlack1>().first2 = true;
            enemyBlack1Instance1.GetComponent<EnemyPathingBlack1>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack1Instance2 = Instantiate(enemyBlues[0],transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance2.GetComponent<EnemyPathingBlack1>().second2 = true;
            enemyBlack1Instance2.GetComponent<EnemyPathingBlack1>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack1Instance3 = Instantiate(enemyBlues[0],transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance3.GetComponent<EnemyPathingBlack1>().third2 = true;
            enemyBlack1Instance3.GetComponent<EnemyPathingBlack1>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack1Instance4 = Instantiate(enemyBlues[0],transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance4.GetComponent<EnemyPathingBlack1>().fourth2 = true;
            enemyBlack1Instance4.GetComponent<EnemyPathingBlack1>().instantiated = true;
        }
        
    }

    IEnumerator WaitAndInstantiate3() {
        startWave = false;
        yield return new WaitForSeconds(waitTime);
        waveGap = false;
        if(blackNow) {
            GameObject enemyBlack1Instance1 = Instantiate(enemyBlack1Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance1.GetComponent<EnemyPathingBlack1>().first3 = true;
            enemyBlack1Instance1.GetComponent<EnemyPathingBlack1>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack1Instance2 = Instantiate(enemyBlack1Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance2.GetComponent<EnemyPathingBlack1>().second3 = true;
            enemyBlack1Instance2.GetComponent<EnemyPathingBlack1>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack1Instance3 = Instantiate(enemyBlack1Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance3.GetComponent<EnemyPathingBlack1>().third3 = true;
            enemyBlack1Instance3.GetComponent<EnemyPathingBlack1>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack1Instance4 = Instantiate(enemyBlack1Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance4.GetComponent<EnemyPathingBlack1>().fourth3 = true;
            enemyBlack1Instance4.GetComponent<EnemyPathingBlack1>().instantiated = true;
        }
        if(greenNow) {
            GameObject enemyBlack1Instance1 = Instantiate(enemyGreens[0],transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance1.GetComponent<EnemyPathingBlack1>().first3 = true;
            enemyBlack1Instance1.GetComponent<EnemyPathingBlack1>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack1Instance2 = Instantiate(enemyGreens[0],transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance2.GetComponent<EnemyPathingBlack1>().second3 = true;
            enemyBlack1Instance2.GetComponent<EnemyPathingBlack1>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack1Instance3 = Instantiate(enemyGreens[0],transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance3.GetComponent<EnemyPathingBlack1>().third3 = true;
            enemyBlack1Instance3.GetComponent<EnemyPathingBlack1>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack1Instance4 = Instantiate(enemyGreens[0],transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance4.GetComponent<EnemyPathingBlack1>().fourth3 = true;
            enemyBlack1Instance4.GetComponent<EnemyPathingBlack1>().instantiated = true;
        }
        if(orangeNow) {
            GameObject enemyBlack1Instance1 = Instantiate(enemyOranges[0],transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance1.GetComponent<EnemyPathingBlack1>().first3 = true;
            enemyBlack1Instance1.GetComponent<EnemyPathingBlack1>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack1Instance2 = Instantiate(enemyOranges[0],transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance2.GetComponent<EnemyPathingBlack1>().second3 = true;
            enemyBlack1Instance2.GetComponent<EnemyPathingBlack1>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack1Instance3 = Instantiate(enemyOranges[0],transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance3.GetComponent<EnemyPathingBlack1>().third3 = true;
            enemyBlack1Instance3.GetComponent<EnemyPathingBlack1>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack1Instance4 = Instantiate(enemyOranges[0],transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance4.GetComponent<EnemyPathingBlack1>().fourth3 = true;
            enemyBlack1Instance4.GetComponent<EnemyPathingBlack1>().instantiated = true;
        }
        if(blueNow) {
            GameObject enemyBlack1Instance1 = Instantiate(enemyBlues[0],transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance1.GetComponent<EnemyPathingBlack1>().first3 = true;
            enemyBlack1Instance1.GetComponent<EnemyPathingBlack1>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack1Instance2 = Instantiate(enemyBlues[0],transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance2.GetComponent<EnemyPathingBlack1>().second3 = true;
            enemyBlack1Instance2.GetComponent<EnemyPathingBlack1>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack1Instance3 = Instantiate(enemyBlues[0],transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance3.GetComponent<EnemyPathingBlack1>().third3 = true;
            enemyBlack1Instance3.GetComponent<EnemyPathingBlack1>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack1Instance4 = Instantiate(enemyBlues[0],transform.position,Quaternion.identity) as GameObject;
            enemyBlack1Instance4.GetComponent<EnemyPathingBlack1>().fourth3 = true;
            enemyBlack1Instance4.GetComponent<EnemyPathingBlack1>().instantiated = true;
        }
    }

    IEnumerator WaitAndInstantiate4() {
        if(blackNow) {
            GameObject enemyBlack2Instance1 = Instantiate(enemyBlack2Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack2Instance1.GetComponent<EnemyPathingBlack2>().first1 = true;
            enemyBlack2Instance1.GetComponent<EnemyPathingBlack2>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack2Instance2 = Instantiate(enemyBlack2Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack2Instance2.GetComponent<EnemyPathingBlack2>().second1 = true;
            enemyBlack2Instance2.GetComponent<EnemyPathingBlack2>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack2Instance3 = Instantiate(enemyBlack2Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack2Instance3.GetComponent<EnemyPathingBlack2>().third1 = true;
            enemyBlack2Instance3.GetComponent<EnemyPathingBlack2>().instantiated = true;
        }
        if(greenNow) {
            GameObject enemyBlack2Instance1 = Instantiate(enemyGreens[1],transform.position,Quaternion.identity) as GameObject;
            enemyBlack2Instance1.GetComponent<EnemyPathingBlack2>().first1 = true;
            enemyBlack2Instance1.GetComponent<EnemyPathingBlack2>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack2Instance2 = Instantiate(enemyGreens[1],transform.position,Quaternion.identity) as GameObject;
            enemyBlack2Instance2.GetComponent<EnemyPathingBlack2>().second1 = true;
            enemyBlack2Instance2.GetComponent<EnemyPathingBlack2>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack2Instance3 = Instantiate(enemyGreens[1],transform.position,Quaternion.identity) as GameObject;
            enemyBlack2Instance3.GetComponent<EnemyPathingBlack2>().third1 = true;
            enemyBlack2Instance3.GetComponent<EnemyPathingBlack2>().instantiated = true;
        }
        if(blueNow) {
            GameObject enemyBlack2Instance1 = Instantiate(enemyBlues[1],transform.position,Quaternion.identity) as GameObject;
            enemyBlack2Instance1.GetComponent<EnemyPathingBlack2>().first1 = true;
            enemyBlack2Instance1.GetComponent<EnemyPathingBlack2>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack2Instance2 = Instantiate(enemyBlues[1],transform.position,Quaternion.identity) as GameObject;
            enemyBlack2Instance2.GetComponent<EnemyPathingBlack2>().second1 = true;
            enemyBlack2Instance2.GetComponent<EnemyPathingBlack2>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack2Instance3 = Instantiate(enemyBlues[1],transform.position,Quaternion.identity) as GameObject;
            enemyBlack2Instance3.GetComponent<EnemyPathingBlack2>().third1 = true;
            enemyBlack2Instance3.GetComponent<EnemyPathingBlack2>().instantiated = true;
        }
        if(orangeNow) {
            GameObject enemyBlack2Instance1 = Instantiate(enemyOranges[1],transform.position,Quaternion.identity) as GameObject;
            enemyBlack2Instance1.GetComponent<EnemyPathingBlack2>().first1 = true;
            enemyBlack2Instance1.GetComponent<EnemyPathingBlack2>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack2Instance2 = Instantiate(enemyOranges[1],transform.position,Quaternion.identity) as GameObject;
            enemyBlack2Instance2.GetComponent<EnemyPathingBlack2>().second1 = true;
            enemyBlack2Instance2.GetComponent<EnemyPathingBlack2>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack2Instance3 = Instantiate(enemyOranges[1],transform.position,Quaternion.identity) as GameObject;
            enemyBlack2Instance3.GetComponent<EnemyPathingBlack2>().third1 = true;
            enemyBlack2Instance3.GetComponent<EnemyPathingBlack2>().instantiated = true;
        }
    }

    IEnumerator WaitAndInstantiate5() {
        if(blackNow) {
            GameObject enemyBlack2Instance1 = Instantiate(enemyBlack2Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack2Instance1.GetComponent<EnemyPathingBlack2>().first2 = true;
            enemyBlack2Instance1.GetComponent<EnemyPathingBlack2>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack2Instance2 = Instantiate(enemyBlack2Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack2Instance2.GetComponent<EnemyPathingBlack2>().second2 = true;
            enemyBlack2Instance2.GetComponent<EnemyPathingBlack2>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack2Instance3 = Instantiate(enemyBlack2Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack2Instance3.GetComponent<EnemyPathingBlack2>().third2 = true;
            enemyBlack2Instance3.GetComponent<EnemyPathingBlack2>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack2Instance4 = Instantiate(enemyBlack2Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack2Instance4.GetComponent<EnemyPathingBlack2>().fourth2 = true;
            enemyBlack2Instance4.GetComponent<EnemyPathingBlack2>().instantiated = true;
        }
        if(greenNow) {
            GameObject enemyBlack2Instance1 = Instantiate(enemyGreens[1],transform.position,Quaternion.identity) as GameObject;
            enemyBlack2Instance1.GetComponent<EnemyPathingBlack2>().first2 = true;
            enemyBlack2Instance1.GetComponent<EnemyPathingBlack2>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack2Instance2 = Instantiate(enemyGreens[1],transform.position,Quaternion.identity) as GameObject;
            enemyBlack2Instance2.GetComponent<EnemyPathingBlack2>().second2 = true;
            enemyBlack2Instance2.GetComponent<EnemyPathingBlack2>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack2Instance3 = Instantiate(enemyGreens[1],transform.position,Quaternion.identity) as GameObject;
            enemyBlack2Instance3.GetComponent<EnemyPathingBlack2>().third2 = true;
            enemyBlack2Instance3.GetComponent<EnemyPathingBlack2>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack2Instance4 = Instantiate(enemyGreens[1],transform.position,Quaternion.identity) as GameObject;
            enemyBlack2Instance4.GetComponent<EnemyPathingBlack2>().fourth2 = true;
            enemyBlack2Instance4.GetComponent<EnemyPathingBlack2>().instantiated = true;
        }
        if(blueNow) {
            GameObject enemyBlack2Instance1 = Instantiate(enemyBlues[1],transform.position,Quaternion.identity) as GameObject;
            enemyBlack2Instance1.GetComponent<EnemyPathingBlack2>().first2 = true;
            enemyBlack2Instance1.GetComponent<EnemyPathingBlack2>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack2Instance2 = Instantiate(enemyBlues[1],transform.position,Quaternion.identity) as GameObject;
            enemyBlack2Instance2.GetComponent<EnemyPathingBlack2>().second2 = true;
            enemyBlack2Instance2.GetComponent<EnemyPathingBlack2>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack2Instance3 = Instantiate(enemyBlues[1],transform.position,Quaternion.identity) as GameObject;
            enemyBlack2Instance3.GetComponent<EnemyPathingBlack2>().third2 = true;
            enemyBlack2Instance3.GetComponent<EnemyPathingBlack2>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack2Instance4 = Instantiate(enemyBlues[1],transform.position,Quaternion.identity) as GameObject;
            enemyBlack2Instance4.GetComponent<EnemyPathingBlack2>().fourth2 = true;
            enemyBlack2Instance4.GetComponent<EnemyPathingBlack2>().instantiated = true;
        }
        if(orangeNow) {
            GameObject enemyBlack2Instance1 = Instantiate(enemyOranges[1],transform.position,Quaternion.identity) as GameObject;
            enemyBlack2Instance1.GetComponent<EnemyPathingBlack2>().first2 = true;
            enemyBlack2Instance1.GetComponent<EnemyPathingBlack2>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack2Instance2 = Instantiate(enemyOranges[1],transform.position,Quaternion.identity) as GameObject;
            enemyBlack2Instance2.GetComponent<EnemyPathingBlack2>().second2 = true;
            enemyBlack2Instance2.GetComponent<EnemyPathingBlack2>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack2Instance3 = Instantiate(enemyOranges[1],transform.position,Quaternion.identity) as GameObject;
            enemyBlack2Instance3.GetComponent<EnemyPathingBlack2>().third2 = true;
            enemyBlack2Instance3.GetComponent<EnemyPathingBlack2>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack2Instance4 = Instantiate(enemyOranges[1],transform.position,Quaternion.identity) as GameObject;
            enemyBlack2Instance4.GetComponent<EnemyPathingBlack2>().fourth2 = true;
            enemyBlack2Instance4.GetComponent<EnemyPathingBlack2>().instantiated = true;
        }
        
    }

    IEnumerator WaitAndInstantiate6() {
        if(blackNow) {
            GameObject enemyBlack3Instance1 = Instantiate(enemyBlack3Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack3Instance1.GetComponent<EnemyPathingBlack3>().first1 = true;
            enemyBlack3Instance1.GetComponent<EnemyPathingBlack3>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack3Instance2 = Instantiate(enemyBlack3Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack3Instance2.GetComponent<EnemyPathingBlack3>().second1 = true;
            enemyBlack3Instance2.GetComponent<EnemyPathingBlack3>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack3Instance3 = Instantiate(enemyBlack3Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack3Instance3.GetComponent<EnemyPathingBlack3>().third1 = true;
            enemyBlack3Instance3.GetComponent<EnemyPathingBlack3>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack3Instance4 = Instantiate(enemyBlack3Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack3Instance4.GetComponent<EnemyPathingBlack3>().fourth1 = true;
            enemyBlack3Instance4.GetComponent<EnemyPathingBlack3>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack3Instance5 = Instantiate(enemyBlack3Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack3Instance5.GetComponent<EnemyPathingBlack3>().fifth1 = true;
            enemyBlack3Instance5.GetComponent<EnemyPathingBlack3>().instantiated = true;
        }
        if(greenNow) {
            GameObject enemyBlack3Instance1 = Instantiate(enemyGreens[2],transform.position,Quaternion.identity) as GameObject;
            enemyBlack3Instance1.GetComponent<EnemyPathingBlack3>().first1 = true;
            enemyBlack3Instance1.GetComponent<EnemyPathingBlack3>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack3Instance2 = Instantiate(enemyGreens[2],transform.position,Quaternion.identity) as GameObject;
            enemyBlack3Instance2.GetComponent<EnemyPathingBlack3>().second1 = true;
            enemyBlack3Instance2.GetComponent<EnemyPathingBlack3>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack3Instance3 = Instantiate(enemyGreens[2],transform.position,Quaternion.identity) as GameObject;
            enemyBlack3Instance3.GetComponent<EnemyPathingBlack3>().third1 = true;
            enemyBlack3Instance3.GetComponent<EnemyPathingBlack3>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack3Instance4 = Instantiate(enemyGreens[2],transform.position,Quaternion.identity) as GameObject;
            enemyBlack3Instance4.GetComponent<EnemyPathingBlack3>().fourth1 = true;
            enemyBlack3Instance4.GetComponent<EnemyPathingBlack3>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack3Instance5 = Instantiate(enemyGreens[2],transform.position,Quaternion.identity) as GameObject;
            enemyBlack3Instance5.GetComponent<EnemyPathingBlack3>().fifth1 = true;
            enemyBlack3Instance5.GetComponent<EnemyPathingBlack3>().instantiated = true;
        }
        if(blueNow) {
            GameObject enemyBlack3Instance1 = Instantiate(enemyBlues[2],transform.position,Quaternion.identity) as GameObject;
            enemyBlack3Instance1.GetComponent<EnemyPathingBlack3>().first1 = true;
            enemyBlack3Instance1.GetComponent<EnemyPathingBlack3>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack3Instance2 = Instantiate(enemyBlues[2],transform.position,Quaternion.identity) as GameObject;
            enemyBlack3Instance2.GetComponent<EnemyPathingBlack3>().second1 = true;
            enemyBlack3Instance2.GetComponent<EnemyPathingBlack3>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack3Instance3 = Instantiate(enemyBlues[2],transform.position,Quaternion.identity) as GameObject;
            enemyBlack3Instance3.GetComponent<EnemyPathingBlack3>().third1 = true;
            enemyBlack3Instance3.GetComponent<EnemyPathingBlack3>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack3Instance4 = Instantiate(enemyBlues[2],transform.position,Quaternion.identity) as GameObject;
            enemyBlack3Instance4.GetComponent<EnemyPathingBlack3>().fourth1 = true;
            enemyBlack3Instance4.GetComponent<EnemyPathingBlack3>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack3Instance5 = Instantiate(enemyBlues[2],transform.position,Quaternion.identity) as GameObject;
            enemyBlack3Instance5.GetComponent<EnemyPathingBlack3>().fifth1 = true;
            enemyBlack3Instance5.GetComponent<EnemyPathingBlack3>().instantiated = true;
        }
        if(orangeNow) {
            GameObject enemyBlack3Instance1 = Instantiate(enemyOranges[2],transform.position,Quaternion.identity) as GameObject;
            enemyBlack3Instance1.GetComponent<EnemyPathingBlack3>().first1 = true;
            enemyBlack3Instance1.GetComponent<EnemyPathingBlack3>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack3Instance2 = Instantiate(enemyOranges[2],transform.position,Quaternion.identity) as GameObject;
            enemyBlack3Instance2.GetComponent<EnemyPathingBlack3>().second1 = true;
            enemyBlack3Instance2.GetComponent<EnemyPathingBlack3>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack3Instance3 = Instantiate(enemyOranges[2],transform.position,Quaternion.identity) as GameObject;
            enemyBlack3Instance3.GetComponent<EnemyPathingBlack3>().third1 = true;
            enemyBlack3Instance3.GetComponent<EnemyPathingBlack3>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack3Instance4 = Instantiate(enemyOranges[2],transform.position,Quaternion.identity) as GameObject;
            enemyBlack3Instance4.GetComponent<EnemyPathingBlack3>().fourth1 = true;
            enemyBlack3Instance4.GetComponent<EnemyPathingBlack3>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack3Instance5 = Instantiate(enemyOranges[2],transform.position,Quaternion.identity) as GameObject;
            enemyBlack3Instance5.GetComponent<EnemyPathingBlack3>().fifth1 = true;
            enemyBlack3Instance5.GetComponent<EnemyPathingBlack3>().instantiated = true;
        }
        
    }

    IEnumerator WaitAndInstantiate7() {
        if(blackNow) {
            GameObject enemyBlack4Instance1 = Instantiate(enemyBlack4Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance1.GetComponent<EnemyPathingBlack4>().first1 = true;
            enemyBlack4Instance1.GetComponent<EnemyPathingBlack4>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack4Instance2 = Instantiate(enemyBlack4Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance2.GetComponent<EnemyPathingBlack4>().second1 = true;
            enemyBlack4Instance2.GetComponent<EnemyPathingBlack4>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack4Instance3 = Instantiate(enemyBlack4Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance3.GetComponent<EnemyPathingBlack4>().third1 = true;
            enemyBlack4Instance3.GetComponent<EnemyPathingBlack4>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack4Instance4 = Instantiate(enemyBlack4Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance4.GetComponent<EnemyPathingBlack4>().fourth1 = true;
            enemyBlack4Instance4.GetComponent<EnemyPathingBlack4>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack4Instance5 = Instantiate(enemyBlack4Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance5.GetComponent<EnemyPathingBlack4>().fifth1 = true;
            enemyBlack4Instance5.GetComponent<EnemyPathingBlack4>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack4Instance6 = Instantiate(enemyBlack4Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance6.GetComponent<EnemyPathingBlack4>().sixth1 = true;
            enemyBlack4Instance6.GetComponent<EnemyPathingBlack4>().instantiated = true;
        }
        if(greenNow) {
            GameObject enemyBlack4Instance1 = Instantiate(enemyGreens[3],transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance1.GetComponent<EnemyPathingBlack4>().first1 = true;
            enemyBlack4Instance1.GetComponent<EnemyPathingBlack4>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack4Instance2 = Instantiate(enemyGreens[3],transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance2.GetComponent<EnemyPathingBlack4>().second1 = true;
            enemyBlack4Instance2.GetComponent<EnemyPathingBlack4>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack4Instance3 = Instantiate(enemyGreens[3],transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance3.GetComponent<EnemyPathingBlack4>().third1 = true;
            enemyBlack4Instance3.GetComponent<EnemyPathingBlack4>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack4Instance4 = Instantiate(enemyGreens[3],transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance4.GetComponent<EnemyPathingBlack4>().fourth1 = true;
            enemyBlack4Instance4.GetComponent<EnemyPathingBlack4>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack4Instance5 = Instantiate(enemyGreens[3],transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance5.GetComponent<EnemyPathingBlack4>().fifth1 = true;
            enemyBlack4Instance5.GetComponent<EnemyPathingBlack4>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack4Instance6 = Instantiate(enemyGreens[3],transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance6.GetComponent<EnemyPathingBlack4>().sixth1 = true;
            enemyBlack4Instance6.GetComponent<EnemyPathingBlack4>().instantiated = true;
        }
        if(blueNow) {
            GameObject enemyBlack4Instance1 = Instantiate(enemyBlues[3],transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance1.GetComponent<EnemyPathingBlack4>().first1 = true;
            enemyBlack4Instance1.GetComponent<EnemyPathingBlack4>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack4Instance2 = Instantiate(enemyBlues[3],transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance2.GetComponent<EnemyPathingBlack4>().second1 = true;
            enemyBlack4Instance2.GetComponent<EnemyPathingBlack4>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack4Instance3 = Instantiate(enemyBlues[3],transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance3.GetComponent<EnemyPathingBlack4>().third1 = true;
            enemyBlack4Instance3.GetComponent<EnemyPathingBlack4>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack4Instance4 = Instantiate(enemyBlues[3],transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance4.GetComponent<EnemyPathingBlack4>().fourth1 = true;
            enemyBlack4Instance4.GetComponent<EnemyPathingBlack4>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack4Instance5 = Instantiate(enemyBlues[3],transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance5.GetComponent<EnemyPathingBlack4>().fifth1 = true;
            enemyBlack4Instance5.GetComponent<EnemyPathingBlack4>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack4Instance6 = Instantiate(enemyBlues[3],transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance6.GetComponent<EnemyPathingBlack4>().sixth1 = true;
            enemyBlack4Instance6.GetComponent<EnemyPathingBlack4>().instantiated = true;
        }
        if(orangeNow) {
            GameObject enemyBlack4Instance1 = Instantiate(enemyOranges[3],transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance1.GetComponent<EnemyPathingBlack4>().first1 = true;
            enemyBlack4Instance1.GetComponent<EnemyPathingBlack4>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack4Instance2 = Instantiate(enemyOranges[3],transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance2.GetComponent<EnemyPathingBlack4>().second1 = true;
            enemyBlack4Instance2.GetComponent<EnemyPathingBlack4>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack4Instance3 = Instantiate(enemyOranges[3],transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance3.GetComponent<EnemyPathingBlack4>().third1 = true;
            enemyBlack4Instance3.GetComponent<EnemyPathingBlack4>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack4Instance4 = Instantiate(enemyOranges[3],transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance4.GetComponent<EnemyPathingBlack4>().fourth1 = true;
            enemyBlack4Instance4.GetComponent<EnemyPathingBlack4>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack4Instance5 = Instantiate(enemyOranges[3],transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance5.GetComponent<EnemyPathingBlack4>().fifth1 = true;
            enemyBlack4Instance5.GetComponent<EnemyPathingBlack4>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack4Instance6 = Instantiate(enemyOranges[3],transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance6.GetComponent<EnemyPathingBlack4>().sixth1 = true;
            enemyBlack4Instance6.GetComponent<EnemyPathingBlack4>().instantiated = true;
        }
    }

    IEnumerator WaitAndInstantiate8() {
        if(blackNow) {
            GameObject enemyBlack4Instance1 = Instantiate(enemyBlack4Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance1.GetComponent<EnemyPathingBlack4>().first2 = true;
            enemyBlack4Instance1.GetComponent<EnemyPathingBlack4>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack4Instance2 = Instantiate(enemyBlack4Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance2.GetComponent<EnemyPathingBlack4>().second2 = true;
            enemyBlack4Instance2.GetComponent<EnemyPathingBlack4>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack4Instance3 = Instantiate(enemyBlack4Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance3.GetComponent<EnemyPathingBlack4>().third2 = true;
            enemyBlack4Instance3.GetComponent<EnemyPathingBlack4>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack4Instance4 = Instantiate(enemyBlack4Prefab,transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance4.GetComponent<EnemyPathingBlack4>().fourth2 = true;
            enemyBlack4Instance4.GetComponent<EnemyPathingBlack4>().instantiated = true;
        }
        if(greenNow) {
            GameObject enemyBlack4Instance1 = Instantiate(enemyGreens[3],transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance1.GetComponent<EnemyPathingBlack4>().first2 = true;
            enemyBlack4Instance1.GetComponent<EnemyPathingBlack4>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack4Instance2 = Instantiate(enemyGreens[3],transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance2.GetComponent<EnemyPathingBlack4>().second2 = true;
            enemyBlack4Instance2.GetComponent<EnemyPathingBlack4>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack4Instance3 = Instantiate(enemyGreens[3],transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance3.GetComponent<EnemyPathingBlack4>().third2 = true;
            enemyBlack4Instance3.GetComponent<EnemyPathingBlack4>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack4Instance4 = Instantiate(enemyGreens[3],transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance4.GetComponent<EnemyPathingBlack4>().fourth2 = true;
            enemyBlack4Instance4.GetComponent<EnemyPathingBlack4>().instantiated = true;
        }
        if(blueNow) {
            GameObject enemyBlack4Instance1 = Instantiate(enemyBlues[3],transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance1.GetComponent<EnemyPathingBlack4>().first2 = true;
            enemyBlack4Instance1.GetComponent<EnemyPathingBlack4>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack4Instance2 = Instantiate(enemyBlues[3],transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance2.GetComponent<EnemyPathingBlack4>().second2 = true;
            enemyBlack4Instance2.GetComponent<EnemyPathingBlack4>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack4Instance3 = Instantiate(enemyBlues[3],transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance3.GetComponent<EnemyPathingBlack4>().third2 = true;
            enemyBlack4Instance3.GetComponent<EnemyPathingBlack4>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack4Instance4 = Instantiate(enemyBlues[3],transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance4.GetComponent<EnemyPathingBlack4>().fourth2 = true;
            enemyBlack4Instance4.GetComponent<EnemyPathingBlack4>().instantiated = true;
        }
        if(orangeNow) {
            GameObject enemyBlack4Instance1 = Instantiate(enemyOranges[3],transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance1.GetComponent<EnemyPathingBlack4>().first2 = true;
            enemyBlack4Instance1.GetComponent<EnemyPathingBlack4>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack4Instance2 = Instantiate(enemyOranges[3],transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance2.GetComponent<EnemyPathingBlack4>().second2 = true;
            enemyBlack4Instance2.GetComponent<EnemyPathingBlack4>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack4Instance3 = Instantiate(enemyOranges[3],transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance3.GetComponent<EnemyPathingBlack4>().third2 = true;
            enemyBlack4Instance3.GetComponent<EnemyPathingBlack4>().instantiated = true;
            yield return new WaitForSeconds(instantiationTime);
            GameObject enemyBlack4Instance4 = Instantiate(enemyOranges[3],transform.position,Quaternion.identity) as GameObject;
            enemyBlack4Instance4.GetComponent<EnemyPathingBlack4>().fourth2 = true;
            enemyBlack4Instance4.GetComponent<EnemyPathingBlack4>().instantiated = true;
        }
    }
}
