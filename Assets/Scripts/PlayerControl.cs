using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float speed = 2.0f;

    private float turnSpeed = 90.0f;

    private float horizontalInput;
    private float forwardInput;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        if (forwardInput < 0)
        {
            //horizontalInput *= -1;
        }
        //Move the wolf forward
        transform.Translate(Vector3.forward*Time.deltaTime*speed*forwardInput);
        //Rotates the wolf based on horizontal input
        transform.Rotate(Vector3.up*turnSpeed*horizontalInput*Time.deltaTime);

        
        //transform.Translate(Vector3.right*Time.deltaTime*turnSpeed*horizontalInput);
    }
}
