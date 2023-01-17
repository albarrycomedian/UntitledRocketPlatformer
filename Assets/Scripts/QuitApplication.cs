using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        processQuitApp();
    }

    private void processQuitApp()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("You are trying to quit the game");
        }
    }
}
