using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool goingUp = true;
    private bool shaking = false;

    [SerializeField] private int cycles;
    private int currentCycle = 0;

    private float shiftAmount = 0.5f;
    private float speed = 10;

    private Vector3 startPosition;


    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {

        if (shaking)
        {
            moveCamera();
        }
    }


    void moveCamera()
    {

        if (currentCycle < cycles)
        {
            if (transform.position.y < startPosition.y + shiftAmount && goingUp)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
            else if (transform.position.y > startPosition.y)
            {
                goingUp = false;
                transform.Translate(Vector3.up * -speed * Time.deltaTime);
            }
            else
            {
                goingUp = true;
                transform.position = startPosition;
                currentCycle++;
            }

        }
        else
        {
            currentCycle = 0;
            shaking = false;
        }

    }

    public void ShakeEffect()
    {
        shaking = true;
    }




}
