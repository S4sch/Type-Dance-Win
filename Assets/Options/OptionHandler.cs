using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionHandler : MonoBehaviour
{
    //Music Stuff
    public Sprite MusicOn, MusicStop;
    SpriteRenderer MusicSR;

    private void Start()
    {
    }

    //Turn the Volume on/off and change sprite
    public void ChangeVolume()
    {
        MusicSR = GameObject.Find("Sound").GetComponent<SpriteRenderer>();
        GlobalSettings.AudioOn = !GlobalSettings.AudioOn;
        if (GlobalSettings.AudioOn)
        {
            MusicSR.sprite = MusicOn;
        }
        else
        {
            MusicSR.sprite = MusicStop;
        }

    }

    //Change between Menu and options
    public void BackToMenu()
    {
        SceneManager.LoadScene("StartScence", LoadSceneMode.Single);
    }

    public void GotoOptions()
    {
        SceneManager.LoadScene("OptionScene", LoadSceneMode.Single);
    }

}
