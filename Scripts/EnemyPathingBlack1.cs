using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathingBlack1 : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints1;
    [SerializeField] List<Transform> waypoints2;
    [SerializeField] List<Transform> waypoints3;
    [SerializeField] GameObject enemyLaserPrefab;
    [SerializeField] float moveSpeed;
    [SerializeField] float initialMoveSpeed = 15f;
    [SerializeField] float laserMoveSpeed;
    [SerializeField] GameObject deathExplosion;
    [SerializeField] AudioClip[] enemySounds;
    AudioSource myAudioSource;
    int waypointIndex = 0;
    bool dead,hit, allowHit, increasedAlready, normalize, targetReached;

    float firstTimer1,secondTimer1,thirdTimer1,fourthTimer1,
    firstTimer2,secondTimer2,thirdTimer2,fourthTimer2,
    firstTimer3,secondTimer3,thirdTimer3,fourthTimer3,
    firstTimer4,secondTimer4,thirdTimer4,fourthTimer4,
    minTimeToFire, maxTimeToFire, movementThisFrame;

    float firstTimerCap1,secondTimerCap1,thirdTimerCap1,fourthTimerCap1,
    firstTimerCap2,secondTimerCap2,thirdTimerCap2,fourthTimerCap2,
    firstTimerCap3,secondTimerCap3,thirdTimerCap3,fourthTimerCap3,
    firstTimerCap4,secondTimerCap4,thirdTimerCap4,fourthTimerCap4;

    public bool instantiated,first1,second1,third1,fourth1,first2,second2,third2,fourth2,first3,second3,third3,fourth3;

    void Awake()
    {
        dead = false;
        myAudioSource = this.GetComponent<AudioSource>();
        this.transform.GetChild(0).gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        InitialSetUp();
    }

    // Update is called once per frame

    void Update()
    {
        EnemyFireTimers();
        EnemyMovementAndFiring();
    }
    

    void EnemyMovementAndFiring() {
        if(this.targetReached) {
            this.allowHit = true;
        }
        if(first1) {
            if(waypointIndex < waypoints1.Count) {
                var targetPosition = waypoints1[waypointIndex].transform.position;
                if(!targetReached) {
                    movementThisFrame = initialMoveSpeed * Time.deltaTime;
                }
                else if(targetReached) {
                    movementThisFrame = moveSpeed * Time.deltaTime;
                }
                if(!hit) {
                    transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
                }
                if(targetPosition == transform.position) {
                    waypointIndex++;
                }
            }
            else {
                if(EnemyInstantiatingManager.wave1TotalLaunched == 0) {
                    EnemyInstantiatingManager.wave1TotalLaunched++;
                }
                targetReached = true;
                ////this.transform.GetChild(0).gameObject.SetActive(false);
                if(firstTimer1 >= firstTimerCap1 && !hit) {
                    firstTimer1 = 0f;
                    firstTimerCap1 = Random.Range(minTimeToFire,maxTimeToFire);
                    GameObject laserInstance = Instantiate(enemyLaserPrefab,transform.position,Quaternion.identity) as GameObject;
                    laserInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,laserMoveSpeed * Time.deltaTime);
                    AudioClip clip = enemySounds[0];
                    myAudioSource.PlayOneShot(clip);
                } 
            }
        }
        if(second1) {
            if(waypointIndex < waypoints1.Count - 1) {
                var targetPosition = waypoints1[waypointIndex].transform.position;
                
                if(!targetReached) {
                    movementThisFrame = initialMoveSpeed * Time.deltaTime;
                }
                else if(targetReached) {
                    movementThisFrame = moveSpeed * Time.deltaTime;
                }
                if(!hit) {
                    transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
                }
                if(targetPosition == transform.position) {
                    waypointIndex++;
                }
            }
            else {
                if(EnemyInstantiatingManager.wave1TotalLaunched == 1) {
                    EnemyInstantiatingManager.wave1TotalLaunched++;
                }
                targetReached = true;
                ////this.transform.GetChild(0).gameObject.SetActive(false);
                if(secondTimer1 >= secondTimerCap1 && !hit) {
                    secondTimer1 = 0f;
                    secondTimerCap1 = Random.Range(minTimeToFire,maxTimeToFire);
                    GameObject laserInstance = Instantiate(enemyLaserPrefab,transform.position,Quaternion.identity) as GameObject;
                    laserInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,laserMoveSpeed * Time.deltaTime);
                    AudioClip clip = enemySounds[0];
                myAudioSource.PlayOneShot(clip);
                } 
            } 
        }
        if(third1) {
            if(waypointIndex < waypoints1.Count - 2) {
                var targetPosition = waypoints1[waypointIndex].transform.position;
                
                if(!targetReached) {
                    movementThisFrame = initialMoveSpeed * Time.deltaTime;
                }
                else if(targetReached) {
                    movementThisFrame = moveSpeed * Time.deltaTime;
                }
                if(!hit) {
                    transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
                }
                if(targetPosition == transform.position) {
                    waypointIndex++;
                }
            }
            else {
                if(EnemyInstantiatingManager.wave1TotalLaunched == 2) {
                    EnemyInstantiatingManager.wave1TotalLaunched++;
                }
                targetReached = true;
                ////this.transform.GetChild(0).gameObject.SetActive(false);
                if(thirdTimer1 >= thirdTimerCap1 && !hit) {
                    thirdTimer1 = 0f;
                    thirdTimerCap1 = Random.Range(minTimeToFire,maxTimeToFire);
                    GameObject laserInstance = Instantiate(enemyLaserPrefab,transform.position,Quaternion.identity) as GameObject;
                    laserInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,laserMoveSpeed * Time.deltaTime);
                    AudioClip clip = enemySounds[0];
                myAudioSource.PlayOneShot(clip);
                } 
            }
        }
        if(fourth1) {
            if(waypointIndex < waypoints1.Count - 3) {
                var targetPosition = waypoints1[waypointIndex].transform.position;
                
                if(!targetReached) {
                    movementThisFrame = initialMoveSpeed * Time.deltaTime;
                }
                else if(targetReached) {
                    movementThisFrame = moveSpeed * Time.deltaTime;
                }
                if(!hit) {
                    transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
                }
                if(targetPosition == transform.position) {
                    waypointIndex++;
                }
            }
            else {
                if(EnemyInstantiatingManager.wave1TotalLaunched == 3) {
                    EnemyInstantiatingManager.wave1TotalLaunched++;
                }
                targetReached = true;
                ////this.transform.GetChild(0).gameObject.SetActive(false);
                if(fourthTimer1 >= fourthTimerCap1 && !hit) {
                    fourthTimer1 = 0f;
                    fourthTimerCap1 = Random.Range(minTimeToFire,maxTimeToFire);
                    GameObject laserInstance = Instantiate(enemyLaserPrefab,transform.position,Quaternion.identity) as GameObject;
                    laserInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,laserMoveSpeed * Time.deltaTime);
                    AudioClip clip = enemySounds[0];
                    myAudioSource.PlayOneShot(clip);
                } 
            }
        }
        
        if(first2) {
            if(waypointIndex < waypoints2.Count) {
                var targetPosition = waypoints2[waypointIndex].transform.position;
                
                if(!targetReached) {
                    movementThisFrame = initialMoveSpeed * Time.deltaTime;
                }
                else if(targetReached) {
                    movementThisFrame = moveSpeed * Time.deltaTime;
                }
                if(!hit) {
                    transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
                }
                if(targetPosition == transform.position) {
                    waypointIndex++;
                }
            }
            else {
                if(EnemyInstantiatingManager.wave1TotalLaunched == 4) {
                    EnemyInstantiatingManager.wave1TotalLaunched++;
                }
                targetReached = true;
                ////this.transform.GetChild(0).gameObject.SetActive(false);
                if(firstTimer2 >= firstTimerCap2 && !hit) {
                    firstTimer2 = 0f;
                    firstTimerCap2 = Random.Range(minTimeToFire,maxTimeToFire);
                    GameObject laserInstance = Instantiate(enemyLaserPrefab,transform.position,Quaternion.identity) as GameObject;
                    laserInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,laserMoveSpeed * Time.deltaTime);
                    AudioClip clip = enemySounds[0];
                myAudioSource.PlayOneShot(clip);
                } 
            }
        }
        if(second2) {
            if(waypointIndex < waypoints2.Count - 1) {
                var targetPosition = waypoints2[waypointIndex].transform.position;
                
                if(!targetReached) {
                    movementThisFrame = initialMoveSpeed * Time.deltaTime;
                }
                else if(targetReached) {
                    movementThisFrame = moveSpeed * Time.deltaTime;
                }
                if(!hit) {
                    transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
                }
                if(targetPosition == transform.position) {
                    waypointIndex++;
                }
            }
            else {
                if(EnemyInstantiatingManager.wave1TotalLaunched == 5) {
                    EnemyInstantiatingManager.wave1TotalLaunched++;
                }
                targetReached = true;
                ////this.transform.GetChild(0).gameObject.SetActive(false);
                if(secondTimer2 >= secondTimerCap2 && !hit) {
                    secondTimer2 = 0f;
                    secondTimerCap2 = Random.Range(minTimeToFire,maxTimeToFire);
                    GameObject laserInstance = Instantiate(enemyLaserPrefab,transform.position,Quaternion.identity) as GameObject;
                    laserInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,laserMoveSpeed * Time.deltaTime);
                    AudioClip clip = enemySounds[0];
                myAudioSource.PlayOneShot(clip);
                } 
            } 
        }
        if(third2) {
            if(waypointIndex < waypoints2.Count - 2) {
                var targetPosition = waypoints2[waypointIndex].transform.position;
                
                if(!targetReached) {
                    movementThisFrame = initialMoveSpeed * Time.deltaTime;
                }
                else if(targetReached) {
                    movementThisFrame = moveSpeed * Time.deltaTime;
                }
                if(!hit) {
                    transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
                }
                if(targetPosition == transform.position) {
                    waypointIndex++;
                }
            }
            else {
                targetReached = true;
                if(EnemyInstantiatingManager.wave1TotalLaunched == 6) {
                    EnemyInstantiatingManager.wave1TotalLaunched++;
                }
                ////this.transform.GetChild(0).gameObject.SetActive(false);
                if(thirdTimer2 >= thirdTimerCap2 && !hit) {
                    thirdTimer2 = 0f;
                    thirdTimerCap2 = Random.Range(minTimeToFire,maxTimeToFire);
                    GameObject laserInstance = Instantiate(enemyLaserPrefab,transform.position,Quaternion.identity) as GameObject;
                    laserInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,laserMoveSpeed * Time.deltaTime);
                    AudioClip clip = enemySounds[0];
                myAudioSource.PlayOneShot(clip);
                } 
            }
        }
        if(fourth2) {
            if(waypointIndex < waypoints2.Count - 3) {
                var targetPosition = waypoints2[waypointIndex].transform.position;
                
                if(!targetReached) {
                    movementThisFrame = initialMoveSpeed * Time.deltaTime;
                }
                else if(targetReached) {
                    movementThisFrame = moveSpeed * Time.deltaTime;
                }
                if(!hit) {
                    transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
                }
                if(targetPosition == transform.position) {
                    waypointIndex++;
                }
            }
            else {
                if(EnemyInstantiatingManager.wave1TotalLaunched == 7) {
                    EnemyInstantiatingManager.wave1TotalLaunched++;
                }
                targetReached = true;
                ////this.transform.GetChild(0).gameObject.SetActive(false);
                if(fourthTimer2 >= fourthTimerCap2 && !hit) {
                    fourthTimer2 = 0f;
                    fourthTimerCap2 = Random.Range(minTimeToFire,maxTimeToFire);
                    GameObject laserInstance = Instantiate(enemyLaserPrefab,transform.position,Quaternion.identity) as GameObject;
                    laserInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,laserMoveSpeed * Time.deltaTime);
                    AudioClip clip = enemySounds[0];
                myAudioSource.PlayOneShot(clip);
                } 
            }
        }
        
        if(first3) {
            if(waypointIndex < waypoints2.Count) {
                var targetPosition = waypoints3[waypointIndex].transform.position;
                
                if(!targetReached) {
                    movementThisFrame = initialMoveSpeed * Time.deltaTime;
                }
                else if(targetReached) {
                    movementThisFrame = moveSpeed * Time.deltaTime;
                }
                if(!hit) {
                    transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
                }
                if(targetPosition == transform.position) {
                    waypointIndex++;
                }
            }
            else {
                if(EnemyInstantiatingManager.wave1TotalLaunched == 8) {
                    EnemyInstantiatingManager.wave1TotalLaunched++;
                }
                targetReached = true;
                ////this.transform.GetChild(0).gameObject.SetActive(false);
                if(firstTimer3 >= firstTimerCap3 && !hit) {
                    firstTimer3 = 0f;
                    firstTimerCap3 = Random.Range(minTimeToFire,maxTimeToFire);
                    GameObject laserInstance = Instantiate(enemyLaserPrefab,transform.position,Quaternion.identity) as GameObject;
                    laserInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,laserMoveSpeed * Time.deltaTime);
                    AudioClip clip = enemySounds[0];
                myAudioSource.PlayOneShot(clip);
                } 
            }
        }
        if(second3) {
            if(waypointIndex < waypoints2.Count - 1) {
                var targetPosition = waypoints3[waypointIndex].transform.position;
                
                if(!targetReached) {
                    movementThisFrame = initialMoveSpeed * Time.deltaTime;
                }
                else if(targetReached) {
                    movementThisFrame = moveSpeed * Time.deltaTime;
                }
                if(!hit) {
                    transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
                }
                if(targetPosition == transform.position) {
                    waypointIndex++;
                }
            }
            else {
                if(EnemyInstantiatingManager.wave1TotalLaunched == 9) {
                    EnemyInstantiatingManager.wave1TotalLaunched++;
                }
                targetReached = true;
                ////this.transform.GetChild(0).gameObject.SetActive(false);
                if(secondTimer3 >= secondTimerCap3 && !hit) {
                    secondTimer3 = 0f;
                    secondTimerCap3 = Random.Range(minTimeToFire,maxTimeToFire);
                    GameObject laserInstance = Instantiate(enemyLaserPrefab,transform.position,Quaternion.identity) as GameObject;
                    laserInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,laserMoveSpeed * Time.deltaTime);
                    AudioClip clip = enemySounds[0];
                myAudioSource.PlayOneShot(clip);
                } 
            } 
        }
        if(third3) {
            if(waypointIndex < waypoints2.Count - 2) {
                var targetPosition = waypoints3[waypointIndex].transform.position;
                
                if(!targetReached) {
                    movementThisFrame = initialMoveSpeed * Time.deltaTime;
                }
                else if(targetReached) {
                    movementThisFrame = moveSpeed * Time.deltaTime;
                }
                if(!hit) {
                    transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
                }
                if(targetPosition == transform.position) {
                    waypointIndex++;
                }
            }
            else {
                if(EnemyInstantiatingManager.wave1TotalLaunched == 10) {
                    EnemyInstantiatingManager.wave1TotalLaunched++;
                }
                targetReached = true;
                ////this.transform.GetChild(0).gameObject.SetActive(false);
                if(thirdTimer3 >= thirdTimerCap3 && !hit) {
                    thirdTimer3 = 0f;
                    thirdTimerCap3 = Random.Range(minTimeToFire,maxTimeToFire);
                    GameObject laserInstance = Instantiate(enemyLaserPrefab,transform.position,Quaternion.identity) as GameObject;
                    laserInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,laserMoveSpeed * Time.deltaTime);
                    AudioClip clip = enemySounds[0];
                myAudioSource.PlayOneShot(clip);
                } 
            }
        }
        if(fourth3) {
            if(waypointIndex < waypoints2.Count - 3) {
                var targetPosition = waypoints3[waypointIndex].transform.position;
                
                if(!targetReached) {
                    movementThisFrame = initialMoveSpeed * Time.deltaTime;
                }
                else if(targetReached) {
                    movementThisFrame = moveSpeed * Time.deltaTime;
                }
                if(!hit) {
                    transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
                }
                if(targetPosition == transform.position) {
                    waypointIndex++;
                }
            }
            else {
                if(EnemyInstantiatingManager.wave1TotalLaunched == 10) {
                    EnemyInstantiatingManager.wave1TotalLaunched++;
                }
                targetReached = true;
                ////this.transform.GetChild(0).gameObject.SetActive(false);
                if(fourthTimer3 >= fourthTimerCap3 && !hit) {
                    fourthTimer3 = 0f;
                    fourthTimerCap3 = Random.Range(minTimeToFire,maxTimeToFire);
                    GameObject laserInstance = Instantiate(enemyLaserPrefab,transform.position,Quaternion.identity) as GameObject;
                    laserInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,laserMoveSpeed * Time.deltaTime);
                    AudioClip clip = enemySounds[0];
                myAudioSource.PlayOneShot(clip);
                } 
            }
        }
        
    }

    void EnemyFireTimers() {
            firstTimer1 += Time.deltaTime;
            firstTimer2 += Time.deltaTime;
            firstTimer3 += Time.deltaTime;
            firstTimer4 += Time.deltaTime;

            secondTimer1 += Time.deltaTime;
            secondTimer2 += Time.deltaTime;
            secondTimer3 += Time.deltaTime;
            secondTimer4 += Time.deltaTime;

            thirdTimer1 += Time.deltaTime;
            thirdTimer2 += Time.deltaTime;
            thirdTimer3 += Time.deltaTime;
            thirdTimer4 += Time.deltaTime;
            
            fourthTimer1 += Time.deltaTime;
            fourthTimer2 += Time.deltaTime;
            fourthTimer3 += Time.deltaTime;
            fourthTimer4 += Time.deltaTime;
        
    }

    void InitialSetUp() {
        this.GetComponent<Animator>().SetBool("isArriving",true);
        targetReached = false;
        //StartCoroutine(WaitAndEndArrivalRoutine());
        if(this.gameObject.tag == "enemyBlack") {
            ////Debug.Log("SET?!");
            minTimeToFire = 1f;
            maxTimeToFire = 10f;
        }
        else if(this.gameObject.tag == "enemyGreen") {
            minTimeToFire = 1f;
            maxTimeToFire = 9f;
        }
        else if(this.gameObject.tag == "enemyBlue") {
            minTimeToFire = 1f;
            maxTimeToFire = 8f;
        }
        else if(this.gameObject.tag == "enemyOrange") {
            minTimeToFire = 1f;
            maxTimeToFire = 7f;
        }

        if(this.gameObject.tag == "enemyBlack") {
            hit = false;
            increasedAlready = false;
            //minTimeToFire = minTimeToFire;
            //maxTimeToFire = maxTimeToFire;
            moveSpeed = 5f;
            laserMoveSpeed = -250f;
            transform.position = waypoints1[waypointIndex].transform.position;
            firstTimerCap1 = Random.Range(minTimeToFire,maxTimeToFire);
            firstTimerCap2 = Random.Range(minTimeToFire,maxTimeToFire);
            firstTimerCap3 = Random.Range(minTimeToFire,maxTimeToFire);
            firstTimerCap4 = Random.Range(minTimeToFire,maxTimeToFire);

            secondTimerCap1 = Random.Range(minTimeToFire,maxTimeToFire);
            secondTimerCap2 = Random.Range(minTimeToFire,maxTimeToFire);
            secondTimerCap3 = Random.Range(minTimeToFire,maxTimeToFire);
            secondTimerCap4 = Random.Range(minTimeToFire,maxTimeToFire);

            thirdTimerCap1 = Random.Range(minTimeToFire,maxTimeToFire);
            thirdTimerCap2 = Random.Range(minTimeToFire,maxTimeToFire);
            thirdTimerCap3 = Random.Range(minTimeToFire,maxTimeToFire);
            thirdTimerCap4 = Random.Range(minTimeToFire,maxTimeToFire);

            fourthTimerCap1 = Random.Range(minTimeToFire,maxTimeToFire);
            fourthTimerCap2 = Random.Range(minTimeToFire,maxTimeToFire);
            fourthTimerCap3 = Random.Range(minTimeToFire,maxTimeToFire);
            fourthTimerCap4 = Random.Range(minTimeToFire,maxTimeToFire);
        }
        if(this.gameObject.tag == "enemyGreen") {
            hit = false;
            increasedAlready = false;
            //minTimeToFire = minTimeToFire;
            //maxTimeToFire = 10f;
            moveSpeed = 5f;
            laserMoveSpeed = -250f;
            transform.position = waypoints1[waypointIndex].transform.position;
            firstTimerCap1 = Random.Range(minTimeToFire,maxTimeToFire);
            firstTimerCap2 = Random.Range(minTimeToFire,maxTimeToFire);
            firstTimerCap3 = Random.Range(minTimeToFire,maxTimeToFire);
            firstTimerCap4 = Random.Range(minTimeToFire,maxTimeToFire);

            secondTimerCap1 = Random.Range(minTimeToFire,maxTimeToFire);
            secondTimerCap2 = Random.Range(minTimeToFire,maxTimeToFire);
            secondTimerCap3 = Random.Range(minTimeToFire,maxTimeToFire);
            secondTimerCap4 = Random.Range(minTimeToFire,maxTimeToFire);

            thirdTimerCap1 = Random.Range(minTimeToFire,maxTimeToFire);
            thirdTimerCap2 = Random.Range(minTimeToFire,maxTimeToFire);
            thirdTimerCap3 = Random.Range(minTimeToFire,maxTimeToFire);
            thirdTimerCap4 = Random.Range(minTimeToFire,maxTimeToFire);

            fourthTimerCap1 = Random.Range(minTimeToFire,maxTimeToFire);
            fourthTimerCap2 = Random.Range(minTimeToFire,maxTimeToFire);
            fourthTimerCap3 = Random.Range(minTimeToFire,maxTimeToFire);
            fourthTimerCap4 = Random.Range(minTimeToFire,maxTimeToFire);
        }
        if(this.gameObject.tag == "enemyOrange") {
            hit = false;
            increasedAlready = false;
            //minTimeToFire = minTimeToFire;
            //maxTimeToFire = maxTimeToFire;
            moveSpeed = 5f;
            laserMoveSpeed = -250f;
            transform.position = waypoints1[waypointIndex].transform.position;
            firstTimerCap1 = Random.Range(minTimeToFire,maxTimeToFire);
            firstTimerCap2 = Random.Range(minTimeToFire,maxTimeToFire);
            firstTimerCap3 = Random.Range(minTimeToFire,maxTimeToFire);
            firstTimerCap4 = Random.Range(minTimeToFire,maxTimeToFire);

            secondTimerCap1 = Random.Range(minTimeToFire,maxTimeToFire);
            secondTimerCap2 = Random.Range(minTimeToFire,maxTimeToFire);
            secondTimerCap3 = Random.Range(minTimeToFire,maxTimeToFire);
            secondTimerCap4 = Random.Range(minTimeToFire,maxTimeToFire);

            thirdTimerCap1 = Random.Range(minTimeToFire,maxTimeToFire);
            thirdTimerCap2 = Random.Range(minTimeToFire,maxTimeToFire);
            thirdTimerCap3 = Random.Range(minTimeToFire,maxTimeToFire);
            thirdTimerCap4 = Random.Range(minTimeToFire,maxTimeToFire);

            fourthTimerCap1 = Random.Range(minTimeToFire,maxTimeToFire);
            fourthTimerCap2 = Random.Range(minTimeToFire,maxTimeToFire);
            fourthTimerCap3 = Random.Range(minTimeToFire,maxTimeToFire);
            fourthTimerCap4 = Random.Range(minTimeToFire,maxTimeToFire);
        }
        if(this.gameObject.tag == "enemyBlue") {
            hit = false;
            increasedAlready = false;
            //minTimeToFire = minTimeToFire;
            //maxTimeToFire = maxTimeToFire;
            moveSpeed = 5f;
            laserMoveSpeed = -250f;
            transform.position = waypoints1[waypointIndex].transform.position;
            firstTimerCap1 = Random.Range(minTimeToFire,maxTimeToFire);
            firstTimerCap2 = Random.Range(minTimeToFire,maxTimeToFire);
            firstTimerCap3 = Random.Range(minTimeToFire,maxTimeToFire);
            firstTimerCap4 = Random.Range(minTimeToFire,maxTimeToFire);

            secondTimerCap1 = Random.Range(minTimeToFire,maxTimeToFire);
            secondTimerCap2 = Random.Range(minTimeToFire,maxTimeToFire);
            secondTimerCap3 = Random.Range(minTimeToFire,maxTimeToFire);
            secondTimerCap4 = Random.Range(minTimeToFire,maxTimeToFire);

            thirdTimerCap1 = Random.Range(minTimeToFire,maxTimeToFire);
            thirdTimerCap2 = Random.Range(minTimeToFire,maxTimeToFire);
            thirdTimerCap3 = Random.Range(minTimeToFire,maxTimeToFire);
            thirdTimerCap4 = Random.Range(minTimeToFire,maxTimeToFire);

            fourthTimerCap1 = Random.Range(minTimeToFire,maxTimeToFire);
            fourthTimerCap2 = Random.Range(minTimeToFire,maxTimeToFire);
            fourthTimerCap3 = Random.Range(minTimeToFire,maxTimeToFire);
            fourthTimerCap4 = Random.Range(minTimeToFire,maxTimeToFire);
        }

    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "PlayerLaser" && instantiated) {
            if(!allowHit) {
                Destroy(other.gameObject);
            }
            else if (allowHit) {
                dead = true;
                Destroy(other.gameObject);
                //StartCoroutine(WaitAndHit());
                //this.GetComponent<Animation>().Play("Hit");
                //this.GetComponent<Animator>().enabled = true;
                //this.GetComponent<Animator>().SetBool("isExploding",true);
                //this.GetComponent<SpriteRenderer>().enabled = false;
                GameObject dieExplosion = Instantiate(deathExplosion,transform.position,Quaternion.identity) as GameObject;
                AudioClip clip = enemySounds[2];
                myAudioSource.PlayOneShot(clip);
                this.GetComponent<PolygonCollider2D>().isTrigger = false;
                this.GetComponent<SpriteRenderer>().enabled = false;
                if(!increasedAlready) {
                    increasedAlready = true;
                    EnemyInstantiatingManager.wave1Total++;
                }
                Destroy(this.gameObject);
            }
        }
    }
    IEnumerator WaitAndEndArrivalRoutine() {
        yield return new WaitForSeconds(1f);
        this.GetComponent<Animator>().SetBool("isArriving",false);
    }

    IEnumerator WaitAndHit() {
        yield return new WaitForSeconds(.1f);
        hit = true;
    }

}
