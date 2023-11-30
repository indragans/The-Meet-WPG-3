using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private float horizontal; 
    private float vertical;
    private float speed = 5.0f;
    private Vector3 moveDirection;
    public bool isGrounded;
    public Rigidbody rb;

    public AudioSource footStepSound;
    public float footStepInterval = 0.1f;

    void Start()
    {
       rb = GetComponent<Rigidbody>();
       isGrounded = false;

       //inisialisasi audio
       footStepSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        moveDirection = new Vector3(horizontal, 0, vertical);
        transform.Translate(moveDirection * speed * Time.deltaTime); 

        if(moveDirection.magnitude > 0 && isGrounded)
        {
            PlayFootStepSound();
        }

        if(Input.GetKeyDown(KeyCode.Space)&& isGrounded){
            rb.velocity = new Vector3(0,5,0);
            //isGrounded = true;
        }

        if(Input.GetKey(KeyCode.LeftShift)&& isGrounded){
            transform.position += transform.forward * Time.deltaTime * speed;
        }
        

    }

    void PlayFootStepSound()
    {
        if(!footStepSound.isPlaying)
        {
            footStepSound.Play();
            Invoke("PlayFootStepSound", footStepInterval);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

}
