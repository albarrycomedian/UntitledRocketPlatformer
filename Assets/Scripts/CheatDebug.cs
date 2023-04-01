using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatDebug : MonoBehaviour
{
    private BoxCollider boxCollider;
    private LevelHandler levelHandler;
    private GameObject canvas;
    private bool collidersEnabled;

    private void Start(){
        canvas = GameObject.Find(Constants.CANVAS_NAME);
        levelHandler = canvas.GetComponent<LevelHandler>();
        boxCollider = GetComponent<BoxCollider>();
        collidersEnabled = true;
        enableColliders(gameObject);
    }

    private void Update() {
        cheatNextLevel();
        toggleCollisions();
    }

     private void cheatNextLevel(){
        if(Input.GetKeyDown(KeyCode.L)){
            levelHandler.LoadNextLevel();
        }
    }

     private void toggleCollisions(){
        if(Input.GetKeyDown(KeyCode.C)){
            if(collidersEnabled){
                disableColliders(gameObject);
            } else{
                enableColliders(gameObject);
            }
            boxCollider.enabled = !boxCollider.enabled;
        } 
    }

    private void disableColliders(GameObject gameObject){
        for(int i = 0; i < gameObject.transform.childCount; i++){
            
            if(gameObject.transform.GetChild(i).childCount > 0){
                disableColliders(gameObject.transform.GetChild(i).gameObject);
            }

            if(transform.GetChild(i).GetComponent<BoxCollider>() != null){
                transform.GetChild(i).GetComponent<BoxCollider>().enabled = false;
            } else if(transform.GetChild(i).GetComponent<CapsuleCollider>() != null){
                transform.GetChild(i).GetComponent<CapsuleCollider>().enabled = false;
            }
        }
        collidersEnabled = false;
    }

    private void enableColliders(GameObject gameObject){
        for(int i = 0; i < gameObject.transform.childCount; i++){

            if(gameObject.transform.GetChild(i).childCount > 0){
                enableColliders(gameObject.transform.GetChild(i).gameObject);
            }

            if(transform.GetChild(i).GetComponent<BoxCollider>() != null){
                transform.GetChild(i).GetComponent<BoxCollider>().enabled = true;
            } else if(transform.GetChild(i).GetComponent<CapsuleCollider>() != null){
                transform.GetChild(i).GetComponent<CapsuleCollider>().enabled = true;
            }
        }
        collidersEnabled = true;
    }
}
