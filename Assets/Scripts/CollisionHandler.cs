using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float delayInSeconds = 2.0f;
    [SerializeField] AudioClip Crash;
    [SerializeField] AudioClip Finish;
    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem finishParticles;


    AudioSource audioSource;
    Rigidbody rb; 
    bool isTransitioning = false;
   // [SerializeField] float health;

    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    void Update ()
    {
        
    }
    private void OnCollisionEnter(Collision other) 
    {
        if (isTransitioning)
        {
            return;
        }
        switch (other.gameObject.tag)
        {
            case "Finish":
                startNextLevelSequence();
                break;
            case "Fuel":
                //Debug.Log("You picked up fuel!");
                break;
            case "Friendly":
                Debug.Log("I'm your friend. My name is Friendly");
                break;
            //case "Health":
               // health = 100;
               // break;
            default:
                //startDamageSequence();
                startCrashSequence();
                break;
        }

       // HealthText.text = "Shields: " + health.ToString("00") + "%"; 
    }
    private void startCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(Crash);
        crashParticles.Play();
        Invoke(nameof(reloadLevel), delayInSeconds);
        GetComponent<Movement>().enabled = false;     
    }
   /* private void startDamageSequence()
    {
        health -= 25;
    } */
    
    private void startNextLevelSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(Finish);
        finishParticles.Play();
        Invoke(nameof(loadNextLevel), delayInSeconds);
        GetComponent<Movement>().enabled = false;
        
    }
    private void reloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    private void loadNextLevel()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex  = currentSceneIndex + 1;
            if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            {
                nextSceneIndex = 0; 
            }
            SceneManager.LoadScene(nextSceneIndex);
        }
}
