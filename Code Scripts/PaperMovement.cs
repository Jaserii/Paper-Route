using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperMovement : MonoBehaviour
{
    private GameObject paper, player;
    private GameData gameData;
    private float x, y, z;      //Starting location of the paper
    public float zSpd;
    public bool isFalling;

    // Start is called before the first frame update
    void Start()
    {
        gameData = GameObject.Find("GameData").GetComponent<GameData>();
        paper = gameObject;
        player = GameObject.Find("paperboy");
        x = player.transform.position.x;
        y = player.transform.position.y; 
        z = player.transform.position.z + 2f;
        Vector3 temp = new Vector3(x,y,z);
        paper.transform.position = temp; 
        isFalling = false;
        zSpd = gameData.xSpd + 5f;                   //Set newspaper speed to speed of player + a small boost
        Debug.Log(zSpd);
    }

    // Update is called once per frame
    void Update()
    {
        //Make the newspaper move left at a consistent speed if thrown
        if (!isFalling){
            paper.transform.Translate(0.0f, 0, (Time.deltaTime * zSpd), Space.World);  
        }
        else {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            paper.transform.Translate(0.0f, -0.02f, 0, Space.World);  
        }
        
    }
}
