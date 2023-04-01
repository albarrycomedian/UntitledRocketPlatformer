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

    // Start is called before the first frame update
    private void Start(){
        cycles = 0f;
        isMovable = true;
        startingPosition = transform.position;

        canvas = GameObject.Find(Constants.CANVAS_OBJCET);
        health = canvas.GetComponent<HealthScript>();
    }

    // Update is called once per frame
    private void Update(){
        if(isMovable){
            cycles += (0.25f * Time.deltaTime);
            processOffset(cycles); 
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(!health.isVulnerable && other.gameObject.tag == Constants.ROCKET_TAG){
            isMovable = false;
        }
    }

    private void OnCollisionExit(Collision other){
        if(!health.isVulnerable && other.gameObject.tag == Constants.ROCKET_TAG){
            isMovable = true;
        }
    }

    private void processOffset(float cycles){   
        const float tau = Mathf.PI * 2; // constant value of 6.283
        float rawSinWave = Mathf.Sin(cycles * tau); // going from -1 to 1 

        movementFactor = (rawSinWave + 1f) / 2f; // recalculated to go from 0 to 1

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
