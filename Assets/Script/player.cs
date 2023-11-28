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

    void Start()
    {
       rb = GetComponent<Rigidbody>();
       isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        moveDirection = new Vector3(horizontal, 0, vertical);
        transform.Translate(moveDirection * speed * Time.deltaTime); 

        if(Input.GetKeyDown(KeyCode.Space)&& isGrounded){
            rb.velocity = new Vector3(0,5,0);
            //isGrounded = true;
        }

        if(Input.GetKey(KeyCode.LeftShift)&& isGrounded){
            transform.position += transform.forward * Time.deltaTime * speed;
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
