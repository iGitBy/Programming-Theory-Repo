using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour
{

    private Rigidbody animalRigidbody;

    private Text speakText;

    protected string animalNoise;


    [SerializeField] private float jumpForce;
    [SerializeField] private float groundSpeed;
    [SerializeField] private float airSpeed;
    [SerializeField] private float groundDrag;
    [SerializeField] private float airDrag;


    [SerializeField] private bool isGrounded;
    private bool readyToSpeak;
    protected bool canFly;




    // Start is called before the first frame update
    void Start()
    {
        animalRigidbody = this.GetComponent<Rigidbody>();
        readyToSpeak = true;
        speakText = GameObject.FindGameObjectWithTag("SpeakText").GetComponent<Text>();
        speakText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Speak();
   
    }

    private void FixedUpdate()
    {
        Move();
    }



    public virtual void Speak()
    {
        if (Input.GetKeyDown(KeyCode.R) && readyToSpeak)
        {
            StartCoroutine(PrepareSpeak());
        }
    }

    IEnumerator PrepareSpeak()
    {
        readyToSpeak = false;
        speakText.text = animalNoise;
        speakText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        readyToSpeak = true;
        speakText.gameObject.SetActive(false);

    }



    public virtual void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGrounded || canFly)
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
