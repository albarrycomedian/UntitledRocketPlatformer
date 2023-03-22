using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LivesScript : MonoBehaviour
{
    private int lives;
    private Text livesText;  

    private GameObject livesTextObject;
    private GameObject rocket;
    private LevelHandler levelHandler;

    // Start is called before the first frame update
    private void Start(){
        rocket = GameObject.FindWithTag(Constants.ROCKET_TAG);
        livesTextObject = GameObject.Find(Constants.LIVES_TEXT);
        livesText = livesTextObject.GetComponent<Text>(); 
        levelHandler = GetComponent<LevelHandler>();
        var state = GameObject.Find(Constants.STATE);

        if(state == null){
            lives = 3;
            livesText.text = GetLivesString(lives.ToString());
        } else {
            var getState = state.GetComponent<LifeState>();
            lives = getState.getLives();
            livesText.text = GetLivesString(lives.ToString());
            Destroy(state);
        }
    }

    private void performOneUp(){
        lives++;
        livesText.text = GetLivesString(lives.ToString());
    }

    private void performOneDown(){
        GameObject child;
        lives--;

        if(lives >= 0){
            var state = new GameObject("State");
            var setState = state.AddComponent<LifeState>();

            setState.setLives(lives);
            DontDestroyOnLoad(state);
            for(int i = 0; i < rocket.transform.childCount; i++){
                child = rocket.transform.GetChild(i).gameObject;
                child.AddComponent<Rigidbody>();
            }
            rocket.transform.DetachChildren();
            levelHandler.ProcessCrashSequence();
        } else {
            //Game Over

            //TODO: Call Game Over Manager
        }
    }

    private string GetLivesString(string lives){
        string livesText = "Lives: " + lives;
        return livesText;
    }

    public void oneUp(){
        performOneUp();
    }

    public void oneDown(){
        performOneDown();
    }

    public int getLives(){
        return lives;
    }
}
