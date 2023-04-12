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

    /**
    * Initialize our variables.
    */
    private void Start(){
       rb = GetComponent<Rigidbody>();
       disableMovement = false;
    }

    /**
    * Check if movement is disabled and either stop thrusting or process movment.
    * We also need to perform error checking in case God mode is enabled.
    */
    private void Update(){
        if (!disableMovement){
            ProcessThrust();
            ProcessRotation();
            CheckAndAdjustPosition();
        } else {
            StopThrusting();
        }
    }

    /**
    * Apply force to the rocket if the player is pushing the space button.
    */
    private void ProcessThrust(){
        if (Input.GetKey(KeyCode.Space)){
            StartThrusting();
        } else{
            StopThrusting();
        }
    }

    /**
    * Apply force to the rocket and play particles.
    */
    private void StartThrusting(){
        rb.AddRelativeForce(Vector3.up * Time.deltaTime * mainThrust);
        if (!mainThrusterParticles.isPlaying)
        {
            mainThrusterParticles.Play();
        }
    }

    /**
    * Turn off thruster particles.
    */
    private void StopThrusting(){
        mainThrusterParticles.Stop();
    }

    /**
    * Process rotation if player is pushing A or D key. Do nothing if both keys are pressed.
    */
    private void ProcessRotation(){
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)){
            //Do Nothing, as they cancel eachother out
        } else if (Input.GetKey(KeyCode.A)){
            RotateLeft();
        } else if (Input.GetKey(KeyCode.D)){
            RotateRight();
        }
    }

    /**
    * Rotate the rocket left.
    */    
    private void RotateLeft(){
        ApplyRotationThrust(rotationThrust);
    }

    /**
    * Rotate the rocket right.
    */
    private void RotateRight(){
        ApplyRotationThrust(-rotationThrust);
    }

    /**
    * Rotate rocket using transform.Rotate. Freeze rotations before rotating the rocket.
    * Unfreeze rotations after rotating the rocket.
    *
    * TODO: Rename this method, as we aren't applying any force, rather rotating the object by 
    * manipulating the transform.
    */
    private void ApplyRotationThrust(float rotationThrust) {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationThrust);
        UnfreezeRotations();
    }

    /**
    * Unfreeze the rotations, but restore our original constraints by constructing a mask.
    */
    private void UnfreezeRotations(){
        rb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationY;
    }

    /**
    * Error correcting if there is any displacement along the Z axis.
    * Additionally also error correcting if there is any rotation along the Y or X axis, which would result in displacement in Z.
    * Without this the invulnerability powerup would break the game. This also fixes a bug where the rocket can become displaced
    * in world space while still on the landing pad.
    */
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

    /**
    * Disables movement.
    */
    public void SetDisableMovementTrue(){
        disableMovement = true;
    }

}
