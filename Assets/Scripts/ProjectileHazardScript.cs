using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileHazardScript : MonoBehaviour
{
    private float strengthOfAttraction = 10f;
    private float pullRadius = 12f;
    private GameObject playerRocket;

    Vector3 initialRocketPosition;

    bool isMoving;

    void Start()
    {
        isMoving = false;
        playerRocket = GameObject.Find("Rocket");
    }

    // Update is called once per frame
    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position,pullRadius);
        
        foreach (var currentCollider in hitColliders)
        {
            if (isMoving){
                GetComponent<Rigidbody>().AddForce(initialRocketPosition * strengthOfAttraction * Time.deltaTime);                
            } else
                if (currentCollider.tag == "Player")
                {
                    initialRocketPosition = playerRocket.transform.position - transform.position;
                    GetComponent<Rigidbody>().AddForce(initialRocketPosition * strengthOfAttraction * Time.deltaTime);
                    isMoving = true;
                } 
        }
    }
}
