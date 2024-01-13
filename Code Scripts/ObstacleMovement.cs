using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private float xSpd;

    //When created, the Obstacle's xSpd is randomly generated
    void Start(){
        xSpd = Random.Range(-50f, -70f);
    }

    //  Move the Obstacle down the x axis
    void Update()
    {
        transform.Translate((Time.deltaTime * xSpd), 0, 0, Space.World);
        if (gameObject.transform.position.x < -100) Destroy(gameObject);   //Delete itself once its far offscreen
    }
}
