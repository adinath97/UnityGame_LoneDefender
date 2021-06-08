using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfiniteInstantiatingManager : MonoBehaviour
{
    [SerializeField] GameObject enemyBlack1Prefab;
    [SerializeField] GameObject enemyBlack2Prefab;
    [SerializeField] GameObject enemyBlack3Prefab;
    [SerializeField] GameObject enemyBlack4Prefab;
    [SerializeField] GameObject enemyBlack5Prefab;
    [SerializeField] List<GameObject> asteroids;
    [SerializeField] List<Transform> asteroidInstantiationPoints;
    [SerializeField] List<Transform> enemyInstantationPoints;
    [SerializeField] float asteroidSpeedMin = -100f;
    [SerializeField] float asteroidSpeedMax = -300f;
    [SerializeField] float asteroidYVelMin = -50f;
    [SerializeField] float asteroidYVelMax = -200f;
    [SerializeField] List<float> asteriodXVelOptions = new List<float>() {-50f,-25f,0,25f,50f};

    public static float pathOneEnemiesTotal = 3,pathTwoEnemiesTotal = 3,pathThreeEnemiesTotal = 5,pathFourEnemiesTotal = 5,pathFiveEnemiesTotal = 9;
    public static float asteroidXVel, asteroidYVel, asteroidSpeed,totalEnemiesDestroyed, pathOneEnemiesDestroyed, pathTwoEnemiesDestroyed,pathThreeEnemiesDestroyed,pathFourEnemiesDestroyed,pathFiveEnemiesDestroyed;
    public static int randomNum, randomNum3, random5, random6, rotationUpperBound;
    public static bool followPlayer, firstWaveCompleted, infiniteGameOver;
    public bool beginGame, asteroidShower, enemiesContinue, incremented;
    private float startingWaitTime = 5f;

    void Awake()
    {
        //reset static bools
        followPlayer = false;
        firstWaveCompleted = false;
        infiniteGameOver = false;

        //reset other bools
        enemiesContinue = true;
        asteroidShower = false;
        beginGame = false;
        incremented = false;

        //reset static ints
        randomNum = 0;
        randomNum3 = 0;
        random5 = 0;
        random6 = 0;

        //reset static floats
        asteroidXVel = 0f;
        asteroidYVel = 0f;
        asteroidSpeed = 0f;
        totalEnemiesDestroyed = 0f;
        pathOneEnemiesDestroyed = 0f;
        pathTwoEnemiesDestroyed = 0f;
        pathThreeEnemiesDestroyed = 0f;
        pathFourEnemiesDestroyed = 0f;
        pathFiveEnemiesDestroyed = 0f;

        //////Debug.Log("HELLO!");
        randomNum = Random.Range(0,20);
        rotationUpperBound = 4;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //////Debug.Log("STARTING NOW");
        //////Debug.Log("asteroidShower is : " + asteroidShower);
        StartCoroutine(WaitAndBeginWaves());
    }

    // Update is called once per frame
    void Update()
    {

        if(infiniteGameOver) {
            infiniteGameOver = false;
            StartCoroutine(WaitAndLoadInfiniteOverScene());
        }
        
        if(!asteroidShower && enemiesContinue) {

            if(pathOneEnemiesDestroyed >= pathOneEnemiesTotal) {
                if(!incremented) {
                    incremented = true;
                    WavesDefeatedManager.wavesDefeated++;
                }
                int random10 = Random.Range(0,20);
                int random11 = Random.Range(0,20);
                if(random10 == random11) {
                    //////Debug.Log("ASTEROID SHOWER TIME!");
                    asteroidShower = true;
                    enemiesContinue = false;
                    return;
                }
            RotateEnemy.angleEnemy = true;
            //////Debug.Log("PATH 1 DONE NOW!");
            randomNum = Random.Range(0,20);
            pathOneEnemiesDestroyed = 0;
            //pick random new enemy, and a random path for new enemy
            int randomNum2 = Random.Range(0,5);
            int randomNum3 = Random.Range(0,5);
            int randomNum4 = Random.Range(0,5);
            if(randomNum3 == randomNum4) {
                followPlayer = true;
            }
            switch(randomNum2) { 
            case 0:
                StartCoroutine(WaitAndInstantiatePath1Wave());
                if(followPlayer) {
                    followPlayer = false;
                    PathOne.followPlayer = true;
                    PathTwo.followPlayer = false;
                    PathThree.followPlayer = false;
                    PathFour.followPlayer = false;
                    PathFive.followPlayer = false;
                }
                break;
            case 1:
                StartCoroutine(WaitAndInstantiatePath2Wave());
                if(followPlayer) {
                    followPlayer = false;
                    PathOne.followPlayer = false;
                    PathTwo.followPlayer = true;
                    PathThree.followPlayer = false;
                    PathFour.followPlayer = false;
                    PathFive.followPlayer = false;
                }
                break;
            case 2:
                StartCoroutine(WaitAndInstantiatePath3Wave());
                if(followPlayer) {
                    followPlayer = false;
                    PathOne.followPlayer = false;
                    PathTwo.followPlayer = false;
                    PathThree.followPlayer = true;
                    PathFour.followPlayer = false;
                    PathFive.followPlayer = false;
                }
                break;
            case 3:
                StartCoroutine(WaitAndInstantiatePath4Wave());
                if(followPlayer) {
                    followPlayer = false;
                    PathOne.followPlayer = false;
                    PathTwo.followPlayer = false;
                    PathThree.followPlayer = false;
                    PathFour.followPlayer = true;
                    PathFive.followPlayer = false;
                }
                break;
            case 4:
                StartCoroutine(WaitAndInstantiatePath5Wave());
                if(followPlayer) {
                    followPlayer = false;
                    PathOne.followPlayer = false;
                    PathTwo.followPlayer = false;
                    PathThree.followPlayer = false;
                    PathFour.followPlayer = false;
                    PathFive.followPlayer = true;
                }
                break;
        }
            incremented = false;
        }

            if(pathTwoEnemiesDestroyed >= pathTwoEnemiesTotal) {
                if(!incremented) {
                    incremented = true;
                    WavesDefeatedManager.wavesDefeated++;
                }
                int random10 = Random.Range(0,20);
                int random11 = Random.Range(0,20);
                if(random10 == random11) {
                    //////Debug.Log("ASTEROID SHOWER TIME!");
                    asteroidShower = true;
                    enemiesContinue = false;
                    return;
                }
            //////Debug.Log("PATH 2 DONE NOW!");
            RotateEnemy.angleEnemy = true;
            randomNum = Random.Range(0,20);
            pathTwoEnemiesDestroyed = 0;
            
            //pick random new enemy, and a random path for new enemy
            int randomNum3 = Random.Range(0,5);
            int randomNum4 = Random.Range(0,5);
            if(randomNum3 == randomNum4) {
                followPlayer = true;
            }
            int randomNum2 = Random.Range(0,5);
        switch(randomNum2) {
            case 0:
                StartCoroutine(WaitAndInstantiatePath1Wave());
                if(followPlayer) {
                    followPlayer = false;
                    PathOne.followPlayer = true;
                    PathTwo.followPlayer = false;
                    PathThree.followPlayer = false;
                    PathFour.followPlayer = false;
                    PathFive.followPlayer = false;
                }
                break;
            case 1:
                StartCoroutine(WaitAndInstantiatePath2Wave());
                if(followPlayer) {
                    followPlayer = false;
                    PathOne.followPlayer = false;
                    PathTwo.followPlayer = true;
                    PathThree.followPlayer = false;
                    PathFour.followPlayer = false;
                    PathFive.followPlayer = false;
                }
                break;
            case 2:
                StartCoroutine(WaitAndInstantiatePath3Wave());
                if(followPlayer) {
                    followPlayer = false;
                    PathOne.followPlayer = false;
                    PathTwo.followPlayer = false;
                    PathThree.followPlayer = true;
                    PathFour.followPlayer = false;
                    PathFive.followPlayer = false;
                }
                break;
            case 3:
                StartCoroutine(WaitAndInstantiatePath4Wave());
                if(followPlayer) {
                    followPlayer = false;
                    PathOne.followPlayer = false;
                    PathTwo.followPlayer = false;
                    PathThree.followPlayer = false;
                    PathFour.followPlayer = true;
                    PathFive.followPlayer = false;
                }
                break;
            case 4:
                StartCoroutine(WaitAndInstantiatePath5Wave());
                if(followPlayer) {
                    followPlayer = false;
                    PathOne.followPlayer = false;
                    PathTwo.followPlayer = false;
                    PathThree.followPlayer = false;
                    PathFour.followPlayer = false;
                    PathFive.followPlayer = true;
                }
                break;
        }
            incremented = false;
        }

            if(pathThreeEnemiesDestroyed >= pathThreeEnemiesTotal) {
                if(!incremented) {
                    incremented = true;
                    WavesDefeatedManager.wavesDefeated++;
                }
                int random10 = Random.Range(0,20);
                int random11 = Random.Range(0,20);
                if(random10 == random11) {
                    //////Debug.Log("ASTEROID SHOWER TIME!");
                    asteroidShower = true;
                    enemiesContinue = false;
                    return;
                }
            RotateEnemy.angleEnemy = true;
            randomNum = Random.Range(0,20);
            pathThreeEnemiesDestroyed = 0;
            
            //pick random new enemy, and a random path for new enemy
            int randomNum3 = Random.Range(0,5);
        int randomNum4 = Random.Range(0,5);
        int randomNum2 = Random.Range(0,5);
        if(randomNum3 == randomNum4) {
            followPlayer = true;
        }
        switch(randomNum2) {
            case 0:
                StartCoroutine(WaitAndInstantiatePath1Wave());
                if(followPlayer) {
                    followPlayer = false;
                    PathOne.followPlayer = true;
                    PathTwo.followPlayer = false;
                    PathThree.followPlayer = false;
                    PathFour.followPlayer = false;
                    PathFive.followPlayer = false;
                }
                break;
            case 1:
                StartCoroutine(WaitAndInstantiatePath2Wave());
                if(followPlayer) {
                    followPlayer = false;
                    PathOne.followPlayer = false;
                    PathTwo.followPlayer = true;
                    PathThree.followPlayer = false;
                    PathFour.followPlayer = false;
                    PathFive.followPlayer = false;
                }
                break;
            case 2:
                StartCoroutine(WaitAndInstantiatePath3Wave());
                if(followPlayer) {
                    followPlayer = false;
                    PathOne.followPlayer = false;
                    PathTwo.followPlayer = false;
                    PathThree.followPlayer = true;
                    PathFour.followPlayer = false;
                    PathFive.followPlayer = false;
                }
                break;
            case 3:
                StartCoroutine(WaitAndInstantiatePath4Wave());
                if(followPlayer) {
                    followPlayer = false;
                    PathOne.followPlayer = false;
                    PathTwo.followPlayer = false;
                    PathThree.followPlayer = false;
                    PathFour.followPlayer = true;
                    PathFive.followPlayer = false;
                }
                break;
            case 4:
                StartCoroutine(WaitAndInstantiatePath5Wave());
                if(followPlayer) {
                    followPlayer = false;
                    PathOne.followPlayer = false;
                    PathTwo.followPlayer = false;
                    PathThree.followPlayer = false;
                    PathFour.followPlayer = false;
                    PathFive.followPlayer = true;
                }
                break;
        }
            incremented = false;
        }

            if(pathFourEnemiesDestroyed >= pathFourEnemiesTotal) {
                if(!incremented) {
                    incremented = true;
                    WavesDefeatedManager.wavesDefeated++;
                }
                int random10 = Random.Range(0,20);
                int random11 = Random.Range(0,20);
                if(random10 == random11) {
                    ////Debug.Log("ASTEROID SHOWER TIME!");
                    asteroidShower = true;
                    enemiesContinue = false;
                    return;
                }
            RotateEnemy.angleEnemy = true;
            randomNum = Random.Range(0,20);
            pathFourEnemiesDestroyed = 0;
            
            //pick random new enemy, and a random path for new enemy
            int randomNum3 = Random.Range(0,5);
        int randomNum4 = Random.Range(0,5);
        int randomNum2 = Random.Range(0,5);
        if(randomNum3 == randomNum4) {
            followPlayer = true;
        }
        switch(randomNum2) {
            case 0:
                StartCoroutine(WaitAndInstantiatePath1Wave());
                if(followPlayer) {
                    followPlayer = false;
                    PathOne.followPlayer = true;
                    PathTwo.followPlayer = false;
                    PathThree.followPlayer = false;
                    PathFour.followPlayer = false;
                    PathFive.followPlayer = false;
                }
                break;
            case 1:
                StartCoroutine(WaitAndInstantiatePath2Wave());
                if(followPlayer) {
                    followPlayer = false;
                    PathOne.followPlayer = false;
                    PathTwo.followPlayer = true;
                    PathThree.followPlayer = false;
                    PathFour.followPlayer = false;
                    PathFive.followPlayer = false;
                }
                break;
            case 2:
                StartCoroutine(WaitAndInstantiatePath3Wave());
                if(followPlayer) {
                    followPlayer = false;
                    PathOne.followPlayer = false;
                    PathTwo.followPlayer = false;
                    PathThree.followPlayer = true;
                    PathFour.followPlayer = false;
                    PathFive.followPlayer = false;
                }
                break;
            case 3:
                StartCoroutine(WaitAndInstantiatePath4Wave());
                if(followPlayer) {
                    followPlayer = false;
                    PathOne.followPlayer = false;
                    PathTwo.followPlayer = false;
                    PathThree.followPlayer = false;
                    PathFour.followPlayer = true;
                    PathFive.followPlayer = false;
                }
                break;
            case 4:
                StartCoroutine(WaitAndInstantiatePath5Wave());
                if(followPlayer) {
                    followPlayer = false;
                    PathOne.followPlayer = false;
                    PathTwo.followPlayer = false;
                    PathThree.followPlayer = false;
                    PathFour.followPlayer = false;
                    PathFive.followPlayer = true;
                }
                break;
        }
            incremented = false;
        }

            if(pathFiveEnemiesDestroyed >= pathFiveEnemiesTotal) {
                if(!incremented) {
                    incremented = true;
                    WavesDefeatedManager.wavesDefeated++;
                }
                int random10 = Random.Range(0,20);
                int random11 = Random.Range(0,20);
                if(random10 == random11) {
                    //////Debug.Log("ASTEROID SHOWER TIME!");
                    asteroidShower = true;
                    enemiesContinue = false;
                    return;
                }
            RotateEnemy.angleEnemy = true;
            randomNum = Random.Range(0,20);
            pathFiveEnemiesDestroyed = 0;
            //pick random new enemy, and a random path for new enemy
            int randomNum3 = Random.Range(0,5);
            int randomNum4 = Random.Range(0,5);
            int randomNum2 = Random.Range(0,5);
            if(randomNum3 == randomNum4) {
                followPlayer = true;
            }
            switch(randomNum2) {
                case 0:
                    StartCoroutine(WaitAndInstantiatePath1Wave());
                    if(followPlayer) {
                        followPlayer = false;
                        PathOne.followPlayer = true;
                        PathTwo.followPlayer = false;
                        PathThree.followPlayer = false;
                        PathFour.followPlayer = false;
                        PathFive.followPlayer = false;
                    }
                break;
            case 1:
                StartCoroutine(WaitAndInstantiatePath2Wave());
                if(followPlayer) {
                    followPlayer = false;
                    PathOne.followPlayer = false;
                    PathTwo.followPlayer = true;
                    PathThree.followPlayer = false;
                    PathFour.followPlayer = false;
                    PathFive.followPlayer = false;
                }
                break;
            case 2:
                StartCoroutine(WaitAndInstantiatePath3Wave());
                if(followPlayer) {
                    followPlayer = false;
                    PathOne.followPlayer = false;
                    PathTwo.followPlayer = false;
                    PathThree.followPlayer = true;
                    PathFour.followPlayer = false;
                    PathFive.followPlayer = false;
                }
                break;
            case 3:
                StartCoroutine(WaitAndInstantiatePath4Wave());
                if(followPlayer) {
                    followPlayer = false;
                    PathOne.followPlayer = false;
                    PathTwo.followPlayer = false;
                    PathThree.followPlayer = false;
                    PathFour.followPlayer = true;
                    PathFive.followPlayer = false;
                }
                break;
            case 4:
                StartCoroutine(WaitAndInstantiatePath5Wave());
                if(followPlayer) {
                    followPlayer = false;
                    PathOne.followPlayer = false;
                    PathTwo.followPlayer = false;
                    PathThree.followPlayer = false;
                    PathFour.followPlayer = false;
                    PathFive.followPlayer = true;
                }
                break;
        }
            incremented = false;
        }
        }
        
        if(asteroidShower) {
            //////Debug.Log("STARTING SHOWER");
            ScoreManager.activateMeteorWarning = true;
            asteroidShower = false;
            int rand15 = Random.Range(0,3);
            switch(rand15) {
                case 0:
                    StartCoroutine(WaitAndLaunchAsteroids1());
                    break;
                case 1:
                    StartCoroutine(WaitAndLaunchAsteroids2());
                    break;
                case 2:
                    StartCoroutine(WaitAndLaunchAsteroids3());
                    break;
            }
        }
    }
    IEnumerator WaitAndLaunchAsteroids1() {
        int rand1 = 0, rand2 = 0, rand3 = 0;
        yield return new WaitForSeconds(3.5f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance1 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance2 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance3 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance4 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance5 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance6 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance7 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance8 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance9 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance10 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance11 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance12 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        yield return new WaitForSeconds(4f);
        enemiesContinue = true;
    }

    IEnumerator WaitAndLaunchAsteroids2() {
        int rand1 = 0, rand2 = 0, rand3 = 0;
        yield return new WaitForSeconds(3.5f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance1 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance1.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance2 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance2.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance3 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance3.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance4 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance4.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance5 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance5.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance6 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance6.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance7 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance7.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance8 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance8.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance9 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance9.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(3f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance10 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance10.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance11 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance11.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance12 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance12.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance13 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance13.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance14 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance14.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance15 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance15.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance16 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance16.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance17 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance17.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance18 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance18.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(4f);
        enemiesContinue = true;
    }

    IEnumerator WaitAndLaunchAsteroids3() {
        int rand1 = 0, rand2 = 0, rand3 = 0;
        yield return new WaitForSeconds(3.5f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance1 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance1.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance2 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance2.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance3 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance3.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance4 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance4.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance5 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance5.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance6 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance6.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance7 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance7.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance8 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance8.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance9 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance9.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance10 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance10.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance11 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance11.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance12 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance12.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance13 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance13.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance14 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance14.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance15 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance15.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance16 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance16.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance17 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance17.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance18 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance18.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance19 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance19.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance20 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance20.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance21 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance21.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance22 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance22.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance23 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance23.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,asteroids.Count);
        rand2 = Random.Range(0,asteroidInstantiationPoints.Count);
        rand3 = Random.Range(0,asteriodXVelOptions.Count);
        asteroidSpeed = Random.Range(asteroidSpeedMin,asteroidSpeedMax);
        asteroidXVel = asteriodXVelOptions[rand3];
        asteroidYVel = Random.Range(asteroidYVelMin,asteroidYVelMax);
        GameObject asteroidInstance24 = Instantiate(asteroids[rand1],asteroidInstantiationPoints[rand2].transform.position,Quaternion.identity) as GameObject;
        //asteroidInstance24.GetComponent<Rigidbody2D>().velocity = new Vector2(asteroidXVel * Time.deltaTime,asteroidYVel * Time.deltaTime);
        yield return new WaitForSeconds(4f);
        enemiesContinue = true;
    }

    IEnumerator WaitAndLoadInfiniteOverScene() {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("InfiniteOverScene");
    }

    IEnumerator WaitAndBeginWaves() {
        yield return new WaitForSeconds(startingWaitTime);
        RotateEnemy.angleEnemy = true;
        pathOneEnemiesDestroyed = 0;
        pathTwoEnemiesDestroyed = 0;
        int randomNum2 = Random.Range(0,5);
        //////Debug.Log("INSTANTIATING NOW");
        int randomNum3 = Random.Range(0,5);
        int randomNum4 = Random.Range(0,5);
        if(randomNum3 == randomNum4) {
            followPlayer = true;
        }
        switch(randomNum2) {
        case 0:
            StartCoroutine(WaitAndInstantiatePath1Wave());
            if(followPlayer) {
                followPlayer = false;
                PathOne.followPlayer = true;
                PathTwo.followPlayer = false;
                PathThree.followPlayer = false;
                PathFour.followPlayer = false;
                PathFive.followPlayer = false;
            }
            break;
        case 1:
            StartCoroutine(WaitAndInstantiatePath2Wave());
            if(followPlayer) {
                followPlayer = false;
                PathOne.followPlayer = false;
                PathTwo.followPlayer = true;
                PathThree.followPlayer = false;
                PathFour.followPlayer = false;
                PathFive.followPlayer = false;
            }
            break;
        case 2:
            StartCoroutine(WaitAndInstantiatePath3Wave());
            if(followPlayer) {
                followPlayer = false;
                PathOne.followPlayer = false;
                PathTwo.followPlayer = false;
                PathThree.followPlayer = true;
                PathFour.followPlayer = false;
                PathFive.followPlayer = false;
            }
            break;
        case 3:
            StartCoroutine(WaitAndInstantiatePath4Wave());
            if(followPlayer) {
                followPlayer = false;
                PathOne.followPlayer = false;
                PathTwo.followPlayer = false;
                PathThree.followPlayer = false;
                PathFour.followPlayer = true;
                PathFive.followPlayer = false;
            }
            break;
        case 4:
            StartCoroutine(WaitAndInstantiatePath5Wave());
            if(followPlayer) {
                followPlayer = false;
                PathOne.followPlayer = false;
                PathTwo.followPlayer = false;
                PathThree.followPlayer = false;
                PathFour.followPlayer = false;
                PathFive.followPlayer = true;
            }
            break;
    }
    }

    IEnumerator WaitAndInstantiatePath1Wave() {
        int rand1 =  0;
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,enemyInstantationPoints.Count);
        GameObject enemyInstance1 = Instantiate(enemyBlack1Prefab,enemyInstantationPoints[rand1].transform.position,Quaternion.identity) as GameObject;
        enemyInstance1.GetComponent<EnemyBlack1Infinite>().pathOne1 = true;
        enemyInstance1.GetComponent<EnemyBlack1Infinite>().instantiated = true;
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,enemyInstantationPoints.Count);
        GameObject enemyInstance2 = Instantiate(enemyBlack1Prefab,enemyInstantationPoints[rand1].transform.position,Quaternion.identity) as GameObject;
        enemyInstance2.GetComponent<EnemyBlack1Infinite>().pathOne2 = true;
        enemyInstance2.GetComponent<EnemyBlack1Infinite>().instantiated = true;
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,enemyInstantationPoints.Count);
        GameObject enemyInstance3 = Instantiate(enemyBlack1Prefab,enemyInstantationPoints[rand1].transform.position,Quaternion.identity) as GameObject;
        enemyInstance3.GetComponent<EnemyBlack1Infinite>().pathOne3 = true;
        enemyInstance3.GetComponent<EnemyBlack1Infinite>().instantiated = true;
    }

    IEnumerator WaitAndInstantiatePath2Wave() {
        int rand1 = 0;
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,enemyInstantationPoints.Count);
        GameObject enemyInstance1 = Instantiate(enemyBlack2Prefab,enemyInstantationPoints[rand1].transform.position,Quaternion.identity) as GameObject;
        enemyInstance1.GetComponent<EnemyBlack2Infinite>().pathTwo1 = true;
        enemyInstance1.GetComponent<EnemyBlack2Infinite>().instantiated = true;
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,enemyInstantationPoints.Count);
        GameObject enemyInstance2 = Instantiate(enemyBlack2Prefab,enemyInstantationPoints[rand1].transform.position,Quaternion.identity) as GameObject;
        enemyInstance2.GetComponent<EnemyBlack2Infinite>().pathTwo2 = true;
        enemyInstance2.GetComponent<EnemyBlack2Infinite>().instantiated = true;
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,enemyInstantationPoints.Count);
        GameObject enemyInstance3 = Instantiate(enemyBlack2Prefab,enemyInstantationPoints[rand1].transform.position,Quaternion.identity) as GameObject;
        enemyInstance3.GetComponent<EnemyBlack2Infinite>().pathTwo3 = true;
        enemyInstance3.GetComponent<EnemyBlack2Infinite>().instantiated = true;
    }

    IEnumerator WaitAndInstantiatePath3Wave() {
        int rand1 = 0;
        yield return new WaitForSeconds(1f);
        GameObject enemyInstance1 = Instantiate(enemyBlack3Prefab,enemyInstantationPoints[rand1].transform.position,Quaternion.identity) as GameObject;
        enemyInstance1.GetComponent<EnemyBlack3Infinite>().pathThree1 = true;
        enemyInstance1.GetComponent<EnemyBlack3Infinite>().instantiated = true;
        yield return new WaitForSeconds(1f);
        GameObject enemyInstance2 = Instantiate(enemyBlack3Prefab,enemyInstantationPoints[rand1].transform.position,Quaternion.identity) as GameObject;
        enemyInstance2.GetComponent<EnemyBlack3Infinite>().pathThree2 = true;
        enemyInstance2.GetComponent<EnemyBlack3Infinite>().instantiated = true;
        yield return new WaitForSeconds(1f);
        GameObject enemyInstance3 = Instantiate(enemyBlack3Prefab,enemyInstantationPoints[rand1].transform.position,Quaternion.identity) as GameObject;
        enemyInstance3.GetComponent<EnemyBlack3Infinite>().pathThree3 = true;
        enemyInstance3.GetComponent<EnemyBlack3Infinite>().instantiated = true;
        yield return new WaitForSeconds(1f);
        GameObject enemyInstance4 = Instantiate(enemyBlack3Prefab,enemyInstantationPoints[3].transform.position,Quaternion.identity) as GameObject;
        enemyInstance4.GetComponent<EnemyBlack3Infinite>().pathThree4 = true;
        enemyInstance4.GetComponent<EnemyBlack3Infinite>().instantiated = true;
        yield return new WaitForSeconds(1f);
        GameObject enemyInstance5 = Instantiate(enemyBlack3Prefab,enemyInstantationPoints[4].transform.position,Quaternion.identity) as GameObject;
        enemyInstance5.GetComponent<EnemyBlack3Infinite>().pathThree5 = true;
        enemyInstance5.GetComponent<EnemyBlack3Infinite>().instantiated = true;
    }

    IEnumerator WaitAndInstantiatePath4Wave() {
        int rand1 = 0;
        yield return new WaitForSeconds(1f);
        GameObject enemyInstance1 = Instantiate(enemyBlack4Prefab,enemyInstantationPoints[rand1].transform.position,Quaternion.identity) as GameObject;
        enemyInstance1.GetComponent<EnemyBlack4Infinite>().pathFour1 = true;
        enemyInstance1.GetComponent<EnemyBlack4Infinite>().instantiated = true;
        yield return new WaitForSeconds(1f);
        GameObject enemyInstance2 = Instantiate(enemyBlack4Prefab,enemyInstantationPoints[rand1].transform.position,Quaternion.identity) as GameObject;
        enemyInstance2.GetComponent<EnemyBlack4Infinite>().pathFour2 = true;
        enemyInstance2.GetComponent<EnemyBlack4Infinite>().instantiated = true;
        yield return new WaitForSeconds(1f);
        GameObject enemyInstance3 = Instantiate(enemyBlack4Prefab,enemyInstantationPoints[rand1].transform.position,Quaternion.identity) as GameObject;
        enemyInstance3.GetComponent<EnemyBlack4Infinite>().pathFour3 = true;
        enemyInstance3.GetComponent<EnemyBlack4Infinite>().instantiated = true;
        yield return new WaitForSeconds(1f);
        GameObject enemyInstance4 = Instantiate(enemyBlack4Prefab,enemyInstantationPoints[rand1].transform.position,Quaternion.identity) as GameObject;
        enemyInstance4.GetComponent<EnemyBlack4Infinite>().pathFour4 = true;
        enemyInstance4.GetComponent<EnemyBlack4Infinite>().instantiated = true;
        yield return new WaitForSeconds(1f);
        GameObject enemyInstance5 = Instantiate(enemyBlack4Prefab,enemyInstantationPoints[rand1].transform.position,Quaternion.identity) as GameObject;
        enemyInstance5.GetComponent<EnemyBlack4Infinite>().pathFour5 = true;
        enemyInstance5.GetComponent<EnemyBlack4Infinite>().instantiated = true;
    }

    IEnumerator WaitAndInstantiatePath5Wave() {
        int rand1 = 0;
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,enemyInstantationPoints.Count);
        GameObject enemyInstance1 = Instantiate(enemyBlack5Prefab,enemyInstantationPoints[rand1].transform.position,Quaternion.identity) as GameObject;
        enemyInstance1.GetComponent<EnemyBlack5Infinite>().pathFive1 = true;
        enemyInstance1.GetComponent<EnemyBlack5Infinite>().instantiated = true;
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,enemyInstantationPoints.Count);
        GameObject enemyInstance2 = Instantiate(enemyBlack5Prefab,enemyInstantationPoints[rand1].transform.position,Quaternion.identity) as GameObject;
        enemyInstance2.GetComponent<EnemyBlack5Infinite>().pathFive2 = true;
        enemyInstance2.GetComponent<EnemyBlack5Infinite>().instantiated = true;
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,enemyInstantationPoints.Count);
        GameObject enemyInstance3 = Instantiate(enemyBlack5Prefab,enemyInstantationPoints[rand1].transform.position,Quaternion.identity) as GameObject;
        enemyInstance3.GetComponent<EnemyBlack5Infinite>().pathFive3 = true;
        enemyInstance3.GetComponent<EnemyBlack5Infinite>().instantiated = true;
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,enemyInstantationPoints.Count);
        GameObject enemyInstance4 = Instantiate(enemyBlack5Prefab,enemyInstantationPoints[rand1].transform.position,Quaternion.identity) as GameObject;
        enemyInstance4.GetComponent<EnemyBlack5Infinite>().pathFive4 = true;
        enemyInstance4.GetComponent<EnemyBlack5Infinite>().instantiated = true;
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,enemyInstantationPoints.Count);
        GameObject enemyInstance5 = Instantiate(enemyBlack5Prefab,enemyInstantationPoints[rand1].transform.position,Quaternion.identity) as GameObject;
        enemyInstance5.GetComponent<EnemyBlack5Infinite>().pathFive5 = true;
        enemyInstance5.GetComponent<EnemyBlack5Infinite>().instantiated = true;
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,enemyInstantationPoints.Count);
        GameObject enemyInstance6 = Instantiate(enemyBlack5Prefab,enemyInstantationPoints[rand1].transform.position,Quaternion.identity) as GameObject;
        enemyInstance6.GetComponent<EnemyBlack5Infinite>().pathFive6 = true;
        enemyInstance6.GetComponent<EnemyBlack5Infinite>().instantiated = true;
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,enemyInstantationPoints.Count);
        GameObject enemyInstance7 = Instantiate(enemyBlack5Prefab,enemyInstantationPoints[rand1].transform.position,Quaternion.identity) as GameObject;
        enemyInstance7.GetComponent<EnemyBlack5Infinite>().pathFive7 = true;
        enemyInstance7.GetComponent<EnemyBlack5Infinite>().instantiated = true;
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,enemyInstantationPoints.Count);
        GameObject enemyInstance8 = Instantiate(enemyBlack5Prefab,enemyInstantationPoints[rand1].transform.position,Quaternion.identity) as GameObject;
        enemyInstance8.GetComponent<EnemyBlack5Infinite>().pathFive8 = true;
        enemyInstance8.GetComponent<EnemyBlack5Infinite>().instantiated = true;
        yield return new WaitForSeconds(1f);
        rand1 = Random.Range(0,enemyInstantationPoints.Count);
        GameObject enemyInstance9 = Instantiate(enemyBlack5Prefab,enemyInstantationPoints[rand1].transform.position,Quaternion.identity) as GameObject;
        enemyInstance9.GetComponent<EnemyBlack5Infinite>().pathFive9 = true;
        enemyInstance9.GetComponent<EnemyBlack5Infinite>().instantiated = true;
    }

}
