using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FuelScript : MonoBehaviour
{
    [SerializeField] public Text fuelText;  
    [SerializeField] float decrementSpeed = .5f;
    [SerializeField] float fuel;  

    // Start is called before the first frame update
    void Start()
    {
        fuel = 100;
    }

    // Update is called once per frame
    void Update(){
        ProcessFuel();
    }

    private void OnCollisionEnter(Collision other){
        if (other.gameObject.tag == "Fuel"){
                fuel = 100;
        }
    }

    private void ProcessFuel(){        
        if (Input.GetKey(KeyCode.Space)){
            if (fuel > 0){
                fuel -= decrementSpeed * Time.deltaTime;
                GetComponent<Movement>().enabled = true;
            } else if (fuel <= 0){
                GetComponent<Movement>().enabled = false;
            }
            //Debug.Log("You have this much fuel: " + Fuel);
            fuelText.text = "Fuel: " + fuel.ToString("00") + " %";
        }
    }
}
