using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    private void nextLevel(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings){
            nextSceneIndex = 0; 
        }

        SceneManager.LoadScene(nextSceneIndex);
    }

    private void Reload(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadNextLevel(){
        nextLevel();
    }

    public void ReloadLevel(){
        Reload();
    }
}
