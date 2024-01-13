using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickLevel : MonoBehaviour
{
    public string level;

    public void ChooseLevel(string level){
        this.level = level;
    }
}
