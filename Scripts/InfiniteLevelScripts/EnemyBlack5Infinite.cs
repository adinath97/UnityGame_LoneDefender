using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlack5Infinite : MonoBehaviour
{
    [SerializeField] List<Sprite> sprites;
    [SerializeField] List<Transform> pathFiveWaypoints;
    [SerializeField] float laserMoveSpeed = -400f;
    [SerializeField] GameObject enemyLaserPrefab;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] GameObject deathExplosion;
    [SerializeField] GameObject hitExplosion;
    [SerializeField] GameObject laserInstantiationPoint;
    [SerializeField] float minTimeToFire = 5f;
    [SerializeField] float maxTimeToFire = 10f;
    [SerializeField] AudioClip[] enemySounds;
    AudioSource myAudioSource;
    public int waypointIndex = 0, hitsAllowed = 3, hits = 0;
    float fireTimer,fireTimerCap,totalFireTimer;
    public bool allowHit,start,instantiated,pathFive1,pathFive2,pathFive3,pathFive4,pathFive5,pathFive6,pathFive7,pathFive8,pathFive9;
    bool dead;
    void Awake()
    {
        allowHit = true;
        dead = false;
        myAudioSource = this.GetComponent<AudioSource>();
        totalFireTimer = 0;
        if(WavesDefeatedManager.wavesDefeated >= 0) {
            minTimeToFire = 5f;
            maxTimeToFire = 10f;
        }
        if(WavesDefeatedManager.wavesDefeated >= 5) {
            minTimeToFire = 5f;
            maxTimeToFire = 9f;
        }
        if(WavesDefeatedManager.wavesDefeated >= 10) {
            minTimeToFire = 4f;
            maxTimeToFire = 9f;
        }
        if(WavesDefeatedManager.wavesDefeated >= 15) {
            minTimeToFire = 4f;
            maxTimeToFire = 8f;
        }
        if(WavesDefeatedManager.wavesDefeated >= 20) {
            minTimeToFire = 4f;
            maxTimeToFire = 7f;
        }
        if(WavesDefeatedManager.wavesDefeated >= 25) {
            minTimeToFire = 3f;
            maxTimeToFire = 7f;
        }
        if(WavesDefeatedManager.wavesDefeated >= 30) {
            minTimeToFire = 3f;
            maxTimeToFire = 6f;
        }
        if(WavesDefeatedManager.wavesDefeated >= 35) {
            minTimeToFire = 2f;
            maxTimeToFire = 6f;
        }
        if(WavesDefeatedManager.wavesDefeated >= 40) {
            minTimeToFire = 1f;
            maxTimeToFire = 6f;
        }
        if(WavesDefeatedManager.wavesDefeated >= 45) {
            minTimeToFire = 1f;
            maxTimeToFire = 5f;
        }
        if(WavesDefeatedManager.wavesDefeated >= 50) {
            minTimeToFire = 0f;
            maxTimeToFire = 5f;
        }
        fireTimerCap = Random.Range(minTimeToFire,maxTimeToFire);
        fireTimer = 0;
        //this.GetComponent<SpriteRenderer>().sprite = sprites[InfiniteInstantiatingManager.randomNum];
        this.GetComponent<Animator>().SetBool("isArriving",true);
        StartCoroutine(WaitAndEndArrivalRoutine());
    }
    
    // Update is called once per frame
    void Update()
    {
        if(instantiated) {
            instantiated = false;
            StartCoroutine(ResetSprite());
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[InfiniteInstantiatingManager.randomNum];
            ////Debug.Log(InfiniteInstantiatingManager.randomNum);
            StartCoroutine(ResetCollider());
        }
        if(dead) {
            return;
        }
        if(start) {
            fireTimer += Time.deltaTime;
            if(fireTimer >= fireTimerCap && !dead) {
                fireTimer = 0;
                fireTimerCap = Random.Range(minTimeToFire,maxTimeToFire);
                GameObject laserInstance = Instantiate(enemyLaserPrefab,laserInstantiationPoint.transform.position,this.transform.rotation) as GameObject;
                AudioClip clip = enemySounds[0];
                myAudioSource.PlayOneShot(clip);
                ////Debug.Log("HELLO");
            }
            if(pathFive1) {
            var targetPosition = pathFiveWaypoints[waypointIndex].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
        }
            if(pathFive2) {
            waypointIndex = 1;
            var targetPosition = pathFiveWaypoints[waypointIndex].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
        }
            if(pathFive3) {
            waypointIndex = 2;
            var targetPosition = pathFiveWaypoints[waypointIndex].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
        }
            if(pathFive4) {
            waypointIndex = 3;
            var targetPosition = pathFiveWaypoints[waypointIndex].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
        }
            if(pathFive5) {
            waypointIndex = 4;
            var targetPosition = pathFiveWaypoints[waypointIndex].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
        }
            if(pathFive6) {
            waypointIndex = 5;
            var targetPosition = pathFiveWaypoints[waypointIndex].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
        }
            if(pathFive7) {
            waypointIndex = 6;
            var targetPosition = pathFiveWaypoints[waypointIndex].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
        }
            if(pathFive8) {
            waypointIndex = 7;
            var targetPosition = pathFiveWaypoints[waypointIndex].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
        }
            if(pathFive9) {
            waypointIndex = 8;
            var targetPosition = pathFiveWaypoints[waypointIndex].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
        }
        }
        
    }

    IEnumerator ResetSprite()
    {
        Destroy(this.gameObject.GetComponent<SpriteRenderer>());
        yield return 0;
        this.gameObject.AddComponent<SpriteRenderer>();
        this.GetComponent<SpriteRenderer>().sprite = sprites[InfiniteInstantiatingManager.randomNum];
        start = true;
    }

    IEnumerator ResetCollider()
    {
        Destroy(this.gameObject.GetComponent("PolygonCollider"));
        yield return 0;
        this.gameObject.AddComponent<PolygonCollider2D>();
        this.GetComponent<PolygonCollider2D>().isTrigger = true;
        start = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "PlayerLaser" && !dead) {
            Destroy(other.gameObject);
            hits++;
            if(hits < hitsAllowed) {
                GameObject hit1Explosion = Instantiate(hitExplosion,transform.position,Quaternion.identity) as GameObject;
                AudioClip clip = enemySounds[1];
                myAudioSource.PlayOneShot(clip);
            }
            if(hits >= hitsAllowed && !dead) {
                dead = true;
                GameObject dieExplosion = Instantiate(deathExplosion,transform.position,Quaternion.identity) as GameObject;
                AudioClip clip = enemySounds[2];
                myAudioSource.PlayOneShot(clip);
                InfiniteInstantiatingManager.pathFiveEnemiesDestroyed++;
                this.GetComponent<SpriteRenderer>().enabled = false;
                Destroy(this.gameObject,1f);
            }
            
        }
    }

    IEnumerator WaitAndEndHitState() {
        yield return new WaitForSeconds(.1f);
        ////Debug.Log("HIT STATE IS DONE");
        this.GetComponent<Animator>().SetBool("isHit",false);
    }

    IEnumerator WaitAndEndArrivalRoutine() {
        yield return new WaitForSeconds(1f);
        this.GetComponent<Animator>().SetBool("isArriving",false);
    }
}
