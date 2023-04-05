using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionHandler : MonoBehaviour
{
    private GameObject canvas;
    private LevelHandler levelHandler;
    private LivesScript livesScript;
    private Movement movement;
    private Rigidbody rb; 
    private RocketAudioProcessor rocketAudioProcessor;
    private FuelScript fuel;
    private HealthScript health;

    // Potentially should be part of a commons script
    private bool isTransitioning = false;

    /**
    * Get the scripts and components we will use.
    */
    private void Start (){
        rb = GetComponent<Rigidbody>();
        movement = GetComponent<Movement>();
        rocketAudioProcessor = GetComponent<RocketAudioProcessor>();
        canvas = GameObject.Find(Constants.CANVAS_OBJCET);
        levelHandler = canvas.GetComponent<LevelHandler>();
        fuel = canvas.GetComponent<FuelScript>();
        health = canvas.GetComponent<HealthScript>();
        livesScript = canvas.GetComponent<LivesScript>();
    }

    /**
    * Process behaviors for various collisions types.
    * 
    * Param: other
    */
    private void OnCollisionEnter(Collision other) {
        if (isTransitioning){
            return;
        }
        
        switch (other.gameObject.tag){
            case "Finish":
                levelHandler.ProcessLevelCompletedSequence();
                break;
            case "Fuel":
                fuel.Refuel();
                break;
            case "LaunchPad":
                // Launch Pad
                break;
            case "Health":
                health.ProcessPickupHealth();
                break;
            case "1Up":
                livesScript.oneUp();
                break;
            case "GodMode":
                health.EngageGodMode();
                break;
            case "LargeHazard":
                health.ProcessLargeHazardCollision();
                break;
            case "SmallHazard":
                health.ProcessSmallHazardCollision();
                break;
            default:
                health.ProcessLargeHazardCollision();
                Debug.Log("Collision not handled, defaulting to destroy rocket");
                break;
        }
    }

    /**
    * Set's transitioning to true.
    */
    public void SetIsTransitioningTrue(){
        isTransitioning = true;
    }

    /**
    * Set's transitioning to false.
    */
    public bool GetIsTransitioningTrue(){
        return isTransitioning;
    }

}
