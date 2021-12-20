using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earthquake : MonoBehaviour
{
    private GameObject mainCamera;

    private void Awake()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Elephant"))
        {
            mainCamera.GetComponent<CameraController>().ShakeEffect();
        }
    }

}
