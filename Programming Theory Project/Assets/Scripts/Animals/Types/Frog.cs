using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Animal //__________INHERITANCE__________
                           //This child class inherits functionality from parent class "Animal"
{
    private void Awake()
    {
        AnimalNoise = "Ribbit...";
    }
}
