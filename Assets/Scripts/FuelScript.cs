using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FuelScript : MonoBehaviour
{
    private float decrementSpeed = 2f;
    private float fuel;  
    private GameObject fueltTextObject;
    private GameObject rocket;
    private Text fuelText;  

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
                fuel = 0; // Fuel shouldn't be lower then zero.
            }
            fuelText.text = GetFuelText(fuel);
        }
    }

    /**
    * Get the fuel text to display on the canvas.
    *
    * Param: fuel, float that contains current fuel level.
    * Return: fuelText, the text to display on the canvas.
    */
    private string GetFuelText(float fuel){
        string fuelText = "Fuel: " + fuel.ToString("00") + " %";

        return fuelText;
    }

    /**
    * Resets fuel level.
    */
    public void Refuel(){
        fuel = 100;
    }
}
