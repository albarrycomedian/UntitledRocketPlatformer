using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHazardScript : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";
    private float newtonsApplied = 15f;
    private float detectionRadius = 12f;
    private GameObject playerRocket;
    private bool isMoving;
    
    private void Start(){
        isMoving = false;
        playerRocket = GameObject.Find("Rocket");
    }

    // Update is called once per frame
    private void Update(){
        Vector3 targetVector;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position,detectionRadius);
        
        foreach (var currentCollider in hitColliders)
        {
            if (!isMoving){
                if (currentCollider.tag == PLAYER_TAG)
                {
                    targetVector = playerRocket.transform.position - transform.position;
                    GetComponent<Rigidbody>().AddForce(targetVector * newtonsApplied * Time.deltaTime);
                    isMoving = true;
                } 
            }
        }
    }
}
