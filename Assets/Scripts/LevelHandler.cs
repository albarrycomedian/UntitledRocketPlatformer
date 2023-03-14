using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    private float delayInSeconds = 2.0f;
    private GameObject canvas;
    private GameObject rocket;
    private LivesScript livesScript;
    private RocketAudioProcessor rocketAudioProcessor;
    private Movement movement;

    private const string ROCKET_TAG = "Player";
    private const string CANVAS_NAME = "Canvas";
    private const string STATE = "State";

    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem finishParticles;

    private void Start(){
        canvas = GameObject.Find(CANVAS_NAME);
        rocket = GameObject.FindWithTag(ROCKET_TAG);
        rocketAudioProcessor = rocket.GetComponent<RocketAudioProcessor>();
        livesScript = canvas.GetComponent<LivesScript>();
        movement = rocket.GetComponent<Movement>();
    }

    private void nextLevel(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        var state = new GameObject(STATE);
        var setState = state.AddComponent<LifeState>();

        setState.setLives(livesScript.getLives());
        DontDestroyOnLoad(state);

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings){
            nextSceneIndex = 0; 
        }

        SceneManager.LoadScene(nextSceneIndex);
    }

    private void Reload(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void CrashSequence(){
        rocket.GetComponent<CollisionHandler>().SetIsTransitioningTrue();
        movement.SetDisableMovementTrue();  
        crashParticles.Play();
        rocketAudioProcessor.playCrash();
        rocketAudioProcessor.setDisableAudioTrue();
        Invoke(nameof(ReloadLevel), delayInSeconds);
    }

    private void NextLevelSequence()
    {
        rocket.GetComponent<CollisionHandler>().SetIsTransitioningTrue();
        movement.SetDisableMovementTrue();
        rocketAudioProcessor.playFinish();
        rocketAudioProcessor.setDisableAudioTrue();
        finishParticles.Play();
        Invoke(nameof(LoadNextLevel), delayInSeconds);
    }

    public void ProcessNextLevelSequence(){
        NextLevelSequence();
    }

    public void ProcessCrashSequence(){
        CrashSequence();
    }

    public void LoadNextLevel(){
        nextLevel();
    }

    public void ReloadLevel(){
        Reload();
    }
}
