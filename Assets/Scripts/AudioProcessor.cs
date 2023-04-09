using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioProcessor : MonoBehaviour
{
    private AudioSource audioSource;
    private bool disableAudio;

    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip finish;
    [SerializeField] AudioClip mainEngine;
    
    /**
    * Initialize our variables.
    */
    private void Start(){
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
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
            if(!audioSource.isPlaying){
                audioSource.PlayOneShot(mainEngine);
            }
        } else{
            audioSource.Stop();
        }
    }

    /**
    * Public method to play the level complete sound.
    */
    public void playFinish(){
        audioSource.Stop();
        Debug.Log("Playing Finish");
        audioSource.PlayOneShot(finish);
        Debug.Log("Done Playing Finish");
    }

    /**
    * Public method to play the crash sound.
    */
    public void playCrash(){
        audioSource.Stop();
        audioSource.PlayOneShot(crash);
    }

    /**
    * Public method to disable audio.
    */
    public void setDisableAudioTrue(){
        disableAudio = true;
    }

    /**
    * Public method to stop audio and then disable audio.
    */
    public void stopAudioAndSetDisableAudioTrue(){
        audioSource.Stop();
        disableAudio = true;
    }

    /**
    * Public method to enable audio.
    */
    public void setDisableAudioFalse(){
        disableAudio = false;
    }
}
