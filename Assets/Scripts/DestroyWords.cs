using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWords : MonoBehaviour
{
    Rigidbody[] rbOfAllChild;
    Transform firstChild;
    float timeToSelfDestroy = 0.5f;
    public bool startTimer = false;
    float counter = 0;

    public AudioSource wolfAttack;

    // Start is called before the first frame update
    void Start()
    {
        rbOfAllChild = GetComponentsInChildren<Rigidbody>(); 
        firstChild = rbOfAllChild[0].gameObject.transform;       
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey("space") && !startTimer)
        {
            for (int i = 0; i < rbOfAllChild.Length; i++) 
                {                    
                    rbOfAllChild[i].isKinematic = false;
                    rbOfAllChild[i].AddExplosionForce(500f, Vector3.up * 4, 3f , 3f);
                }
            startTimer = true;
            wolfAttack.Play();
        }
        else if (startTimer)
        {
            counter += Time.deltaTime;
            if (counter > timeToSelfDestroy)
            {
                startTimer = false;
                foreach (Transform child in transform)
                {
                    child.gameObject.GetComponent<Collider>().enabled = false;
                }
            }
        }
        if (firstChild.position.y < -20f)
        {
            Destroy(gameObject);
        }

    }
}
