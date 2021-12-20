using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lion : Animal //__________INHERITANCE__________
                           //This child class inherits functionality from parent class "Animal"
{
    [SerializeField] private GameObject mainCamera;

    private void Awake()
    {
        AnimalNoise = "RAAAAAAAWWWWWRR!!!";
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }


    //__________POLYMORPHISM__________

    public override void Speak() // Lion (child) class overrides Speak() method of Animal (parent) class
    {
        mainCamera.GetComponent<CameraController>().ShakeEffect(); // adds a camera effect to personalize it's ROOAAAR!
        base.Speak();
    }
}
