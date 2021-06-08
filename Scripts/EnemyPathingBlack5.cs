using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathingBlack5 : MonoBehaviour
{
    [SerializeField] List<Transform> desiredPositions;
    [SerializeField] GameObject enemyLaserPrefab;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float minTimeToFire;
    [SerializeField] float maxTimeToFire;
    [SerializeField] float laserMoveSpeed;
    [SerializeField] GameObject deathExplosion;
    [SerializeField] AudioClip[] enemySounds;
    AudioSource myAudioSource;

    int waypointIndex = 0;
    int hitsAllowed;
    bool dead,hit, allowHit, increasedAlready;
    int counter1,counter2,counter3, hitsHad;
    GameObject launchPoint1,launchPoint2;

    float firstTimer1,secondTimer1,thirdTimer1,fourthTimer1,
    firstTimer2,secondTimer2,thirdTimer2,fourthTimer2,
    firstTimer3,secondTimer3,thirdTimer3,fourthTimer3,
    firstTimer4,secondTimer4,thirdTimer4,fourthTimer4;

    float firstTimerCap1,secondTimerCap1,thirdTimerCap1,fourthTimerCap1,
    firstTimerCap2,secondTimerCap2,thirdTimerCap2,fourthTimerCap2,
    firstTimerCap3,secondTimerCap3,thirdTimerCap3,fourthTimerCap3,
    firstTimerCap4,secondTimerCap4,thirdTimerCap4,fourthTimerCap4;

    public bool instantiated,fifth1,sixth1,first1,second1,third1,fourth1,first2,second2,third2,fourth2,first3,second3,third3,fourth3;

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
        allowHit = true;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyFireTimers();
        EnemyMovementAndFiring();
        
    }

    void EnemyMovementAndFiring() {
        if(first1) {
            if(transform.position != desiredPositions[1].transform.position) {
                var targetPosition = desiredPositions[1].transform.position;
                var movementThisFrame = moveSpeed * Time.deltaTime;
                if(!hit) {
                    transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
                }
                if(targetPosition == transform.position) {
                    waypointIndex++;
                }
            }
            else {
                if(EnemyInstantiatingManager.wave5TotalLaunched == 0) {
                    EnemyInstantiatingManager.wave5TotalLaunched++;
                }
                allowHit = true;
                if(firstTimer1 >= firstTimerCap1 && !hit) {
                    firstTimer1 = 0f;
                    firstTimerCap1 = Random.Range(minTimeToFire,maxTimeToFire);
                    GameObject laserInstance1 = Instantiate(enemyLaserPrefab,launchPoint1.transform.position,Quaternion.identity) as GameObject;
                    //GameObject laserInstance2 = Instantiate(enemyLaserPrefab,launchPoint2.transform.position,Quaternion.identity) as GameObject;
                    laserInstance1.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,laserMoveSpeed * Time.deltaTime);
                    AudioClip clip = enemySounds[0];
                    myAudioSource.PlayOneShot(clip);
                    //laserInstance2.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,laserMoveSpeed * Time.deltaTime);
                    ////Debug.Log("LAUNCHED?!");
                    ////Debug.Log(launchPoint1.transform.position);
                    ////Debug.Log(launchPoint2.transform.position);
                } 
            }
        }
        if(second1) {
            if(transform.position != desiredPositions[2].transform.position) {
                var targetPosition = desiredPositions[2].transform.position;
                var movementThisFrame = moveSpeed * Time.deltaTime;
                if(!hit) {
                    transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
                }
                if(targetPosition == transform.position) {
                    waypointIndex++;
                }
            }
            else {
                if(EnemyInstantiatingManager.wave5TotalLaunched == 1) {
                    EnemyInstantiatingManager.wave5TotalLaunched++;
                }
                allowHit = true;
                if(secondTimer1 >= secondTimerCap1 && !hit) {
                    secondTimer1 = 0f;
                    secondTimerCap1 = Random.Range(minTimeToFire,maxTimeToFire);
                    GameObject laserInstance1 = Instantiate(enemyLaserPrefab,launchPoint1.transform.position,Quaternion.identity) as GameObject;
                    //GameObject laserInstance2 = Instantiate(enemyLaserPrefab,launchPoint2.transform.position,Quaternion.identity) as GameObject;
                    laserInstance1.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,laserMoveSpeed * Time.deltaTime);
                    AudioClip clip = enemySounds[0];
                    myAudioSource.PlayOneShot(clip);
                    //laserInstance2.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,laserMoveSpeed * Time.deltaTime);
                    ////Debug.Log("LAUNCHED?!");
                    ////Debug.Log(launchPoint1.transform.position);
                    ////Debug.Log(launchPoint2.transform.position);
                } 
            }
        }
        if(third1) {
            if(transform.position != desiredPositions[3].transform.position) {
                var targetPosition = desiredPositions[3].transform.position;
                var movementThisFrame = moveSpeed * Time.deltaTime;
                if(!hit) {
                    transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
                }
                if(targetPosition == transform.position) {
                    waypointIndex++;
                }
            }
            else {
                if(EnemyInstantiatingManager.wave5TotalLaunched == 2) {
                    EnemyInstantiatingManager.wave5TotalLaunched++;
                }
                allowHit = true;
                if(thirdTimer1 >= thirdTimerCap1 && !hit) {
                    thirdTimer1 = 0f;
                    thirdTimerCap1 = Random.Range(minTimeToFire,maxTimeToFire);
                    GameObject laserInstance1 = Instantiate(enemyLaserPrefab,launchPoint1.transform.position,Quaternion.identity) as GameObject;
                    //GameObject laserInstance2 = Instantiate(enemyLaserPrefab,launchPoint2.transform.position,Quaternion.identity) as GameObject;
                    laserInstance1.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,laserMoveSpeed * Time.deltaTime);
                    AudioClip clip = enemySounds[0];
                    myAudioSource.PlayOneShot(clip);
                    //laserInstance2.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,laserMoveSpeed * Time.deltaTime);
                    ////Debug.Log("LAUNCHED?!");
                    ////Debug.Log(launchPoint1.transform.position);
                    ////Debug.Log(launchPoint2.transform.position);
                } 
            }
        }
        if(fourth1) {
            if(transform.position != desiredPositions[4].transform.position) {
                var targetPosition = desiredPositions[4].transform.position;
                var movementThisFrame = moveSpeed * Time.deltaTime;
                if(!hit) {
                    transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
                }
                if(targetPosition == transform.position) {
                    waypointIndex++;
                }
            }
            else {
                allowHit = true;
                if(EnemyInstantiatingManager.wave5TotalLaunched == 3) {
                    EnemyInstantiatingManager.wave5TotalLaunched++;
                }
                if(fourthTimer1 >= fourthTimerCap1 && !hit) {
                    fourthTimer1 = 0f;
                    fourthTimerCap1 = Random.Range(minTimeToFire,maxTimeToFire);
                    GameObject laserInstance1 = Instantiate(enemyLaserPrefab,launchPoint1.transform.position,Quaternion.identity) as GameObject;
                    //GameObject laserInstance2 = Instantiate(enemyLaserPrefab,launchPoint2.transform.position,Quaternion.identity) as GameObject;
                    laserInstance1.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,laserMoveSpeed * Time.deltaTime);
                    AudioClip clip = enemySounds[0];
                    myAudioSource.PlayOneShot(clip);
                    //laserInstance2.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,laserMoveSpeed * Time.deltaTime);
                    ////Debug.Log("LAUNCHED?!");
                    ////Debug.Log(launchPoint1.transform.position);
                    ////Debug.Log(launchPoint2.transform.position);
                } 
            }
        }
        if(fifth1) {
            if(transform.position != desiredPositions[5].transform.position) {
                var targetPosition = desiredPositions[5].transform.position;
                var movementThisFrame = moveSpeed * Time.deltaTime;
                if(!hit) {
                    transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
                }
                if(targetPosition == transform.position) {
                    waypointIndex++;
                }
            }
            else {
                allowHit = true;
                if(EnemyInstantiatingManager.wave5TotalLaunched == 4) {
                    EnemyInstantiatingManager.wave5TotalLaunched++;
                }
                if(firstTimer2 >= firstTimerCap2 && !hit) {
                    firstTimer2 = 0f;
                    firstTimerCap2 = Random.Range(minTimeToFire,maxTimeToFire);
                    GameObject laserInstance1 = Instantiate(enemyLaserPrefab,launchPoint1.transform.position,Quaternion.identity) as GameObject;
                    //GameObject laserInstance2 = Instantiate(enemyLaserPrefab,launchPoint2.transform.position,Quaternion.identity) as GameObject;
                    laserInstance1.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,laserMoveSpeed * Time.deltaTime);
                    AudioClip clip = enemySounds[0];
                    myAudioSource.PlayOneShot(clip);
                    //laserInstance2.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,laserMoveSpeed * Time.deltaTime);
                    //("LAUNCHED?!");
                    ////Debug.Log(launchPoint1.transform.position);
                    ////Debug.Log(launchPoint2.transform.position);
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
            increasedAlready = false;
            moveSpeed = 17f;
            laserMoveSpeed = -250f;
            //minTimeToFire = 2f;
            //maxTimeToFire = 6f;
            hitsAllowed = 3;
            transform.position = desiredPositions[0].transform.position;
            launchPoint1 = this.gameObject;
            launchPoint2 = this.gameObject;
            //this.GetComponent<Animator>().enabled = false;
            
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
            moveSpeed = 17f;
            laserMoveSpeed = -250f;
            //minTimeToFire = 2f;
            //maxTimeToFire = 6f;
            hitsAllowed = 3;
            transform.position = desiredPositions[0].transform.position;
            launchPoint1 = this.gameObject;
            launchPoint2 = this.gameObject;
            //this.GetComponent<Animator>().enabled = false;
            
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
            moveSpeed = 17f;
            laserMoveSpeed = -250f;
            //minTimeToFire = 2f;
            //maxTimeToFire = 6f;
            hitsAllowed = 3;
            transform.position = desiredPositions[0].transform.position;
            launchPoint1 = this.gameObject;
            launchPoint2 = this.gameObject;
            //this.GetComponent<Animator>().enabled = false;
            
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
            moveSpeed = 17f;
            laserMoveSpeed = -250f;
            //minTimeToFire = 2f;
            //maxTimeToFire = 6f;
            hitsAllowed = 3;
            transform.position = desiredPositions[0].transform.position;
            launchPoint1 = this.gameObject;
            launchPoint2 = this.gameObject;
            //this.GetComponent<Animator>().enabled = false;
            
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
                        EnemyInstantiatingManager.wave5Total++;
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
