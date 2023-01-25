using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLight : MonoBehaviour
{
    Light light;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        light.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        LightHandler();
    }
    private void LightHandler()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            light.enabled = !light.enabled;
        } 
    }
}
