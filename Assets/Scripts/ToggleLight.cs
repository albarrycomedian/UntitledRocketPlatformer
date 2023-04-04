using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLight : MonoBehaviour
{
    GameObject lightObject;
    Light rocketLight;
    
    /**
    * Initialize our variables.
    */
    void Start(){
        lightObject = GameObject.Find(Constants.SPOTLIGHT_OBJECT);
        rocketLight = lightObject.GetComponent<Light>();
        rocketLight.enabled = false;
    }

    
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
