using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFuel : MonoBehaviour
{
    private void OnCollisionEnter(Collision other){
        switch (other.gameObject.tag)
        {
            case Constants.ROCKET_TAG:
                Destroy(gameObject);
                break;
        }
    }
}
