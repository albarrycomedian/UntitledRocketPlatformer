using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallHazardCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other){
        Destroy(gameObject);  
    }
}
