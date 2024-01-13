using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUIUpdater : MonoBehaviour
{
    [SerializeField] TMP_Text newspapers, score, gameover, keyToPress;                  //Objects representing the corresponding text on screen
    [SerializeField] Image gameoverBack, keyToPressBack;                                    //Background image so that GAME OVER or SUCCESS can be more easily read
    [SerializeField] GameData gameData;                                     //GameData object containing important game information

    void Start(){
        gameData = GameObject.Find("GameData").GetComponent<GameData>();
    }

    // Update is called once per frame
    void Update()
    {
        //Show main game UI when active
        if (gameData.isAlive){
            newspapers.enabled = true;
            score.enabled = true;
            gameover.enabled = false;
            gameoverBack.enabled = false;
            keyToPress.enabled = false;
            keyToPressBack.enabled = false;
            newspapers.SetText("Newspapers: " + gameData.newspapers);
            score.SetText("Score: " + gameData.score);
        }
        //Show various game over text
        else {
            gameover.enabled = true;
            gameoverBack.enabled = true;
            keyToPress.enabled = true;
            keyToPressBack.enabled = true;
            if (gameData.won && gameData.score == 600){      //Each level has 6 buildings to deliver to
                gameover.SetText("PERFECT");
            }
            else if (gameData.won){
                gameover.SetText("COMPLETE");
            }
            else{
                gameover.SetText("GAME OVER");
            }
        }
        
    }
}
