using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Class to store the game state between scenes.
*
* TODO: Refactor so that this is a generic state class.
*/
public class LifeState : MonoBehaviour
{
    private int lives;

    /**
    * Public method to retrieve the stored life count.
    */
    public int getLives(){
        return lives;
    }

    /**
    * Public method used to store the life count between scene transitions.
    */
    public void setLives(int count){
        lives = count;
    }
}
