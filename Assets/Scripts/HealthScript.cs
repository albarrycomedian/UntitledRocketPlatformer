using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    private Text healthText;  
    private int health;
    private bool isVulnerable;
    private float godModeStartTimestamp;
    private float godModeThreshold = 30f;
    
    private GameObject canvas;
    private GameObject healthTextObject;
    private LivesScript livesScript;

    // Start is called before the first frame update
    private void Start(){
        health = 100;
        canvas = GameObject.Find(Constants.CANVAS_NAME);
        livesScript = canvas.GetComponent<LivesScript>();
        healthTextObject = GameObject.Find(Constants.HEALTH_TEXT);
        healthText = healthTextObject.GetComponent<Text>();
        healthText.text = GetHealthString(health.ToString());
        isVulnerable = true;
    }

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

    private string GetHealthString(string health){
        string healthText = "Shields: " + health + "%";
        return healthText;
    }

    private void OverrideHealthText(){
        float timeLeft = (godModeStartTimestamp + godModeThreshold) - Time.time;
        healthText.text = "Mega Shields " + string.Format("{0:N1}", timeLeft) + "S";
    }

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

    private void LargeHazardCollision(){
        if(isVulnerable){
            healthText.text = GetHealthString(Constants.NO_HEALTH);
            livesScript.oneDown();
        }
    }

    private void PickupHealth(){
        health = 100;
        healthText.text = GetHealthString(health.ToString());
    }

    private void StartGodMode(){
        godModeStartTimestamp = Time.time;
        isVulnerable = false;
    }

    public void ProcessSmallHazardCollision(){
        SmallHazardCollision();
    }

    public void ProcessLargeHazardCollision(){
        LargeHazardCollision();
    }

    public void ProcessPickupHealth(){
        PickupHealth();
    }

    public void EngageGodMode(){
        StartGodMode();
    }
}
