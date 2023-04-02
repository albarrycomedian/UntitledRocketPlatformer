using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FuelScript : MonoBehaviour
{
    private GameObject fueltTextObject;
    private GameObject rocket;
    private Text fuelText;  
    private float decrementSpeed = 2f;
    private float fuel;  

    /**
    * Set variables and get the game objects and components we will use.
    */
    private void Start(){
        fuel = 100;
        fueltTextObject = GameObject.Find(Constants.FUEL_TEXT);
        rocket = GameObject.FindWithTag(Constants.ROCKET_TAG);
        fuelText = fueltTextObject.GetComponent<Text>();
    }

    /**
    * Check to see if we need to process fuel each frame.
    */
    private void Update(){
        ProcessFuel();
    }

    /**
    * Decrements fuel if the space button is being pushed.
    * Disables movement if fuel reaches 0.
    * Updates the fuel text.
    */
    private void ProcessFuel(){        
        if (Input.GetKey(KeyCode.Space)){
            if (fuel > 0){
                fuel -= decrementSpeed * Time.deltaTime;
            } else if (fuel <= 0){
                rocket.GetComponent<Movement>().SetDisableMovementTrue();
            }
            fuelText.text = "Fuel: " + fuel.ToString("00") + " %";
        }
    }

    /**
    * Resets fuel level.
    */
    public void Refuel(){
        fuel = 100;
    }
}
