using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLight : MonoBehaviour
{
    Light rocketLight;
    // Start is called before the first frame update
    void Start()
    {
        rocketLight = GetComponent<Light>();
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
