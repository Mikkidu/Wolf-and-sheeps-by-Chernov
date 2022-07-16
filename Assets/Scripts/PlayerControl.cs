using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    float speed = 2.0f;

    float turnSpeed = 90.0f;

    float horizontalInput;
    float forwardInput;
    public AudioSource[] wolfAttack;
    float fullTime = 3f;
    public AudioSource[] wolfBurp;
    int randomSound;
    public GameObject bone;
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
    void OnCollisionEnter(Collision other)
    {

        if (other.collider.name == "Sheep(Clone)")
        {
            wolfAttack[0].Play();
            StartCoroutine(FullBelly(fullTime));        
        }
    }
    
     private IEnumerator FullBelly(float restTime)
    {
        StartCoroutine(ChangeWolfScale(-1, 3));
        StartCoroutine(ChangeWolfScale(1, 16));
        StartCoroutine(ChangeWolfScale(-1, 3));
        yield return new WaitForSeconds(restTime);
        StartCoroutine(ChangeWolfScale(1, 3));
        Instantiate(bone, transform.position + Vector3.up * 0.1f, bone.transform.rotation);
        StartCoroutine(ChangeWolfScale(-1, 16));
        StartCoroutine(ChangeWolfScale(1, 3));
        randomSound = Random.Range(0, wolfBurp.Length);
        wolfBurp[randomSound].Play();
    }
      IEnumerator ChangeWolfScale(float moreLess, int times)
    {
        Vector3 reScale = Vector3.one * 0.01f;
        for (float i = 0; i < times; i += 1)
        {
            transform.localScale += moreLess * reScale;
            yield return new WaitForSeconds(1f / 50f);
        }
    }
    
}
