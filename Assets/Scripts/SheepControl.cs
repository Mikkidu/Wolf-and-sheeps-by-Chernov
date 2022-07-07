using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepControl : MonoBehaviour
{
    public Transform wolf;
    private float speed = 2f;

    float alarmDistance = 2.5f;

    float restDistance = 4f;

    private float turnSpeed = 90f;

    private Vector3 whereIsWoolf;

    bool alarmFlag = false;

    float walkDirect;

    float walkTime = 3f;
    float stayTime = 2f;

    bool walkFlag;


    

    void Start()
    {
        
      
    }

    // Update is called once per frame
    void Update()
    {
        whereIsWoolf = transform.position - wolf.position;
        whereIsWoolf.y = 0;
        if (alarmFlag && whereIsWoolf.sqrMagnitude < restDistance)
        {
            //Move the wolf forward
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            //Rotates the wolf based on horizontal input
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(whereIsWoolf,Vector3.up), Time.deltaTime * 5.0f);
        }
        else if (whereIsWoolf.sqrMagnitude < alarmDistance)
        {
            alarmFlag = true;
        }
        else if (alarmFlag)
        {
            alarmFlag = false;
        }

        if (!alarmFlag)
        {
            //take a rest
        }


    }
}
