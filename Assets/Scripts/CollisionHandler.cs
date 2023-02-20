using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionHandler : MonoBehaviour
{
    LevelHandler levelHandler;
    Movement movement;
    Rigidbody rb; 
    RocketAudioProcessor rocketAudioProcessor;

    bool isTransitioning = false;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        movement = GetComponent<Movement>();
        levelHandler = GetComponent<LevelHandler>();
        rocketAudioProcessor = GetComponent<RocketAudioProcessor>();
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (isTransitioning)
        {
            return;
        }
        switch (other.gameObject.tag)
        {
            case "Finish":
                levelHandler.ProcessNextLevelSequence();
                break;
            default:
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
