using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    private AudioProcessor audioProcessor;
    private float delayInSeconds = 2.0f;
    private GameObject canvas;
    private GameObject rocket;
    private LivesScript livesScript;
    private Movement movement;

    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem finishParticles;

    /**
    * Get the game objects and scripts we will be using.
    */
    private void Start(){
        canvas = GameObject.Find(Constants.CANVAS_NAME);
        rocket = GameObject.FindWithTag(Constants.ROCKET_TAG);
        audioProcessor = rocket.GetComponent<AudioProcessor>();
        livesScript = canvas.GetComponent<LivesScript>();
        movement = rocket.GetComponent<Movement>();
    }

    /**
    * Stores the current state, currently just amount of lives, and loads the next scene.
    */
    private void nextLevel(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        var state = new GameObject(Constants.STATE);
        var setState = state.AddComponent<LifeState>();

        setState.setLives(livesScript.getLives());
        DontDestroyOnLoad(state);

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings){
            nextSceneIndex = 0; 
        }

        SceneManager.LoadScene(nextSceneIndex);
    }

    /**
    * Reload the current scene.
    *
    * TODO: Currently we are handling saving the state outside of this script when we reload the current scene.
    * Instead, reloading the scene should handle saving the game state.
    */
    private void Reload(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    /**
    * Sequence of events that occurs when the rocket crashes. Currently this is split with the lives script.
    *
    * TODO: Migrate this into the lives script, as the level handler should only take care of loading the scenes/levels.
    * Additionally, the crash sequence occurs when the rocket health has dropped to zero and the player loses a life.
    */
    private void CrashSequence(){
        audioProcessor.playCrash();
        audioProcessor.setDisableAudioTrue();
        rocket.GetComponent<CollisionHandler>().SetIsTransitioningTrue();
        movement.SetDisableMovementTrue();  
        crashParticles.Play();
        Invoke(nameof(ReloadLevel), delayInSeconds);
    }

    /**
    * Sequence of events that occurs when the player succesfully lands on the landing pad.
    *
    */
    private void LevelCompletedSequence()
    {
        audioProcessor.playFinish();
        audioProcessor.setDisableAudioTrue();
        rocket.GetComponent<CollisionHandler>().SetIsTransitioningTrue();
        movement.SetDisableMovementTrue();
        finishParticles.Play();
        Invoke(nameof(LoadNextLevel), delayInSeconds);
    }

    /**
    * Public method to call when the level has been completed.
    */
    public void ProcessLevelCompletedSequence(){
        LevelCompletedSequence();
    }

    /**
    * Public method to call when the rocket has been destroyed.
    */
    public void ProcessCrashSequence(){
        CrashSequence();
    }

    /**
    * Public method to call to load the next level.
    */
    public void LoadNextLevel(){
        nextLevel();
    }

    /**
    * Public method to call to reload the current level.
    */
    public void ReloadLevel(){
        Reload();
    }
}
