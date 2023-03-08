using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCollecting : MonoBehaviour
{
    [SerializeField] float strengthOfAttraction = 5f;
    [SerializeField] float pullRadius = 5f;
    [SerializeField] Transform playerRocket; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(playerRocket.position,pullRadius);

        foreach (var currentCollider in hitColliders)
        {
            
            if (currentCollider.tag == "Fuel")
            {
                Transform fuelPickup = currentCollider.transform;
                fuelPickup.position = Vector3.MoveTowards(fuelPickup.position,playerRocket.position,strengthOfAttraction * Time.deltaTime);
            } else if (currentCollider.tag == "Health"){
                Transform healthPickup = currentCollider.transform;
                healthPickup.position = Vector3.MoveTowards(healthPickup.position,playerRocket.position,strengthOfAttraction * Time.deltaTime);
            }
        }
    }
}
