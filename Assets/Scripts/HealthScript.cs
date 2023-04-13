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
        healthText.text = GetHealthString(health.ToString());
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
                healthText.text = GetHealthString(health.ToString());
            } else {
                OverrideHealthText();
            }
        }
    }

    /**
    * Get the health string to display.
    *
    * Param: health, A string containing the current health percent.
    * return: health string
    *
    * TODO: This should take in an integer instead of a string.
    * It should check the value of the int is between 0 and 100.
    * It should then convert the integer to a string.
    */
    private string GetHealthString(string health){
        string healthText = "Shields: " + health + "%";
        return healthText;
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
                healthText.text = GetHealthString(health.ToString());
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
        healthText.text = GetHealthString(health.ToString());
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
