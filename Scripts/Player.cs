using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject playerLaserPrefab;
    [SerializeField] List<GameObject> laserInstantiationPoints;
    [SerializeField] float padding = 1f;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float powerUpDuration = 5f;
    [SerializeField] float laserMoveSpeed = 250f;
    [SerializeField] GameObject powerUpExplosion;
    [SerializeField] GameObject playerDeathExplosion;
    [SerializeField] AudioClip[] playerSounds;
    AudioSource myAudioSource;
    float xMin, xMax, yMin, yMax, deltaX, deltaY, newXPos, newYPos;
    public static float playerHealth = 100f;
    bool dead, fireAgain, moreCannonsPowerUp, thisGameOver; 
    Quaternion currentAngle;
    
    void Awake()
    {
        dead = false;
        myAudioSource = this.GetComponent<AudioSource>();
        this.transform.GetChild(3).gameObject.SetActive(false);
        this.transform.GetChild(4).gameObject.SetActive(false);
        playerHealth = 100f;
    }
    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
        fireAgain = true;
    }

    void Update()
    {
        

        if(HealthBar.playerDead && playerHealth <= 0) {
            thisGameOver = true;
            HealthBar.playerDead = false;
            AudioClip clip = playerSounds[2];
            myAudioSource.PlayOneShot(clip);
            GameObject deathExplosionInstance = Instantiate(playerDeathExplosion,transform.position,Quaternion.identity) as GameObject;
            this.GetComponent<SpriteRenderer>().enabled = false;
            GameTracker.finiteGameOver = true;
        }

        if(Input.GetKey(KeyCode.Space)) {
            if(fireAgain && !thisGameOver) {
                fireAgain = false;
                StartCoroutine(FireRoutine());
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!thisGameOver) {
            MovePlayer();
        }
    }

    IEnumerator FireRoutine() {
        yield return new WaitForSeconds(.15f);
        GameObject laserInstance3 = Instantiate(playerLaserPrefab,laserInstantiationPoints[2].transform.position,Quaternion.identity) as GameObject;
        laserInstance3.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,laserMoveSpeed * Time.fixedDeltaTime);
        fireAgain = true;
        if(moreCannonsPowerUp) {
            GameObject laserInstance1 = Instantiate(playerLaserPrefab,laserInstantiationPoints[0].transform.position,Quaternion.identity) as GameObject;
            laserInstance1.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,laserMoveSpeed * Time.fixedDeltaTime);
            GameObject laserInstance2 = Instantiate(playerLaserPrefab,laserInstantiationPoints[1].transform.position,Quaternion.identity) as GameObject;
            laserInstance2.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,laserMoveSpeed * Time.fixedDeltaTime);
        }
        AudioClip clip = playerSounds[0];
        myAudioSource.PlayOneShot(clip);
    }

    void MovePlayer() {
        deltaX = Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed;
        newXPos = Mathf.Clamp(transform.position.x + deltaX,xMin,xMax);
        transform.position = new Vector2(newXPos,transform.position.y);
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    IEnumerator CannonsPowerUpRoutine() {
        yield return new WaitForSeconds(powerUpDuration);
        this.transform.GetChild(3).gameObject.SetActive(false);
        this.transform.GetChild(4).gameObject.SetActive(false);
        moreCannonsPowerUp = false;
        PowerUpGenerator.shootingBoost = false;
        PowerUpGenerator.powerUpActive = false;
    }

    IEnumerator PlanetShieldRoutine() {
        yield return new WaitForSeconds(powerUpDuration);
        PowerUpGenerator.shieldBoost = false;
        PowerUpGenerator.powerUpActive = false;
    }

    IEnumerator PlanetRegenerateRoutine() {
        yield return new WaitForSeconds(powerUpDuration);
        HealthBar.increaseRate = 1f;
        PowerUpGenerator.regenerateBoost = false;
        PowerUpGenerator.powerUpActive = false;
    }
    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "playerShootingBoost" && !dead) {
            AudioClip clip = playerSounds[3];
            myAudioSource.PlayOneShot(clip);
            GameObject powerUpExplosionInstance = Instantiate(powerUpExplosion,transform.position,Quaternion.identity) as GameObject;
            this.transform.GetChild(3).gameObject.SetActive(true);
            this.transform.GetChild(4).gameObject.SetActive(true);
            StartCoroutine(CannonsPowerUpRoutine());
            PowerUpGenerator.shootingBoost = true;
            moreCannonsPowerUp = true;
            PowerUpGenerator.powerUpActive = true;
        }
        if(collisionInfo.gameObject.tag == "planetShieldBoost" && !dead) {
            AudioClip clip = playerSounds[3];
            myAudioSource.PlayOneShot(clip);
            GameObject powerUpExplosionInstance = Instantiate(powerUpExplosion,transform.position,Quaternion.identity) as GameObject;
            StartCoroutine(PlanetShieldRoutine());
            PowerUpGenerator.shieldBoost = true;
            PowerUpGenerator.powerUpActive = true;
        }
        if(collisionInfo.gameObject.tag == "planetRegenerateBoost" && !dead) {
            AudioClip clip = playerSounds[3];
            myAudioSource.PlayOneShot(clip);
            GameObject powerUpExplosionInstance = Instantiate(powerUpExplosion,transform.position,Quaternion.identity) as GameObject;
            StartCoroutine(PlanetRegenerateRoutine());
            HealthBar.increaseRate = 2f;
            PowerUpGenerator.regenerateBoost = true;
            PowerUpGenerator.powerUpActive = true;
        }
        if(collisionInfo.gameObject.tag == "EnemyLaser" && playerHealth > 0) {
            playerHealth -= 20f;
            if(playerHealth > 0) {
                this.GetComponent<Animator>().SetBool("isHit",true);
                StartCoroutine(WaitAndEndHitState());
                AudioClip clip = playerSounds[1];
                myAudioSource.PlayOneShot(clip);
            }
            if(playerHealth <= 0) {
                dead = true;
            }
        }
        Destroy(collisionInfo.gameObject);
    }

    IEnumerator WaitAndEndHitState() {
        yield return new WaitForSeconds(.5f);
        this.GetComponent<Animator>().SetBool("isHit",false);
    }
}
