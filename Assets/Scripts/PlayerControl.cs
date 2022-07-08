using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    float speed = 5.0f;

    float turnSpeed = 90.0f;

    float horizontalInput;
    float forwardInput;
    public AudioSource[] wolfAttack;
    float fullTime = 3f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        //Move the wolf forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //Rotates the wolf based on horizontal input
        transform.Rotate(Vector3.up * turnSpeed * horizontalInput * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision other)
    {

        if (other.collider.name == "Sheep(Clone)")
        {
            wolfAttack[0].Play();
            StartCoroutine(FullBelly(fullTime));
            
        }
    }
     private IEnumerator FullBelly(float restTime)
    {
        for (float i = 0; i < 3; i += 1)
        {
            transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f) / 10;
            yield return new WaitForSeconds(1f / 50f);
        }
        for (float i = 0; i < 16; i += 1)
        {
            transform.localScale += new Vector3(0.1f, 0.1f, 0.1f) / 10;
            yield return new WaitForSeconds(1f / 50f);
        }
        for (float i = 0; i < 3; i += 1)
        {
            transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f) / 10;
            yield return new WaitForSeconds(1f / 50f);
        }
        yield return new WaitForSeconds(restTime);
        for (float i = 0; i < 5; i += 1)
        {
            transform.localScale += new Vector3(0.1f, 0.1f, 0.1f) / 10;
            yield return new WaitForSeconds(1f / 50f);
        }
        for (float i = 0; i < 15; i += 1)
        {
            transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f) / 10;
            yield return new WaitForSeconds(1f / 50f);
        }
    }
}
