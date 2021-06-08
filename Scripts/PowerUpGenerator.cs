using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PowerUpGenerator : MonoBehaviour
{
    [SerializeField] List<GameObject> powerUps;

    [SerializeField] List<Transform> powerUpGeneratorPoints;

    [SerializeField] float powerUpObjectSpeed = -350f;

    float powerUpTimer, powerUpTimerCap;
    float minTimePowerUp = 10f;
    float maxTimePowerUp = 15f;

    public static bool powerUpActive, shootingBoost, shieldBoost, regenerateBoost;
    
    void Awake()
    {
        powerUpActive = false;
        shootingBoost = false;
        shieldBoost = false;
        regenerateBoost = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        powerUpTimerCap = Random.Range(minTimePowerUp,maxTimePowerUp);
        if(SceneManager.GetActiveScene().name == "InfiniteGameScene") {
            //Debug.Log("INFINITE LEVEL TIME");
            minTimePowerUp = 20f;
            maxTimePowerUp = 25f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!powerUpActive) {
            powerUpTimer += Time.deltaTime;
        }
        if(powerUpTimer > powerUpTimerCap) {
            powerUpTimerCap = Random.Range(minTimePowerUp,maxTimePowerUp);
            powerUpTimer = 0;
            int randomIndex = Mathf.RoundToInt(Random.Range(0,powerUps.Count));
            int randomIndex1 = Mathf.RoundToInt(Random.Range(0,powerUpGeneratorPoints.Count));
            GameObject powerUpInstance = Instantiate(powerUps[randomIndex],powerUpGeneratorPoints[randomIndex1].transform.position,Quaternion.identity);
            powerUpInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,powerUpObjectSpeed * Time.deltaTime);
        }
    }
}
