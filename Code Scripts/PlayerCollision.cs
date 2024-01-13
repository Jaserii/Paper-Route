using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameData gameData;

    void Start(){
        gameData = GameObject.Find("GameData").GetComponent<GameData>();
    }

    private void OnCollisionEnter(Collision entity){
        if (entity.gameObject.name != "paperboy") return;
        GameObject.FindWithTag("MainCamera").GetComponent<AudioSource>().Stop();    //Stop the background music when game ends
        //Debug.Log(gameObject.name);
        //Debug.Log(houseColour);
        
        //If player hit invisible finish line, they win. If not, they lose because they hit an obstacle
        if (gameObject.name == "finishline") {
            gameData.won = true;
            GetComponent<AudioSource>().Play();     //Play victory tune
        }
        else {
            entity.gameObject.GetComponent<ParticleSystem>().Play();
            entity.gameObject.GetComponent<AudioSource>().Play();
            gameData.won = false;
        }

        
        //Debug.Log(gameObject.name);
        gameData.isAlive = false;
        gameData.xSpd = 0;

    }
}
