using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAudioProcessor : MonoBehaviour
{
    private AudioSource rocketAudio;
    private bool disableAudio;

    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip finish;
    [SerializeField] AudioClip mainEngine;
    
    /**
    * Initialize our variables.
    */
    private void Start(){
        rocketAudio = GetComponent<AudioSource>();
        rocketAudio.Stop();
        disableAudio = false;
    }

    /**
    * Check if the audio is disabled. If not, process the audio.
    */
    private void Update(){
        if (!disableAudio){
            processAudio();
        }
    }

    /**
    * If the player is pressing the space key then play the rocket thrust sound.
    */
    private void processAudio(){
        if(Input.GetKey(KeyCode.Space)){
            if(!rocketAudio.isPlaying){
                rocketAudio.PlayOneShot(mainEngine);
            }
        } else{
            rocketAudio.Stop();
        }
    }

    /**
    * Public method to play the level complete sound.
    */
    public void playFinish(){
        rocketAudio.Stop();
        rocketAudio.PlayOneShot(finish);
    }

    /**
    * Public method to play the crash sound.
    */
    public void playCrash(){
        rocketAudio.Stop();
        rocketAudio.PlayOneShot(crash);
    }

    /**
    * Public method to disable audio.
    */
    public void setDisableAudioTrue(){
        disableAudio = true;
    }
}
