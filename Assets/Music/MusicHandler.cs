using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicHandler : MonoBehaviour
{
    //Music Sprites
    public Sprite MusicOn, MusicStop;
    Image MusicSR;

    void Start()
    {
        //Set up the current Status
        MusicSR = GameObject.Find("Sound").GetComponent<Image>();
        ChangeSprite();
    }

    //Turn the Volume on/off and change sprite
    public void ChangeVolume()
    {
        GlobalSettings.AudioOn = !GlobalSettings.AudioOn;
        ChangeSprite();

    }

    //Change Sprite according to the current Audio Status
    void ChangeSprite()
    {
        if (GlobalSettings.AudioOn)
        {
            MusicSR.sprite = MusicOn;
        }
        else
        {
            MusicSR.sprite = MusicStop;
        }
    }

}
