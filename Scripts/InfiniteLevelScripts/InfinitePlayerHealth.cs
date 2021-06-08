using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfinitePlayerHealth : MonoBehaviour
{
    private Image myHealthBar;
    public static float currentHealth = 100f;
    private float maxHealth = 100f, regenerateBoostTimer, regenerateBoostTimerCap;
    public static bool playerDead, regenerateBoost;
    [SerializeField] float rateOfDecrease = 30f;


    // Start is called before the first frame update
    void Start()
    {
        myHealthBar = this.GetComponent<Image>();
        myHealthBar.color = Color.green;
        playerDead = false;
        regenerateBoostTimerCap = 7f;
        regenerateBoostTimer = 0f;
        currentHealth = 100f;
        maxHealth = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        OnHitDecreasePlayerHeath();
    }

    void OnHitDecreasePlayerHeath() {
        if(currentHealth > InfinitePlayer.playerHealth) {
            currentHealth -= Time.deltaTime * rateOfDecrease;
        }
        if(regenerateBoost) {
            regenerateBoostTimer += Time.deltaTime;
            currentHealth += Time.deltaTime * rateOfDecrease;
            myHealthBar.color = Color.blue;
            if(regenerateBoostTimer >= regenerateBoostTimerCap) {
                regenerateBoostTimer = 0f;
                regenerateBoost = false;
                InfinitePlayer.playerRegenBoost = false;
                myHealthBar.color = Color.green;
            }
        }
        if(currentHealth <= 0) {
            playerDead = true;
        }
        float fillValue = currentHealth / maxHealth;
        myHealthBar.fillAmount = fillValue;
        
    }
}
