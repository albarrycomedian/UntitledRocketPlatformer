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

    public int getLives(){
        return lives;
    }

    public void setLives(int count){
        lives = count;
    }
}
