using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image myHealthBar;
    public Image planetHealthBar;
    public static float currentHealth = 100f;
    public static float currentPlanetHealth = 100f;
    private float maxHealth = 100f;
    private float maxPlanetHealth = 100f;
    public static float increaseRate;

    public static bool playerDead, planetDead;
    [SerializeField] float rateOfDecrease = 15f;

    Image planetHealthBarColor;

    void Awake()
    {
        planetHealthBarColor = planetHealthBar.GetComponent<Image>();
        planetHealthBar.color = Color.blue;
        currentHealth = 100f;
        currentPlanetHealth = 100f;
        maxHealth = 100f;
        maxPlanetHealth = 100f;
    }

    // Start is called before the first frame update
    void Start()
    {
        myHealthBar = this.GetComponent<Image>();
        increaseRate = 1f;
        playerDead = false;
        planetDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        OnHitDecreasePlanetHealth();
        OnHitDecreasePlayerHeath();
    }

    void OnHitDecreasePlanetHealth() {
        if(PowerUpGenerator.shieldBoost) {
            PowerUpGenerator.shootingBoost = false;
            PowerUpGenerator.regenerateBoost = false;
            planetHealthBarColor.color = Color.green;
            ////Debug.Log("SHIELD");
        }
        else if(PowerUpGenerator.regenerateBoost) {
            PowerUpGenerator.shieldBoost = false;
            PowerUpGenerator.shieldBoost = false;
            planetHealthBarColor.color = Color.red;
            ////Debug.Log("REGENERATE");
        }
        else if(!PowerUpGenerator.regenerateBoost && !PowerUpGenerator.shieldBoost) {
            planetHealthBarColor.color = Color.blue;
        }
        if(currentPlanetHealth > PlanetHealthBar.planetHealth) {
            currentPlanetHealth -= Time.deltaTime * rateOfDecrease;
        }
        else {
            if(currentPlanetHealth < 100f) {
                currentPlanetHealth += Time.deltaTime * increaseRate;
            }
            if(PlanetHealthBar.planetHealth < 100f) {
                PlanetHealthBar.planetHealth += Time.deltaTime * increaseRate;    
            }
        }
        if(currentPlanetHealth <= 0 && PlanetHealthBar.planetHealth <= 0) {
            planetDead = true;
            EnemyInstantiatingManager.finiteLevelOver = true;
            GameTracker.finiteGameOver = true;
        }
        float fillValue = currentPlanetHealth / maxPlanetHealth;
        planetHealthBar.fillAmount = fillValue;
    }

    void OnHitDecreasePlayerHeath() {
        if(currentHealth > Player.playerHealth) {
            currentHealth -= Time.deltaTime * rateOfDecrease;
        }
        if(currentHealth <= 0) {
            playerDead = true;
            EnemyInstantiatingManager.finiteLevelOver = true;
        }
        float fillValue = currentHealth / maxHealth;
        myHealthBar.fillAmount = fillValue;
        
    }
}
