using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatDebug : MonoBehaviour
{
    private BoxCollider boxCollider;
    private LevelHandler LevelHandler;

    private void Start(){
        LevelHandler = GetComponent<LevelHandler>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void Update() {
        cheatNextLevel();
        toggleCollisions();
    }

     private void cheatNextLevel(){
        if(Input.GetKeyDown(KeyCode.L)){
            LevelHandler.LoadNextLevel();
        }
    }

     private void toggleCollisions(){
        if(Input.GetKeyDown(KeyCode.C)){
            boxCollider.enabled = !boxCollider.enabled;
            disableColliders();
        } 
    }

    private void disableColliders(){
         for(int i = 0; i < transform.childCount; i++){
            if(transform.GetChild(i).GetComponent<BoxCollider>() != null){
                transform.GetChild(i).GetComponent<BoxCollider>().enabled = false;
            } else if(transform.GetChild(i).GetComponent<CapsuleCollider>() != null){
                transform.GetChild(i).GetComponent<CapsuleCollider>().enabled = false;
            }
        }
    }
}
