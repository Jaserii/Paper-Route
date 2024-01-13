using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperHitGround : MonoBehaviour
{
    /*
        When the paper hits a "floor" object (Grass, front porch, etc.), set newspaper to stop falling
    */
    private void OnCollisionEnter(Collision entity){
        if (entity.gameObject.name != "newspaper(Clone)") return;
        entity.gameObject.GetComponent<PaperMovement>().isFalling = false;   //Set the newspaper to a state of falling
        entity.gameObject.GetComponent<PaperMovement>().zSpd = 0f;          //Remove Z speed from newspaper
        //entity.gameObject.GetComponent<Rigidbody>().useGravity = true;      //Enable proper gravity physics
    }
}
