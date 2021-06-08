using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinitePlayer : MonoBehaviour
{
    [SerializeField] List<Transform> laserInstantiationPoints;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float laserMoveSpeed = 50f;
    [SerializeField] GameObject playerLaserPrefab;
    [SerializeField] GameObject deathExplosion;
    [SerializeField] GameObject hitExplosion;
    [SerializeField] GameObject powerUpExplosion;
    [SerializeField] GameObject highScoreExplosion;
    [SerializeField] GameObject bonusExplosion;
    [SerializeField] AudioClip[] playerSounds;
    AudioSource myAudioSource;
    public static float playerHealth;
    public static bool newHighScore, bonus, playerRegenBoost;
    float padding = 1f, firingRate, random4, firingTimer, firingTimerCap, speedTimer, speedTimerCap;
    float xMin, xMax, deltaX, newXPos;
    bool dead, moreCannonsPowerUp, fireAgain, firingBoostCountDown, speedBoostCountDown, thisGameOver;

    void Awake()
    {
        dead = false;
        myAudioSource = this.GetComponent<AudioSource>();
        thisGameOver = false;
        AwakeSetUp();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    void Update()
    {
        

        if(firingBoostCountDown) {
            firingTimer += Time.deltaTime;
            //Debug.Log(firingTimer);
            if(firingTimer >= firingTimerCap) {
                firingBoostCountDown = false;
                firingTimer = 0;
                firingRate = .5f;
            }
        }
        if(speedBoostCountDown) {
            speedTimer += Time.deltaTime;
            if(speedTimer >= speedTimerCap) {
                speedBoostCountDown = false;
                speedTimer = 0;
                moveSpeed = 10f;
            }
        }
        
        Fire();
        /*
        if(newHighScore) {
            newHighScore = false;
            //Debug.Log("HIGH SCORE DONE");
            GameObject highScore1Explosion = Instantiate(highScoreExplosion,transform.position,Quaternion.identity) as GameObject;
        }
        
        if(bonus) {
            bonus = false;
            //Debug.Log("BONUS");
            GameObject bonus1Explosion = Instantiate(bonusExplosion,transform.position,Quaternion.identity) as GameObject;
        }
        */
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if(!thisGameOver) {
           MovePlayer();
        }
        
    }

    void Fire() {
         
        if(Input.GetKey(KeyCode.Space)) {
            if(fireAgain && !thisGameOver) {
                fireAgain = false;
                StartCoroutine(FireRoutine());
            }
        }
    }

    IEnumerator FireRoutine() {
        yield return new WaitForSeconds(firingRate);
        GameObject laserInstance1 = Instantiate(playerLaserPrefab,laserInstantiationPoints[0].transform.position,Quaternion.identity) as GameObject;
        laserInstance1.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,laserMoveSpeed * Time.fixedDeltaTime);
        GameObject laserInstance2 = Instantiate(playerLaserPrefab,laserInstantiationPoints[1].transform.position,Quaternion.identity) as GameObject;
        laserInstance2.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,laserMoveSpeed * Time.fixedDeltaTime);
        AudioClip clip = playerSounds[0];
        myAudioSource.PlayOneShot(clip);
        fireAgain = true;
    }

    void AwakeSetUp() {
        playerRegenBoost = false;
        newHighScore = false;
        firingRate = .5f;
        random4 = 0;
        speedTimer = 0;
        speedTimerCap = 7f;
        firingTimer = 0;
        firingTimerCap = 7f;
        playerHealth = 100f;
        moreCannonsPowerUp = false;
        fireAgain = true;
        this.transform.GetChild(3).gameObject.SetActive(false);
        this.transform.GetChild(4).gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "EnemyLaser" && !dead) {
            Destroy(other.gameObject);
            if(!InfinitePlayerHealth.regenerateBoost) {
                playerHealth -= 20f;
            }
            int intplayerHealth = Mathf.RoundToInt(playerHealth);
            //Debug.Log(intplayerHealth);
            if(playerHealth > 0f && !playerRegenBoost) {
                AudioClip clip = playerSounds[1];
                myAudioSource.PlayOneShot(clip);
                GameObject hit1Explosion = Instantiate(hitExplosion,transform.position,Quaternion.identity) as GameObject;
            }
            else if(playerHealth <= 0f && !playerRegenBoost) {
                dead = true;
                AudioClip clip = playerSounds[2];
                myAudioSource.PlayOneShot(clip);
                GameObject dieExplosion = Instantiate(deathExplosion,transform.position,Quaternion.identity) as GameObject;
                GamePlayManager.gameOver = true;
                thisGameOver = true;
                this.GetComponent<SpriteRenderer>().enabled = false;
            }
        }

        if(other.gameObject.tag == "Meteor" && !dead) {
            AudioClip clip = playerSounds[2];
            myAudioSource.PlayOneShot(clip);
            GameObject dieExplosion = Instantiate(deathExplosion,transform.position,Quaternion.identity) as GameObject;
            GamePlayManager.gameOver = true;
            thisGameOver = true;
            this.GetComponent<SpriteRenderer>().enabled = false;
        }

        if(other.gameObject.tag == "planetRegenerateBoost" && playerHealth > 0f) {
            //Debug.Log("HEALTH BOOST");
            
            playerRegenBoost = true;
            Destroy(other.gameObject);
            ScoreManager.currentScore += 1000f;
            AudioClip clip = playerSounds[3];
            myAudioSource.PlayOneShot(clip);
            GameObject powerUp1Explosion = Instantiate(powerUpExplosion,transform.position,Quaternion.identity) as GameObject;
            playerHealth = 100f;
            InfinitePlayerHealth.regenerateBoost = true;
        }

        if(other.gameObject.tag == "playerShootingBoost" && !dead) {
            
            //Debug.Log("SHOOTING BOOST");
            ScoreManager.currentScore += 1000f;
            Destroy(other.gameObject);
            AudioClip clip = playerSounds[3];
            myAudioSource.PlayOneShot(clip);
            GameObject powerUp1Explosion = Instantiate(powerUpExplosion,transform.position,Quaternion.identity) as GameObject;
            firingRate = .1f;
            firingBoostCountDown = true;
        }

        if(other.gameObject.tag == "planetShieldBoost" && !dead) {
            
            //Debug.Log("SPEED BOOST!");
            ScoreManager.currentScore += 1000f;
            Destroy(other.gameObject);
            AudioClip clip = playerSounds[3];
            myAudioSource.PlayOneShot(clip);
            GameObject powerUp1Explosion = Instantiate(powerUpExplosion,transform.position,Quaternion.identity) as GameObject;
            moveSpeed = 20f;
            speedBoostCountDown = true;
        }
    }

    void MovePlayer() {
        deltaX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        newXPos = Mathf.Clamp(transform.position.x + deltaX,xMin,xMax);
        transform.position = new Vector2(newXPos,transform.position.y);
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
    }
}
