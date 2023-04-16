using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLight : MonoBehaviour
{
    GameObject lightObject;
    Light rocketLight;

    /**
    * TODO: Why is this script attached to the light?
    * This script should be attached to the rocket.
    * Update script, if need be, so that it can be attached to the rocket.
    */
    
    /**
    * Initialize our variables.
    */
    void Start(){
        lightObject = GameObject.Find(Constants.SPOTLIGHT_OBJECT);
        rocketLight = lightObject.GetComponent<Light>();
        rocketLight.enabled = false;
    }

    /**
    * Once per frame check to see if the light has been enabled.
    */
    void Update()
    {
        LightHandler();
    }

    /**
    * Toggle the light on shift key press.
    */
    private void LightHandler(){
        if (Input.GetKeyDown(KeyCode.LeftShift)){
            //Invert the current condition
            rocketLight.enabled = !rocketLight.enabled;
        } 
    }
}
