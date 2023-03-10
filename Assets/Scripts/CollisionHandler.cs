using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionHandler : MonoBehaviour
{
    private GameObject canvas;
    private LevelHandler levelHandler;
    private Movement movement;
    private Rigidbody rb; 
    private RocketAudioProcessor rocketAudioProcessor;
    private FuelScript fuel;
    private HealthScript health;

    private bool isTransitioning = false;

    private void Start (){
        rb = GetComponent<Rigidbody>();
        movement = GetComponent<Movement>();
        rocketAudioProcessor = GetComponent<RocketAudioProcessor>();
        canvas = GameObject.Find("Canvas");
        levelHandler = canvas.GetComponent<LevelHandler>();
        fuel = canvas.GetComponent<FuelScript>();
        health = canvas.GetComponent<HealthScript>();
    }

    private void OnCollisionEnter(Collision other) {
        if (isTransitioning){
            return;
        }
        
        switch (other.gameObject.tag){
            case "Finish":
                levelHandler.ProcessNextLevelSequence();
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

    public void SetIsTransitioningTrue(){
        isTransitioning = true;
    }

    public bool GetIsTransitioningTrue(){
        return isTransitioning;
    }

}
