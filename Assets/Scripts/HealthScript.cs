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

    LevelHandler levelHandler;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        GetHealthString(health.ToString());
        levelHandler = GetComponent<LevelHandler>();
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
                    levelHandler.ProcessCrashSequence();

                    //TODO: Deduct Life
                } else{
                    healthText.text = GetHealthString(health.ToString());
                }
                break;
            case "LargeHazard":
                healthText.text = GetHealthString(NO_HEALTH);
                levelHandler.ProcessCrashSequence();

                //TODO: Deduct Life
                break;
            case "Friendly":
                break;
            case "Finish":
                break;
            default:
                health = 0;
                healthText.text = GetHealthString(health.ToString());
                levelHandler.ProcessCrashSequence();

                //TODO: Deduct Life
                break;
        }
    }

    private string GetHealthString(string health){
        string healthText = "Health: " + health + "%";
        return healthText;
    }
}
