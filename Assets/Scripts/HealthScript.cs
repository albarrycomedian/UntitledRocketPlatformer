using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    private Text healthText;  
    private int health;
    
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
    }

    private string GetHealthString(string health){
        string healthText = "Health: " + health + "%";
        return healthText;
    }

    private void SmallHazardCollision(){
        health -= 10;
        if(health <= 0){
            healthText.text = GetHealthString(Constants.NO_HEALTH);
            livesScript.oneDown();
        } else{
            healthText.text = GetHealthString(health.ToString());
        }
    }

    private void LargeHazardCollision(){
        healthText.text = GetHealthString(Constants.NO_HEALTH);
        livesScript.oneDown();
    }

    private void PickupHealth(){
        health = 100;
        healthText.text = GetHealthString(health.ToString());
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
}
