using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallHazardCollisionHandler : MonoBehaviour
{
    /**
    * On Any collision destroy the hazard.
    *
    * Param: other, the gameObject we collided with.
    */
    private void OnCollisionEnter(Collision other){
        Destroy(gameObject);  
    }
}
