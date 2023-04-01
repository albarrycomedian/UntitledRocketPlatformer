using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLight : MonoBehaviour
{
    GameObject lightObject;
    Light rocketLight;
    // Start is called before the first frame update
    void Start(){
        lightObject = GameObject.Find(Constants.SPOTLIGHT_OBJECT);
        rocketLight = lightObject.GetComponent<Light>();
        rocketLight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        LightHandler();
    }

    private void LightHandler(){
        if (Input.GetKeyDown(KeyCode.LeftShift)){
            //Invert the current condition
            rocketLight.enabled = !rocketLight.enabled;
        } 
    }
}
