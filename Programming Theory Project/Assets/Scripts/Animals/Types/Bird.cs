using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Animal //INHERITANCE
{

    private void Awake()
    {
        canFly = true;
        animalNoise = "SQUAAAK!";
    }
    
}
