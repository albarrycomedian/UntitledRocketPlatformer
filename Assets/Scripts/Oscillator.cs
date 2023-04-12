using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    private GameObject canvas;
    private Vector3 startingPosition;
    private Vector3 rotatingPosition;
    private float movementFactor;
    private HealthScript health;
    private float cycles;

    private bool isMovable;

    [SerializeField] Vector3 movementVector;

    /**
    * Initialize our variables.
    */
    private void Start(){
        cycles = 0f;
        isMovable = true;
        startingPosition = transform.position;

        canvas = GameObject.Find(Constants.CANVAS_OBJCET);
        health = canvas.GetComponent<HealthScript>();
    }

    /**
    * Check to see if the oscillating obstacle is movable. If so, run the clock and process the offset.
    */
    private void Update(){
        if(isMovable){
            //Effectively the clock, this will overflow to negative values when we hit 3.402823466 E + 38
            //I'm not sure what will happen when/if this occurs, I would assume the obstacle will teleport for a single frame.
            cycles += (0.25f * Time.deltaTime);
            processOffset(cycles); 
        }
    }

    /**
    * Check and see if we've collided with a rocket that is invulnerable. 
    * If so, then disable movement to avoid bugs.
    *
    * Param: other
    */
    private void OnCollisionEnter(Collision other) {
        if(!health.isVulnerable && other.gameObject.tag == Constants.ROCKET_TAG){
            isMovable = false;
        }
    }

    /**
    * check and see if we've stopped colliding with an invulnerable rocket.
    * If so, then enable movement.
    * 
    * Param: other
    */
    private void OnCollisionExit(Collision other){
        if(!health.isVulnerable && other.gameObject.tag == Constants.ROCKET_TAG){
            isMovable = true;
        }
    }

    /**
    * Calculate the offset from the original position to move the object.
    * 
    * Param: cycles
    */
    private void processOffset(float cycles){   
        const float tau = Mathf.PI * 2; // constant value of 6.283

        // The output of the Sin function is always a value between -1 and 1.
        // As our cycles grow the output of Sin will osscilate between -1 and 1
        float rawSinWave = Mathf.Sin(cycles * tau); 

        movementFactor = (rawSinWave + 1f) / 2f; // recalculated to go from 0 to 1

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
