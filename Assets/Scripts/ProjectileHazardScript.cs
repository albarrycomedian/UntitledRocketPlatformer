using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHazardScript : MonoBehaviour
{
    private float newtonsApplied = 15f;
    private float detectionRadius = 12f;
    private GameObject rocket;
    private bool isMoving;

    private const string ROCKET_TAG = "Player";
    
    private void Start(){
        isMoving = false;
        rocket = GameObject.FindWithTag(ROCKET_TAG);
    }

    // Update is called once per frame
    private void Update(){
        Vector3 targetVector;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position,detectionRadius);
        
        foreach (var currentCollider in hitColliders)
        {
            if (!isMoving){
                if (currentCollider.tag == ROCKET_TAG)
                {
                    targetVector = rocket.transform.position - transform.position;
                    GetComponent<Rigidbody>().AddForce(targetVector * newtonsApplied * Time.deltaTime);
                    isMoving = true;
                } 
            }
        }
    }
}
