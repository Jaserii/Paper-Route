using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperCollision : MonoBehaviour
{
    [SerializeField] MeshFilter currentModel;
    [SerializeField] Mesh toChangeInto;
    private GameData gameData;
    private string houseColour;
    private bool alreadyDelivered = false;

    void Start(){
        gameData = GameObject.Find("GameData").GetComponent<GameData>();
    }

    private void OnCollisionEnter(Collision entity){
        if (entity.gameObject.name != "newspaper(Clone)") return;
        houseColour = checkHouse(gameObject);    //Recursively go up the object hierarchy until it detects the tag "red" or "blue" indicating the colour of the building
        determineCollisionObject(entity);
        //Debug.Log(gameObject.name);
        //Debug.Log(houseColour);
        if (!entity.gameObject.GetComponent<PaperMovement>().isFalling){
            entity.gameObject.GetComponent<PaperMovement>().isFalling = true;   //Set the newspaper to a state of falling
        }
    }

    private void determineCollisionObject(Collision entity){
        switch(gameObject.name){
            //If the paper collided with a window, break it (Change mesh to broken_window.fbx)
            case "window":
                updateModel(entity);
                gameData.score -= 200;                //Lose 200 points for breaking a window
                break;
            
            //If the paper collided with a wide window, break it (Change mesh to brokenwidewindow.fbx)
            case "widewindow":
                updateModel(entity);
                currentModel.GetComponent<MeshCollider>().sharedMesh = toChangeInto;
                gameData.score -= 400;                //Lose 400 points for breaking a window; more for this kind of window because of its size
                break;

            //Erase the thrown newspaper as if the newspaper flew inside; only applies to small house windows
            case "broken_window":
                Destroy(entity.gameObject);
                break;

            //Gain points for landing the newspaper on the frontstep
            case "door":
                checkDelivery();
                break;
            
            //Same thing but for city doors
            case "fancydoor":
                checkDelivery();
                break;
        }
    }

    private string checkHouse(GameObject parentObj){
        if ((parentObj.tag == "red" || parentObj.gameObject.tag == "blue")){
            return parentObj.tag;
        }
        else{
            return checkHouse(parentObj.transform.parent.gameObject);
        }
    }

    private void updateModel(Collision entity){
        currentModel.mesh = toChangeInto;
        gameObject.name = "broken_window";
        GetComponent<ParticleSystem>().Play();
        GetComponent<AudioSource>().Play();
        Destroy(entity.gameObject);           //Destroy newspaper
    }

    private void checkDelivery(){
        //Debug.Log(houseColour);
        if (alreadyDelivered == true) return;               //Don't do anything if player already attempted a delivery
        AudioSource temp = GetComponent<AudioSource>();
        if (houseColour == "red") {
            temp.Play();                    //Play Success sound effect (Ding)
            gameData.score += 100;          //Gain 100 points for delivering to a valued customer
        }
        else if (houseColour == "blue") {
            temp.Play();                    //Play Failure sound effect (WrongAnswer)
            gameData.score -= 100;   //Lose 100 points for delivering to a rival customer
        }
        alreadyDelivered = true;
    }
}
