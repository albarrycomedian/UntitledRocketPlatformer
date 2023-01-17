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
    }

    // Update is called once per frame
    void Update()
    {
        toggleLight();
    }
    private void toggleLight()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            light.enabled = !light.enabled;
            Debug.Log("The Light is On");
        } 
    }
}
