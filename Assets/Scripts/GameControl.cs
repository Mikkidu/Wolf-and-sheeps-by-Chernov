using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public GameObject wolf;
    bool startTimer = false;
    GameObject wordHungry;
    public AudioSource wolfAttack;
    Rigidbody[] rbOfChildren;
    Rigidbody[] symbols;
    float counter = 0;
    float timeToSelfDestroy = 0.5f;


    
    // Start is called before the first frame update
    void Start()
    {
        wordHungry = GameObject.Find("Hungry");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("space") && !startTimer)
        {
            rbOfChildren = wordHungry.GetComponentsInChildren<Rigidbody>();

            symbols[0].gameObject.GetComponentInChildren<Rigidbody>();
            for (int j = 0; j < symbols.Length; j++) //не нужен второй перебор . в первом вызываются все дети с Rigidbody!
            {
                for (int i = 0; i < symbols[j].gameObject.GetComponentInChildren<Rigidbody>().Length; i++) 
                {                    
                    rbOfChildren[i].isKinematic = false;
                    rbOfChildren[i].AddExplosionForce(500f, Vector3.up * 4, 3f , 3f);

                }
            }
            Debug.Log(symbols.Length);
            startTimer = true;
            wolf.gameObject.GetComponent<PlayerControl>().enabled = true;
            wolfAttack.Play();
        }
        else if (startTimer)
        {
            counter += Time.deltaTime;
            // if (counter > timeToSelfDestroy)
            // {
            //     startTimer = false;
            //     counter = 0;
            //     foreach (Transform child in transform)
            //     {
            //         child.gameObject.GetComponent<Collider>().enabled = false;
            //     }
            // }
        }
       
    }

}
