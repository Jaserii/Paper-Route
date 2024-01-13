using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float z = 0;           //Keep track of player's z pos
    [SerializeField] float zSpd = 0f;       //Variable speed of a player moving up or down the z axis
    public float xSpd;                             //Speed that the player and camera move at along the x axis
    [SerializeField] GameObject paper;      //An instance of a newspaper object is created when the player presses spacebar
    private GameObject player;              //Easier identification of the Player object
    private Vector3 pos, rotate;            //Vector3 objects for Player's position and rotation
    [SerializeField] GameData gameData;     //Contains universal game data such as x axis speed, newspaper count, win/lose state, etc.


    // When started, the Player gets its speed as defined in the Scene's gameData object
    void Start()
    {
        player = gameObject;
        xSpd = (float)gameData.xSpd;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameData.isAlive) return;      //If player hit an obstacle, stop movement
        movement();
        rotation();
        deliverPaper();
    }

    /*
        movement()
        -Make the player move left and right (+/- Z axis)
    */
    void movement(){
        //Get the current pos of the player
        z = player.transform.position.z;               
        zSpd = (-1) * Input.GetAxis("Horizontal") * Time.deltaTime * 10f;

        //Stop movement if the player reaches a specific Z value to the right
        if (z <= -1.3f)
        {
            z = -1.2f;
            //Get current x and y value, and save z to the vector
            pos = new Vector3(player.transform.position.x, player.transform.position.y, z);
            player.transform.position = pos;
            zSpd = 0;
        }

        //Translate the Player's position corresponding to the World's coordinates
        transform.Translate((Time.deltaTime * xSpd), 0, zSpd, Space.World);

    }


    /*
        rotation()
        -Adjust the rotation of the player depending on where they are turning
    */
    void rotation(){
        //Rotate left
        if (zSpd > 0){
            rotate = new Vector3(player.transform.rotation.x, -30f, player.transform.rotation.z);
        }
        //Rotate right
        else if (zSpd < 0){
            rotate = new Vector3(player.transform.rotation.x, 30f, player.transform.rotation.z);
        }
        //Normal orientation
        else{
            rotate = new Vector3(player.transform.rotation.x, 0f, player.transform.rotation.z);
        }
        player.transform.eulerAngles = rotate;
    }


    /*
        deliverPaper()
        -When player presses spacebar, create a new Newspaper object that travels to the left of the player
    */
    void deliverPaper(){
        if(Input.GetKeyDown("space")){
            //Debug.Log("Thrown!");
            if (gameData.newspapers <= 0) return;   //Do not throw newspapers if the player has run out
            Instantiate(paper);
            gameData.newspapers--;
        }
    }
}
