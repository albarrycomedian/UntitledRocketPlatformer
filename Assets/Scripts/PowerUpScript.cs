using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    /**
    * Like all powerups the oneUp should be destroyed as soon as something collides with it.
    * This should actually be one script that is attached to all powerups regardless of types.
    *
    */
    private void OnCollisionEnter(Collision other){
        switch (other.gameObject.tag)
        {
            case Constants.ROCKET_TAG:
                Destroy(gameObject);
                break;
        }
    }
}
