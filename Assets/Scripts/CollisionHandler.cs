using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 2.0f;
    [SerializeField] ParticleSystem finishParticles;

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
                ProcessNextLevelSequence();
                break;
            default:
                break;
        }
    }
    
    private void ProcessNextLevelSequence()
    {
        isTransitioning = true;
        movement.SetDisableMovementTrue();
        rocketAudioProcessor.playFinish();
        rocketAudioProcessor.setDisableAudioTrue();
        finishParticles.Play();
        Invoke(nameof(LoadNextLevel), delayInSeconds);
    }

    private void ReloadLevel()
    {
        levelHandler.ReloadLevel();
    }

    private void LoadNextLevel(){
        levelHandler.LoadNextLevel();
    }

    public void SetIsTransitioningTrue(){
        isTransitioning = true;
    }

    public bool GetIsTransitioningTrue(){
        return isTransitioning;
    }

}
