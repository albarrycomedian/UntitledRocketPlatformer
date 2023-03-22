using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHazardScript : MonoBehaviour
{
    private float newtonsApplied = .25f;
    private float detectionRadius = 12f;
    private GameObject rocket;
    private bool isMoving;
    
    private void Start(){
        isMoving = false;
        rocket = GameObject.FindWithTag(Constants.ROCKET_TAG);
    }

    // Update is called once per frame
    private void Update(){
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
