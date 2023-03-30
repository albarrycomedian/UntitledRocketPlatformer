using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    private float mainThrust = 1000.0f;
    private float rotationThrust = 100.0f;

    private bool disableMovement;
    private Rigidbody rb;

    [SerializeField] ParticleSystem mainThrusterParticles;

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
            CheckAndAdjustPosition();
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
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationThrust);
        UnfreezeRotations();
    }

    private void UnfreezeRotations(){
        rb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationY;
    }

    private void CheckAndAdjustPosition(){
        if(transform.position.z != 0f){
            transform.SetLocalPositionAndRotation(new Vector3(transform.position.x, transform.position.y, 0f), transform.rotation);
        }
        if(transform.rotation.y != 0f){
            transform.SetLocalPositionAndRotation(transform.position, 
                new Quaternion(transform.rotation.x, 0f, transform.rotation.z, transform.rotation.w));
        }
        if(transform.rotation.x != 0f){
            transform.SetLocalPositionAndRotation(transform.position, 
            new Quaternion(0f, transform.rotation.y, transform.rotation.z, transform.rotation.w));;
        }
    }

    public void SetDisableMovementTrue(){
        disableMovement = true;
    }

}
