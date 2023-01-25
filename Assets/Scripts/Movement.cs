using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100.0f;
    [SerializeField] float rotationThrust = 100.0f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainThrusterParticles;
    Rigidbody rb;
    AudioSource audioSource;

    // Start is called before the first frame update
    private void Start(){
       rb = GetComponent<Rigidbody>();
       audioSource = GetComponent<AudioSource>();
       audioSource.Stop();
    }

    // Update is called once per frame
    private void Update(){
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust(){
        if (Input.GetKey(KeyCode.Space)){
            startThrusting();
        }
        else{
            stopThrusting();
        }
    }

    private void startThrusting(){
        rb.AddRelativeForce(Vector3.up * Time.deltaTime * mainThrust);
        if (!mainThrusterParticles.isPlaying)
        {
            mainThrusterParticles.Play();
        }
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
    }

    private void stopThrusting(){
        audioSource.Stop();
        mainThrusterParticles.Stop();
    }

    private void ProcessRotation(){
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)){
            //Do Nothing, as they cancel eachother out
        } else if (Input.GetKey(KeyCode.A)){
            rotateLeft();
        } else if (Input.GetKey(KeyCode.D)){
            rotateRight();
        }
    }

    private void rotateLeft(){
        ApplyRotationThrust(rotationThrust);
    }

    private void rotateRight(){
        ApplyRotationThrust(-rotationThrust);
    }

    private void ApplyRotationThrust(float rotationThrust) {
        rb.freezeRotation = true; //overrides physics system rotations
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationThrust);
        rb.freezeRotation = false;
    }

}
