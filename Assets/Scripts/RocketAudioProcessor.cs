using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAudioProcessor : MonoBehaviour
{
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip finish;
    [SerializeField] AudioClip mainEngine;

    AudioSource rocketAudio;
    bool disableAudio;
    // Start is called before the first frame update
    void Start()
    {
        rocketAudio = GetComponent<AudioSource>();
        rocketAudio.Stop();
        disableAudio = false;
    }

    // Update is called once per frame
    void Update()
    {
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
