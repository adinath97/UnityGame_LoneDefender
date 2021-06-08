using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathingBlack2 : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints1;
    [SerializeField] List<Transform> waypoints2;
    //left to right top row
    [SerializeField] List<Transform> subWaypoints1;
    [SerializeField] List<Transform> subWaypoints2;
    [SerializeField] List<Transform> subWaypoints3;
    [SerializeField] List<Transform> subWaypoints4;
    //left to right bottom row
    [SerializeField] List<Transform> subWaypoints5;
    [SerializeField] List<Transform> subWaypoints6;
    [SerializeField] List<Transform> subWaypoints7;
    [SerializeField] GameObject deathExplosion;

    [SerializeField] GameObject enemyLaserPrefab;
    [SerializeField] AudioClip[] enemySounds;
    AudioSource myAudioSource;
    [SerializeField] float moveSpeed;
    [SerializeField] float initialMoveSpeed = 15f;
    [SerializeField] float laserMoveSpeed;

    int hitsAllowed;
    int waypointIndex = 0;
    int subWaypointIndex = 0;
    int counter1, counter2, counter3, hitsHad;
    bool dead, hit, allowHit, increasedAlready, targetReached;
    [SerializeField] float maxTimeToFire;
    [SerializeField] float minTimeToFire;

    float firstTimer1,secondTimer1,thirdTimer1,fourthTimer1,
    firstTimer2,secondTimer2,thirdTimer2,fourthTimer2,
    firstTimer3,secondTimer3,thirdTimer3,fourthTimer3,
    firstTimer4,secondTimer4,thirdTimer4,fourthTimer4;

    float firstTimerCap1,secondTimerCap1,thirdTimerCap1,fourthTimerCap1,
    firstTimerCap2,secondTimerCap2,thirdTimerCap2,fourthTimerCap2,
    firstTimerCap3,secondTimerCap3,thirdTimerCap3,fourthTimerCap3,
    firstTimerCap4,secondTimerCap4,thirdTimerCap4,fourthTimerCap4;

    public bool instantiated,first1,second1,third1,fourth1,first2,second2,third2,fourth2,first3,second3,third3,fourth3;

    // Start is called before the first frame update

    void Awake()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
        myAudioSource = this.GetComponent<AudioSource>();
        targetReached = false;
        dead = false;
    }
    
    void Start()
    {
        InitialSetUp();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyFireTimers();
        EnemyMovementAndFiring();
        MoveOnSubWaypoints();
    }
    void MoveOnSubWaypoints() {
        if(EnemyInstantiatingManager.wave2TotalLaunched == 7) {
            //this.transform.GetChild(0).gameObject.SetActive(false);
            var movementThisFrame2 = moveSpeed * Time.deltaTime * .5f;
            if(allowHit && fourth2) {
                if(counter1 == 0) {
                    ////Debug.Log("HELLO 1");
                    counter1++;
                }
                if(subWaypointIndex < 2) {
                    if(counter2 == 0) {
                        ////Debug.Log("HELLO 2");
                        counter2++;
                    }
                    ////Debug.Log(subWaypointIndex);
                    var targetPosition2 = new Vector2(subWaypoints1[subWaypointIndex].transform.position.x,subWaypoints1[subWaypointIndex].transform.position.y);
                    var currentPos = new Vector2(transform.position.x,transform.position.y);
                    if(!hit) {
                        transform.position = Vector2.MoveTowards(transform.position,targetPosition2,movementThisFrame2);
                    }
                    if(targetPosition2 == currentPos) {
                        ////Debug.Log("HELLO 3.1");
                        if(counter3 == 0) {
                            ////Debug.Log("HELLO 3");
                            counter3++;
                        }
                        subWaypointIndex++;
                    }
                }
                else {
                    subWaypointIndex = 0;
                }
            }
            if(allowHit && third2) {
                if(counter1 == 0) {
                    ////Debug.Log("HELLO 1");
                    counter1++;
                }
                if(subWaypointIndex < 2) {
                    if(counter2 == 0) {
                        ////Debug.Log("HELLO 2");
                        counter2++;
                    }
                    ////Debug.Log(subWaypointIndex);
                    var targetPosition2 = new Vector2(subWaypoints2[subWaypointIndex].transform.position.x,subWaypoints2[subWaypointIndex].transform.position.y);
                    var currentPos = new Vector2(transform.position.x,transform.position.y);
                    //var movementThisFrame2 = moveSpeed * Time.deltaTime * .1f;
                    if(!hit) {
                        ////Debug.Log("MOVING?!");
                        transform.position = Vector2.MoveTowards(transform.position,targetPosition2,movementThisFrame2);
                    }
                    ////Debug.Log("Ship pos is " + transform.position);
                    ////Debug.Log("Waypoint localPos is " + subWaypoints2[subWaypointIndex].transform.localPosition);
                    ////Debug.Log("Waypoint pos is " + subWaypoints2[subWaypointIndex].transform.position);
                    if(targetPosition2 == currentPos) {
                        ////Debug.Log("HELLO 3.1");
                        if(counter3 == 0) {
                            ////Debug.Log("HELLO 3");
                            counter3++;
                        }
                        subWaypointIndex++;
                    }
                }
                else {
                    subWaypointIndex = 0;
                }
            }
            if(allowHit && second2) {
                if(counter1 == 0) {
                    ////Debug.Log("HELLO 1");
                    counter1++;
                }
                if(subWaypointIndex < 2) {
                    if(counter2 == 0) {
                        ////Debug.Log("HELLO 2");
                        counter2++;
                    }
                    ////Debug.Log(subWaypointIndex);
                    var targetPosition2 = new Vector2(subWaypoints3[subWaypointIndex].transform.position.x,subWaypoints3[subWaypointIndex].transform.position.y);
                    var currentPos = new Vector2(transform.position.x,transform.position.y);
                    //var movementThisFrame2 = moveSpeed * Time.deltaTime * .1f;
                    if(!hit) {
                        transform.position = Vector2.MoveTowards(transform.position,targetPosition2,movementThisFrame2);
                    }
                    if(targetPosition2 == currentPos) {
                        ////Debug.Log("HELLO 3.1");
                        if(counter3 == 0) {
                            ////Debug.Log("HELLO 3");
                            counter3++;
                        }
                        subWaypointIndex++;
                    }
                }
                else {
                    subWaypointIndex = 0;
                }
            }
            if(allowHit && first2) {
                if(counter1 == 0) {
                    ////Debug.Log("HELLO 1");
                    counter1++;
                }
                if(subWaypointIndex < 2) {
                    if(counter2 == 0) {
                        ////Debug.Log("HELLO 2");
                        counter2++;
                    }
                    ////Debug.Log(subWaypointIndex);
                    var targetPosition2 = new Vector2(subWaypoints4[subWaypointIndex].transform.position.x,subWaypoints4[subWaypointIndex].transform.position.y);
                    var currentPos = new Vector2(transform.position.x,transform.position.y);
                    //var movementThisFrame2 = moveSpeed * Time.deltaTime * .1f;
                    if(!hit) {
                        transform.position = Vector2.MoveTowards(transform.position,targetPosition2,movementThisFrame2);
                    }
                    if(targetPosition2 == currentPos) {
                        ////Debug.Log("HELLO 3.1");
                        if(counter3 == 0) {
                            ////Debug.Log("HELLO 3");
                            counter3++;
                        }
                        subWaypointIndex++;
                    }
                }
                else {
                    subWaypointIndex = 0;
                }
            }
            
            if(allowHit && third1) {
                if(counter1 == 0) {
                    ////Debug.Log("HELLO 1");
                    counter1++;
                }
                if(subWaypointIndex < 2) {
                    if(counter2 == 0) {
                        ////Debug.Log("HELLO 2");
                        counter2++;
                    }
                    ////Debug.Log(subWaypointIndex);
                    var targetPosition2 = new Vector2(subWaypoints5[subWaypointIndex].transform.position.x,subWaypoints5[subWaypointIndex].transform.position.y);
                    var currentPos = new Vector2(transform.position.x,transform.position.y);
                    //var movementThisFrame2 = moveSpeed * Time.deltaTime * .1f;
                    if(!hit) {
                        transform.position = Vector2.MoveTowards(transform.position,targetPosition2,movementThisFrame2);
                    }
                    if(targetPosition2 == currentPos) {
                        ////Debug.Log("HELLO 3.1");
                        if(counter3 == 0) {
                            ////Debug.Log("HELLO 3");
                            counter3++;
                        }
                        subWaypointIndex++;
                    }
                }
                else {
                    subWaypointIndex = 0;
                }
            }
            if(allowHit && second1) {
                if(counter1 == 0) {
                    ////Debug.Log("HELLO 1");
                    counter1++;
                }
                if(subWaypointIndex < 2) {
                    if(counter2 == 0) {
                        ////Debug.Log("HELLO 2");
                        counter2++;
                    }
                    ////Debug.Log(subWaypointIndex);
                    var targetPosition2 = new Vector2(subWaypoints6[subWaypointIndex].transform.position.x,subWaypoints6[subWaypointIndex].transform.position.y);
                    var currentPos = new Vector2(transform.position.x,transform.position.y);
                    //var movementThisFrame2 = moveSpeed * Time.deltaTime * .1f;
                    if(!hit) {
                        transform.position = Vector2.MoveTowards(transform.position,targetPosition2,movementThisFrame2);
                    }
                    if(targetPosition2 == currentPos) {
                        ////Debug.Log("HELLO 3.1");
                        if(counter3 == 0) {
                            ////Debug.Log("HELLO 3");
                            counter3++;
                        }
                        subWaypointIndex++;
                    }
                }
                else {
                    subWaypointIndex = 0;
                }
            }
            if(allowHit && first1) {
                if(counter1 == 0) {
                    ////Debug.Log("HELLO 1");
                    counter1++;
                }
                if(subWaypointIndex < 2) {
                    if(counter2 == 0) {
                        ////Debug.Log("HELLO 2");
                        counter2++;
                    }
                    ////Debug.Log(subWaypointIndex);
                    var targetPosition2 = new Vector2(subWaypoints7[subWaypointIndex].transform.position.x,subWaypoints7[subWaypointIndex].transform.position.y);
                    var currentPos = new Vector2(transform.position.x,transform.position.y);
                    //var movementThisFrame2 = moveSpeed * Time.deltaTime * .1f;
                    if(!hit) {
                        transform.position = Vector2.MoveTowards(transform.position,targetPosition2,movementThisFrame2);
                    }
                    if(targetPosition2 == currentPos) {
                        ////Debug.Log("HELLO 3.1");
                        if(counter3 == 0) {
                            ////Debug.Log("HELLO 3");
                            counter3++;
                        }
                        subWaypointIndex++;
                    }
                }
                else {
                    subWaypointIndex = 0;
                }
            }
            
        }

    }

    void EnemyMovementAndFiring() {
        //rightmost bottom row -> leftmost bottom row
        if(this.targetReached) {
            this.allowHit = true;
        }
        if(first1) {
            if(waypointIndex < waypoints1.Count) {
                var targetPosition = waypoints1[waypointIndex].transform.position;
                var movementThisFrame = initialMoveSpeed * Time.deltaTime;
                if(!hit) {
                    transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
                }
                if(targetPosition == transform.position) {
                    waypointIndex++;
                }
            }
            else {
                //allowHit = true;
                if(!targetReached) {
                    EnemyInstantiatingManager.wave2TotalLaunched++;
                    targetReached = true;
                }
                
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
                var movementThisFrame = initialMoveSpeed * Time.deltaTime;                
                if(!hit) {
                    transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
                }
                if(targetPosition == transform.position) {
                    waypointIndex++;
                }
            }
            else {
                //allowHit = true;
                if(!targetReached) {
                    EnemyInstantiatingManager.wave2TotalLaunched++;
                    targetReached = true;
                }
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
                var movementThisFrame = initialMoveSpeed * Time.deltaTime;
                if(!hit) {
                    transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
                }
                if(targetPosition == transform.position) {
                    waypointIndex++;
                }
            }
            else {
                //allowHit = true;
                if(!targetReached) {
                    EnemyInstantiatingManager.wave2TotalLaunched++;
                    targetReached = true;
                }
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

        //rightmost top row -> leftmost top row
        if(first2) {
            if(waypointIndex < waypoints2.Count) {
                var targetPosition = waypoints2[waypointIndex].transform.position;
                var movementThisFrame = initialMoveSpeed * Time.deltaTime;
                if(!hit) {
                    transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
                }
                if(targetPosition == transform.position) {
                    waypointIndex++;
                }
            }
            else {
                
                //allowHit = true;
                if(!targetReached) {
                    EnemyInstantiatingManager.wave2TotalLaunched++;
                    targetReached = true;
                }
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
                var movementThisFrame = initialMoveSpeed * Time.deltaTime;
                if(!hit) {
                    transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
                }
                if(targetPosition == transform.position) {
                    waypointIndex++;
                }
            }
            else {
                //allowHit = true;
                if(!targetReached) {
                    EnemyInstantiatingManager.wave2TotalLaunched++;
                    targetReached = true;
                }
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
                var movementThisFrame = initialMoveSpeed * Time.deltaTime;
                if(!hit) {
                    transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
                }
                if(targetPosition == transform.position) {
                    waypointIndex++;
                }
            }
            else {
                //allowHit = true;
                if(!targetReached) {
                    EnemyInstantiatingManager.wave2TotalLaunched++;
                    targetReached = true;
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
                var movementThisFrame = initialMoveSpeed * Time.deltaTime;
                if(!hit) {
                    transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
                }
                if(targetPosition == transform.position) {
                    waypointIndex++;
                }
            }
            else {
                //allowHit = true;
                if(!targetReached) {
                    EnemyInstantiatingManager.wave2TotalLaunched++;
                    targetReached = true;
                }
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
    
    IEnumerator WaitAndEndArrivalRoutine() {
        yield return new WaitForSeconds(1f);
        this.GetComponent<Animator>().SetBool("isArriving",false);
        
    }
    
    void InitialSetUp() {
        this.GetComponent<Animator>().SetBool("isArriving",true);
        StartCoroutine(WaitAndEndArrivalRoutine());
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
            //minTimeToFire = 5f;
            //maxTimeToFire = 10f;
            moveSpeed = 5f;
            laserMoveSpeed = -250f;
            hitsAllowed = 2;
            //this.GetComponent<Animator>().enabled = false;
            if(first1 || second1 || third1) {
                transform.position = waypoints1[waypointIndex].transform.position;
            }
            if(first2 || second2 || third2 || fourth2) {
                transform.position = waypoints2[waypointIndex].transform.position;
            }
            
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
            //minTimeToFire = 5f;
            //maxTimeToFire = 10f;
            moveSpeed = 5f;
            laserMoveSpeed = -250f;
            hitsAllowed = 2;
            //this.GetComponent<Animator>().enabled = false;
            if(first1 || second1 || third1) {
                transform.position = waypoints1[waypointIndex].transform.position;
            }
            if(first2 || second2 || third2 || fourth2) {
                transform.position = waypoints2[waypointIndex].transform.position;
            }
            
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
            //minTimeToFire = 5f;
            //maxTimeToFire = 10f;
            moveSpeed = 5f;
            laserMoveSpeed = -250f;
            hitsAllowed = 2;
            //this.GetComponent<Animator>().enabled = false;
            if(first1 || second1 || third1) {
                transform.position = waypoints1[waypointIndex].transform.position;
            }
            if(first2 || second2 || third2 || fourth2) {
                transform.position = waypoints2[waypointIndex].transform.position;
            }
            
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
            //minTimeToFire = 5f;
            //maxTimeToFire = 10f;
            moveSpeed = 5f;
            laserMoveSpeed = -250f;
            hitsAllowed = 2;
            //this.GetComponent<Animator>().enabled = false;
            if(first1 || second1 || third1) {
                transform.position = waypoints1[waypointIndex].transform.position;
            }
            if(first2 || second2 || third2 || fourth2) {
                transform.position = waypoints2[waypointIndex].transform.position;
            }
            
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
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.tag == "PlayerLaser" && instantiated) {
            if(!allowHit) {
                Destroy(other.gameObject);
            }
            else if (allowHit) {
                hitsHad++;
                Destroy(other.gameObject);
                if(hitsHad < hitsAllowed) {
                    this.GetComponent<Animator>().SetBool("isHit",true);
                    StartCoroutine(WaitAndEndHitState());
                    AudioClip clip = enemySounds[1];
                    myAudioSource.PlayOneShot(clip);
                }
                if(hitsHad >= hitsAllowed) {
                    GameObject dieExplosion = Instantiate(deathExplosion,transform.position,Quaternion.identity) as GameObject;
                    //this.GetComponent<Animator>().enabled = true;
                    //this.GetComponent<Animator>().SetBool("isExploding",true);
                    //StartCoroutine(WaitAndHit());
                    //this.GetComponent<SpriteRenderer>().enabled = false;
                    AudioClip clip = enemySounds[2];
                    myAudioSource.PlayOneShot(clip);
                    this.GetComponent<PolygonCollider2D>().isTrigger = false;
                    this.GetComponent<SpriteRenderer>().enabled = false;
                    if(!increasedAlready) {
                        increasedAlready = true;
                        EnemyInstantiatingManager.wave2Total++;
                    }
                    Destroy(this.gameObject);
                }
            }
        }
    }

    IEnumerator WaitAndEndHitState() {
        yield return new WaitForSeconds(.1f);
        this.GetComponent<Animator>().SetBool("isHit",false);
    }

    IEnumerator WaitAndHit() {
        yield return new WaitForSeconds(.1f);
        hit = true;
    }
    
}
