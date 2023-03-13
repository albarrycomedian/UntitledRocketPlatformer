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
    private float decrementSpeed = .5f;
    private float fuel;  

    // Start is called before the first frame update
    private void Start(){
        fuel = 100;
        fueltTextObject = GameObject.Find("FuelText");
        rocket = GameObject.Find("Rocket");
        fuelText = fueltTextObject.GetComponent<Text>();
    }

    // Update is called once per frame
    private void Update(){
        ProcessFuel();
    }

    private void ProcessFuel(){        
        if (Input.GetKey(KeyCode.Space)){
            if (fuel > 0){
                fuel -= decrementSpeed * Time.deltaTime;
            } else if (fuel <= 0){
                rocket.GetComponent<Movement>().SetDisableMovementTrue();
            }
            //Debug.Log("You have this much fuel: " + Fuel);
            fuelText.text = "Fuel: " + fuel.ToString("00") + " %";
        }
    }

    public void Refuel(){
        fuel = 100;
    }
}
