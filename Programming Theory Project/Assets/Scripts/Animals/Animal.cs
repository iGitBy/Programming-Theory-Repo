using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour //__________INHERITANCE__________
                                    //Animal inherits functionality from MonoBehaviour. 
                                    //Animal's child classes of Bird, Elephant, Frog, and Lion will inherit functionality from
                                    //Animal, which inherits from MonoBehaviour. So, if Animal is parent
                                    //to Lion then MonoBehaviour is... grandparent to Lion :)
{

    private Rigidbody animalRigidbody;

    private Text speakText;

    private float maxSpeakTextLength = 20;


    //__________ENCAPSULATION__________
    private string m_AnimalNoise; //private backing field
    public string AnimalNoise //public property with setter validation
    {
        get { return m_AnimalNoise; }

        set
        {
            if (value.Length > maxSpeakTextLength)
            {
                Debug.LogError("Animal noise can't be more than 10 characters long!");
            }
            else
            {
                m_AnimalNoise = value;
            }
        }
    }


    [SerializeField] private float jumpForce;
    [SerializeField] private float groundSpeed;
    [SerializeField] private float airSpeed;
    [SerializeField] private float groundDrag;
    [SerializeField] private float airDrag;



    private bool isGrounded;
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

        Jump();//__________ABSTRACTION__________
        //methods like this abstract/simplify more complex code blocks


        if (Input.GetKeyDown(KeyCode.Space) && readyToSpeak)
        {
            Speak();
        }

    }

    private void FixedUpdate()
    {
        Move();
    }


    //__________POLYMORPHISM__________
    public virtual void Speak() // virtual methods like these pave the way for overrides in child classes
    {
        StartCoroutine(PrepareSpeak());
    }

    IEnumerator PrepareSpeak()
    {
        readyToSpeak = false;
        speakText.text = m_AnimalNoise;
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
