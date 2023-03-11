using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
