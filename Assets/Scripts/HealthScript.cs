using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    private Text healthText;  
    private int health;
    private float godModeStartTimestamp;
    private float godModeThreshold = 30f;
    
    private GameObject canvas;
    private GameObject healthTextObject;
    private LivesScript livesScript;

    // This will be moved to a common script
    public bool isVulnerable;


    /**
    * Sets variables and gets the game objects, components, and scripts we will use.
    */
    private void Start(){
        health = 100;
        canvas = GameObject.Find(Constants.CANVAS_NAME);
        livesScript = canvas.GetComponent<LivesScript>();
        healthTextObject = GameObject.Find(Constants.HEALTH_TEXT);
        healthText = healthTextObject.GetComponent<Text>();
        healthText.text = GetHealthString(health);
        isVulnerable = true;
    }

    /**
    * On each frame check to see if the rocket is vulnerable or not.
    * If it is not vulnerable override the health text with countdown for vulnerability.
    * If timer hits 0, restore vulnerability and health text.
    */
    private void Update(){
        if(!isVulnerable){
            if(Time.time > (godModeStartTimestamp + godModeThreshold)){
                isVulnerable = true;
                healthText.text = GetHealthString(health);
            } else {
                OverrideHealthText();
            }
        }
    }

    /**
    * Get the health string to display.
    *
    * Param: health, A integer containing the current health percent.
    * return: health string
    */
    private string GetHealthString(int health){
        string healthText = "Shields: ";

        // Health should always be between 0 and 100
        if(health < 0){
            health = 0;
        } else if(health > 100){
            health = 100;
        }

        return healthText = healthText + health.ToString() + "%";
    }

    /**
    * Override the health text with the mega shield text.
    */
    private void OverrideHealthText(){
        float timeLeft = (godModeStartTimestamp + godModeThreshold) - Time.time;
        healthText.text = "Mega Shields " + string.Format("{0:N1}", timeLeft) + "S";
    }

    /**
    * Process damage for collision with small hazard if rocket is vulnerable.
    */
    private void SmallHazardCollision(){
        if(isVulnerable){
            health -= 10;
            if(health <= 0){
                healthText.text = GetHealthString(Constants.NO_HEALTH);
                livesScript.oneDown();
            } else{
                healthText.text = GetHealthString(health);
            }
        }
    }

    /**
    * Process damage for large hazard collision if rocket is vulnerable.
    */
    private void LargeHazardCollision(){
        if(isVulnerable){
            healthText.text = GetHealthString(Constants.NO_HEALTH);
            livesScript.oneDown();
        }
    }

    /**
    * Restore health to 100.
    */
    private void PickupHealth(){
        health = 100;
        healthText.text = GetHealthString(health);
    }

    /**
    * Make rocket invulnerable.
    */
    private void StartGodMode(){
        godModeStartTimestamp = Time.time;
        isVulnerable = false;
    }

    /**
    * Public method to process small hazard damage.
    */
    public void ProcessSmallHazardCollision(){
        SmallHazardCollision();
    }

    /**
    * Public method to process large hazard damage.
    */
    public void ProcessLargeHazardCollision(){
        LargeHazardCollision();
    }

    /**
    * Public method to process health pickup.
    */
    public void ProcessPickupHealth(){
        PickupHealth();
    }

    /**
    * Public method to enable invulnerability.
    */
    public void EngageGodMode(){
        StartGodMode();
    }
}
