using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    public GameData gameData;

    // User presses any key and they go back to the level selector
    void Update()
    {
        if (gameData.isAlive == false){
            StartCoroutine(waitTimer());        //Give Player a chance to see the screen before clicking a button to return to the main menu 
        }
    }

    IEnumerator waitTimer(){
        yield return new WaitForSeconds(1);
        if (Input.GetKeyDown("space")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   //Return to index of current scene
        }
        else if (Input.anyKey){
            SceneManager.LoadScene(0);
        }
    }
}
