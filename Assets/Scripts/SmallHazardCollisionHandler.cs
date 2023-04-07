using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallHazardCollisionHandler : MonoBehaviour
{
    /**
    * On Any collision destroy the hazard.
    */
    private void OnCollisionEnter(Collision other){
        Destroy(gameObject);  
    }
}
