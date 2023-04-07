using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFuel : MonoBehaviour
{
    /**
    * Like all powerups the oneUp should be destroyed as soon as something collides with it.
    * This should actually be one script that is attached to all powerups regardless of types.
    *
    * TODO: Refactor so that this isn't specific to the OneUp Powerup. Additionally, consider
    * whether or not this should be destroyed on all collisions, or just on collisions with the rocket.
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
