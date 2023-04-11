using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    // Update is called once per frame
    private void Update(){
        processQuitApp();
    }

    /**
    * Quit the application.
    * 
    * TODO: Complete method.
    */
    private void processQuitApp(){
        if(Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("You are trying to quit the game");
        }
    }
}
