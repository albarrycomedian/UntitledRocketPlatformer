using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatDebug : MonoBehaviour
{
    private bool collidersEnabled;
    private BoxCollider boxCollider;
    private GameObject canvas;
    private LevelHandler levelHandler;

    /**
    * Get the scripts we will use and enable colliders.
    */
    private void Start(){
        canvas = GameObject.Find(Constants.CANVAS_NAME);
        levelHandler = canvas.GetComponent<LevelHandler>();
        boxCollider = GetComponent<BoxCollider>();
        collidersEnabled = true;
        EnableColliders(gameObject);
    }

    /**
    * Check each frame to see if we should load the next level or toggle collisions.
    */
    private void Update() {
        processLevelCheat();
        toggleCollisions();
    }

    /**
    * Load the next level if the L key is pressed.
    */
    private void processLevelCheat(){
        if(Input.GetKeyDown(KeyCode.L)){
            levelHandler.LoadNextLevel();
        }
    }

    /**
    * Toggles the colliders on or off for the game object this script is attach to.
    */
    private void toggleCollisions(){
        if(Input.GetKeyDown(KeyCode.C)){
            if(collidersEnabled){
                DisableColliders(gameObject);
            } else{
                EnableColliders(gameObject);
            }
        } 
    }

    /**
    * Disables colliders for every child object attached to a game object.
    *
    * Param: gameObject whose colliders, and child colliders, will be disabled.
    */
    public void DisableColliders(GameObject gameObject){
        for(int i = 0; i < gameObject.transform.childCount; i++){
            
            if(gameObject.transform.GetChild(i).childCount > 0){
                DisableColliders(gameObject.transform.GetChild(i).gameObject);
            }

            if(transform.GetChild(i).GetComponent<BoxCollider>() != null){
                transform.GetChild(i).GetComponent<BoxCollider>().enabled = false;
            } else if(transform.GetChild(i).GetComponent<CapsuleCollider>() != null){
                transform.GetChild(i).GetComponent<CapsuleCollider>().enabled = false;
            }
        }
        boxCollider.enabled = false;
        collidersEnabled = false;
    }

    /**
    * Enables colliders for every child object attached to a game object.
    *
    * Param: gameObject whose colliders, and child colliders will be enabled.
    */
    private void EnableColliders(GameObject gameObject){
        for(int i = 0; i < gameObject.transform.childCount; i++){

            if(gameObject.transform.GetChild(i).childCount > 0){
                EnableColliders(gameObject.transform.GetChild(i).gameObject);
            }

            if(transform.GetChild(i).GetComponent<BoxCollider>() != null){
                transform.GetChild(i).GetComponent<BoxCollider>().enabled = true;
            } else if(transform.GetChild(i).GetComponent<CapsuleCollider>() != null){
                transform.GetChild(i).GetComponent<CapsuleCollider>().enabled = true;
            }
        }
        boxCollider.enabled = true;
        collidersEnabled = true;
    }
}
