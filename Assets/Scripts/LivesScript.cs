using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LivesScript : MonoBehaviour
{
    private GameObject livesTextObject;
    private GameObject rocket;
    private int lives;
    private LevelHandler levelHandler;
    private Text livesText;  

    /**
    * Initialize game objects, components, and scripts.
    */
    private void Start(){
        rocket = GameObject.FindWithTag(Constants.ROCKET_TAG);
        livesTextObject = GameObject.Find(Constants.LIVES_TEXT);
        livesText = livesTextObject.GetComponent<Text>(); 
        levelHandler = GetComponent<LevelHandler>();
        var state = GameObject.Find(Constants.STATE);

        if(state == null){
            lives = 3;
            livesText.text = GetLivesString(lives);
        } else {
            var getState = state.GetComponent<LifeState>();
            lives = getState.getLives();
            livesText.text = GetLivesString(lives);
            Destroy(state);
        }
    }

    /**
    * Increase lives by one and update text.
    */
    private void performOneUp(){
        lives++;
        livesText.text = GetLivesString(lives);
    }

    /**
    * Decrease lives by one and check whether or not the player has lost the game.
    * If the player hasn't lost the game, destroy the rocket, save the game state and run the crash sequence.
    */
    private void performOneDown(){
        lives--;

        if(lives >= 0){
            var state = new GameObject(Constants.STATE_OBJECT);
            var setState = state.AddComponent<LifeState>();

            setState.setLives(lives);
            DontDestroyOnLoad(state);
            ExplodeRocket(rocket);
            levelHandler.ProcessCrashSequence();
        } else {
            //Game Over

            //TODO: Call Game Over Manager
        }
    }

    /**
    * Explode the rocket by adding Rigidbodys to the child objects and detaching them from the parent.
    * Param: gameObject
    */
    private void ExplodeRocket(GameObject gameObject){
        GameObject child;
        for(int i = 0; i < gameObject.transform.childCount; i++){
            child = gameObject.transform.GetChild(i).gameObject;
            if(child.transform.childCount > 0){
                ExplodeRocket(child);
            } else {
                child.AddComponent<Rigidbody>();
            }
        }
        gameObject.transform.DetachChildren();
    }

    /**
    * Get the lives string with the correct amount of lives as passed in as a paremeter.
    * Param: lives, string containing current lives count.
    * Return: lives string
    */
    private string GetLivesString(int lives){
        string livesText = "Lives: ";

        if (lives < 0){ // We should never have negative lives.
            lives = 0;
        }

        return livesText = livesText + lives.ToString();;
    }

    /**
    * Public method for calling oneUp.
    */
    public void oneUp(){
        performOneUp();
    }

    /**
    * Public method for calling oneDown.
    */
    public void oneDown(){
        performOneDown();
    }

    /**
    * Public method to get the count of current lives.
    */
    public int getLives(){
        return lives;
    }
}
