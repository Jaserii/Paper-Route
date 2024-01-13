using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField] GameObject player;     //Camera will follow behind the player at the same speed
    [SerializeField] GameData gameData;

    //Also update Audio Listener to Player's settings
    void Start(){
        AudioListener.volume = GameData.volume;
    }

    // Update camera to follow the Player at the same speed as defined in gameData
    void Update()
    {
        transform.Translate((Time.deltaTime * gameData.xSpd), 0, 0, Space.World);  
    }
}
