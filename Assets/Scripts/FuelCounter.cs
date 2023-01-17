using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FuelCounter : MonoBehaviour
{
    [SerializeField] private Text fuelMeter; 
    private int fuelAmount;
    // Start is called before the first frame update
    void Start()
    {
        fuelAmount = 100;
    }

    // Update is called once per frame
    void Update()
    {
        fuelMeter.text = "Fuel: " + fuelAmount.ToString() + "%";

        if (fuelAmount == 0)
        {
            GetComponent<Movement>().enabled = false;
        }

    }
}
