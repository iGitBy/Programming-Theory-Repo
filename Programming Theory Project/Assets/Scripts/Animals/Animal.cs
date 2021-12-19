using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{

    private Rigidbody animalRigidbody;

    [SerializeField] private float jumpForce;

    [SerializeField] private float groundSpeed;

    [SerializeField] private float airSpeed; 

    [SerializeField] private float groundDrag;

    [SerializeField] private float airDrag;

    [SerializeField] private bool isGrounded;



    // Start is called before the first frame update
    void Start()
    {
        animalRigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded)
            {

                animalRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            }
        }

    }

    void Move()
    {
        float moveSpeed;

        if (isGrounded)
        {
            animalRigidbody.drag = groundDrag;
            moveSpeed = groundSpeed;
        }

        else
        {
            animalRigidbody.drag = airDrag;
            moveSpeed = airSpeed;
        }

        animalRigidbody.AddForce(Vector3.right * Input.GetAxis("Horizontal") * moveSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
        }
    }

}
