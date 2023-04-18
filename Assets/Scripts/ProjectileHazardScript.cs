using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHazardScript : MonoBehaviour
{
    private bool isMoving;
    private float newtonsApplied = .25f;
    private float detectionRadius = 12f;
    private GameObject rocket;
    
    /**
    * Initialize variables.
    */
    private void Start(){
        isMoving = false;
        rocket = GameObject.FindWithTag(Constants.ROCKET_TAG);
    }

    /**
    * Check to see if there are any objects within our detection sphere.
    */
    private void Update(){
        CheckForObjectsWithinProximity();
    }

    /**
    * Check if any colliders are within our detection radius. If there are, check the tags.
    * If it is the rocket, apply force in the direction of the rocket.
    */
    private void CheckForObjectsWithinProximity(){
        Vector3 targetVector;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position,detectionRadius);
        
        foreach (var currentCollider in hitColliders)
        {
            if (!isMoving){
                if (currentCollider.tag == Constants.ROCKET_TAG)
                {
                    targetVector = rocket.transform.position - transform.position;
                    GetComponent<Rigidbody>().AddForce(targetVector * newtonsApplied);
                    isMoving = true;
                } 
            }
        }
    }
}
