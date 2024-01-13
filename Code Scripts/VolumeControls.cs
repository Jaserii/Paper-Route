using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VolumeControls : MonoBehaviour
{
    [SerializeField] TMP_Text volumeLevel;

    //Set volume level text to current volume; default is 10%
    void Start(){
        volumeLevel.SetText(((int)(GameData.volume * 100f)).ToString());
    }

    public void changeVolume(){
        if (gameObject.tag == "volUp") {
            GameData.volume += 0.1f;
            if (GameData.volume > 1f) GameData.volume = 1f;
        }
        else if (gameObject.tag == "volDown"){
            GameData.volume -= 0.1f;
            if (GameData.volume < 0f) GameData.volume = 0f;
        }
        volumeLevel.SetText(((int)(GameData.volume * 100f)).ToString());
    }
}
