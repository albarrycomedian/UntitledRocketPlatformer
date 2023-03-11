using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 2.0f;
    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem finishParticles;
    GameObject canvas;
    LivesScript livesScript;
    RocketAudioProcessor rocketAudioProcessor;
    Movement movement;

    private void Start(){
        rocketAudioProcessor = GetComponent<RocketAudioProcessor>();
        canvas = GameObject.Find("Canvas");
        livesScript = canvas.GetComponent<LivesScript>();
        movement = GetComponent<Movement>();
    }

    private void nextLevel(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        var state = new GameObject("State");
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
        GetComponent<CollisionHandler>().SetIsTransitioningTrue();
        movement.SetDisableMovementTrue();  
        crashParticles.Play();
        rocketAudioProcessor.playCrash();
        rocketAudioProcessor.setDisableAudioTrue();
        Invoke(nameof(ReloadLevel), delayInSeconds);
    }

    private void NextLevelSequence()
    {
        GetComponent<CollisionHandler>().SetIsTransitioningTrue();
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
