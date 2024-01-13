using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    public PickLevel level;

   //Run the selected level
   public void startGame(){
        if (level.level == null) return;    //If nothing is selected, then don't run anything

        else{
            switch(level.level){
                //Load PleasantVille Level
                case "PleasantVille":
                    SceneManager.LoadScene(1);
                    break;
                
                //Load Downtown Level
                case "Downtown":
                    SceneManager.LoadScene(2);
                    break;
                
                //Load Settings
                case "Settings":
                    SceneManager.LoadScene(3);
                    break;
                
                //Load MainMenu
                case "Back":
                    SceneManager.LoadScene(0);
                    break;
            }
        }
   }
}
