using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallHazardCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) 
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                Destroy(gameObject);
            break;
            case "Bullet":
                Destroy(gameObject);
            break;
        }
    }
}
