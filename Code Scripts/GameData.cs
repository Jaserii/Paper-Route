using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour
{
    /*
        C# that contains important variables related to the game such as Score, Lives, and Number of Newspapers available for the player to throw
    */

    public int lives = 3;
    public int newspapers = 10;
    public int score = 0;
    public float xSpd = 0.02f;
    public bool isAlive = true;
    public bool won = false;
    public int carSpawnChance;     //2: 50%     1: 75%       0: 100%
    public static float volume = 0.1f;
}
