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
    
    // Start is called before the first frame update
    private void Start(){
        rocketAudio = GetComponent<AudioSource>();
        rocketAudio.Stop();
        disableAudio = false;
    }

    // Update is called once per frame
    private void Update(){
        if (!disableAudio){
            processAudio();
        }
    }

    private void processAudio(){
        if(Input.GetKey(KeyCode.Space)){
            if(!rocketAudio.isPlaying){
                rocketAudio.PlayOneShot(mainEngine);
            }
        } else{
            rocketAudio.Stop();
        }
    }

    public void playFinish(){
        rocketAudio.Stop();
        rocketAudio.PlayOneShot(finish);
    }

    public void playCrash(){
        rocketAudio.Stop();
        rocketAudio.PlayOneShot(crash);
    }

    public void setDisableAudioTrue(){
        disableAudio = true;
    }
}
