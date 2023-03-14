using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{

    private Vector3 startingPosition;
    private Vector3 rotatingPosition;
    private float movementFactor;
    private float period = 4f;

    [SerializeField] Vector3 movementVector;

    // Start is called before the first frame update
    private void Start(){
        startingPosition = transform.position;
    }

    // Update is called once per frame
    private void Update(){
        if (period <= Mathf.Epsilon) 
        { 
            return; 
        }
        float cycles = Time.time / period; // contually growing over time
        
        const float tau = Mathf.PI * 2; // constant value of 6.283
        float rawSinWave = Mathf.Sin(cycles * tau); // going from -1 to 1 

        movementFactor = (rawSinWave + 1f) / 2f; // recalculated to go from 0 to 1

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
