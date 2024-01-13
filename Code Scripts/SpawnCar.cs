using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    [SerializeField] GameData gameData;
    [SerializeField] GameObject car;

    //  When Player touches this object, a car has a 50%, 75%, or 100% of spawning
    private void OnTriggerEnter(Collider entity){
        if (entity.gameObject.name != "paperboy") return;
        if (Random.Range(1, 4) > gameData.carSpawnChance){
            Debug.Log("Hit!");
            Vector3 carPos = new Vector3(entity.gameObject.transform.position.x + 100, entity.gameObject.transform.position.y, -1.2f);
            Instantiate(car, carPos, Quaternion.identity);      //Quarternion.identity = no rotation
        }

    }
}
