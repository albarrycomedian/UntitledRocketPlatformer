using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatDebug : MonoBehaviour
{

    BoxCollider boxCollider;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }
    void Update()
    {
        cheatNextLevel();
        toggleCollisions();
    }
     private void cheatNextLevel()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;
            if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            {
                nextSceneIndex = 0;
            }
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
     private void toggleCollisions()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            boxCollider.enabled = !boxCollider.enabled;
        } 
    }
}
