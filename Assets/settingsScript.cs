using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class settingsScript : MonoBehaviour
{
    public AudioMixer audioMixer;
    public bool sound_on;

    private void Awake()
    {
        sound_on = true;
        DontDestroyOnLoad(this.gameObject);
    }

    public void setSoundOn(bool _sound_on)
    {
        sound_on = _sound_on;
        if(sound_on)
            audioMixer.SetFloat("masterVol", 0);
        else
            audioMixer.SetFloat("masterVol", -80);
    }    
}
