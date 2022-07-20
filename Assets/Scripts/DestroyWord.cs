using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWord : MonoBehaviour
{
    Rigidbody[] rbOfChildren;
    float counter = 0;
    float timeToSelfDestroy = 3f;
    Collider[] collOfChildren;


 
    void Start()
    {
        rbOfChildren = gameObject.GetComponentsInChildren<Rigidbody>();
        for (int j = 0; j < rbOfChildren.Length; j++)
        {                  
            rbOfChildren[j].isKinematic = false;
            rbOfChildren[j].AddExplosionForce(500f, Vector3.up * 4, 3f , 3f);
        }
    }


    void Update()
    {
        counter += Time.deltaTime;
        if (counter > timeToSelfDestroy)
        {
            Destroy(gameObject);
        }
        else if (counter > timeToSelfDestroy / 2)
        {
            collOfChildren = gameObject.GetComponentsInChildren<Collider>();
            foreach (Collider child in collOfChildren)
            {
                
                child.enabled = false;
            }
        }    
    }
}
