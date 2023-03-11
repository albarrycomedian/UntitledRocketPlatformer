using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    [SerializeField] public Text healthText;  
    [SerializeField] int health;
    private const string NO_HEALTH = "0";
    
    GameObject canvas;
    LivesScript livesScript;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        healthText.text = GetHealthString(health.ToString());
        canvas = GameObject.Find("Canvas");
        livesScript = canvas.GetComponent<LivesScript>();
    }

    private void OnCollisionEnter(Collision other){
        if(GetComponent<CollisionHandler>().GetIsTransitioningTrue()){
            return;
        }
        switch (other.gameObject.tag){
            case "SmallHazard": 
                health -= 10;
                if(health <= 0){
                    healthText.text = GetHealthString(NO_HEALTH);
                    livesScript.oneDown();
                } else{
                    healthText.text = GetHealthString(health.ToString());
                }
                break;
            case "LargeHazard":
                healthText.text = GetHealthString(NO_HEALTH);
                livesScript.oneDown();
                break;
            case "Health":
                health = 100;
                healthText.text = GetHealthString(health.ToString());
                break;
            case "Friendly":
                break;
            case "Finish":
                break;
            case "Fuel":
                break;
            default:
                health = 0;
                healthText.text = GetHealthString(health.ToString());
                livesScript.oneDown();
                break;
        }
    }

    private string GetHealthString(string health){
        string healthText = "Health: " + health + "%";
        return healthText;
    }
}
