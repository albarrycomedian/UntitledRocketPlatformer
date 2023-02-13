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
    [SerializeField] ParticleSystem mainThrusterParticles;

    bool disableMovement;
    Rigidbody rb;

    // Start is called before the first frame update
    private void Start(){
       rb = GetComponent<Rigidbody>();
       disableMovement = false;
    }

    // Update is called once per frame
    private void Update(){
        if (!disableMovement){
            ProcessThrust();
            ProcessRotation();
        } else {
            StopThrusting();
        }
    }

    private void ProcessThrust(){
        if (Input.GetKey(KeyCode.Space)){
            StartThrusting();
        } else{
            StopThrusting();
        }
    }

    private void StartThrusting(){
        rb.AddRelativeForce(Vector3.up * Time.deltaTime * mainThrust);
        if (!mainThrusterParticles.isPlaying)
        {
            mainThrusterParticles.Play();
        }
    }

    private void StopThrusting(){
        mainThrusterParticles.Stop();
    }

    private void ProcessRotation(){
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)){
            //Do Nothing, as they cancel eachother out
        } else if (Input.GetKey(KeyCode.A)){
            RotateLeft();
        } else if (Input.GetKey(KeyCode.D)){
            RotateRight();
        }
    }

    private void RotateLeft(){
        ApplyRotationThrust(rotationThrust);
    }

    private void RotateRight(){
        ApplyRotationThrust(-rotationThrust);
    }

    private void ApplyRotationThrust(float rotationThrust) {
        rb.freezeRotation = true; //overrides physics system rotations
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationThrust);
        rb.freezeRotation = false;
    }

    public void SetDisableMovementTrue(){
        disableMovement = true;
    }

}
