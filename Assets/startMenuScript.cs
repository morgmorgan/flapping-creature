using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startMenuScript : MonoBehaviour
{
    public GameObject mute_icon;
    public GameObject sound_icon;
    
    private bool soundOn;
    settingsScript gameSettings;
    private void Awake()
    {
        gameSettings = GameObject.Find("GameSettings").GetComponent<settingsScript>();
        soundOn = true;
        gameSettings.setSoundOn(soundOn);
        sound_icon.SetActive(soundOn);
        mute_icon.SetActive(!soundOn);
    }

    public void startDaGame()
    {
        SceneManager.LoadScene(sceneName: "playArea");
    }

    public void toggleSound()
    {
        soundOn = !soundOn;
        gameSettings.setSoundOn(soundOn);
        sound_icon.SetActive(soundOn);
        mute_icon.SetActive(!soundOn);
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
