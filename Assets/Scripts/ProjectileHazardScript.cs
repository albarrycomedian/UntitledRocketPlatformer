using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHazardScript : MonoBehaviour
{
    [SerializeField] float strengthOfAttraction = 5f;
    [SerializeField] float pullRadius = 10f;
    [SerializeField] GameObject playerRocket;

    Vector3 initialRocketPosition;

    bool isMoving;

    void Start()
    {
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position,pullRadius);
        
        foreach (var currentCollider in hitColliders)
        {
            if (!isMoving){
                if (currentCollider.tag == "Player")
                {
                    initialRocketPosition = playerRocket.transform.position - transform.position;
                    GetComponent<Rigidbody>().AddForce(initialRocketPosition * strengthOfAttraction * Time.deltaTime);
                    isMoving = true;
                } 
            } else if (isMoving){
                GetComponent<Rigidbody>().AddForce(initialRocketPosition * strengthOfAttraction * Time.deltaTime);
            }
        }
    }
}
