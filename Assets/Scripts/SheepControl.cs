using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepControl : MonoBehaviour
{
    Transform wolf;
    float speed = 2f;

    float alarmDistance = 2.5f;

    float restDistance = 4f;

    Vector3 whereIsWoolf;

    bool alarmFlag = false;

    float walkDirect;

    float walkTime = 3f;
    float stayTime = 2f;

    bool walkFlag = false;

    float counter = 0f;

    public AudioSource[] chillBaa;

    int randomBaa;
    public AudioSource[] fearBaa;

    






    void Start()
    {
        stayTime = Random.Range(0, stayTime);
        wolf = GameObject.Find("Wolf").transform;
    }

    // Update is called once per frame
    void Update()
    {
        whereIsWoolf = transform.position - wolf.position;
        whereIsWoolf.y = 0;
        if (alarmFlag && whereIsWoolf.sqrMagnitude < restDistance)
        {
            Walk(Quaternion.LookRotation(whereIsWoolf, Vector3.up), speed);

        }
        else if (whereIsWoolf.sqrMagnitude < alarmDistance)
        {
            alarmFlag = true;
            randomBaa = Random.Range(0, 2);
            fearBaa[randomBaa].Play();
            GetComponent<Breath>().changeBreathPeriod *= 0.25f;

        }
        else if (alarmFlag)
        {
            alarmFlag = false;
            GetComponent<Breath>().changeBreathPeriod *= 4f;

        }
        

        if (!alarmFlag)
        {
            //take a rest
            if (walkFlag)
            {
                Walk(Quaternion.Euler(Vector3.up * walkDirect), speed * 0.25f);
                if (counter > walkTime)
                {
                    walkFlag = false;
                    counter = 0;
                }
            }
            else if (counter > stayTime)
            {
                walkFlag = true;
                walkDirect = Random.Range(-180, 180);
                counter = 0;
                randomBaa = Random.Range(0, 3);
                chillBaa[randomBaa].Play();
            }
        }
        counter += Time.deltaTime;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.name == "Wolf")
        {
            Destroy(gameObject);
        }
    }

    void Walk(Quaternion direct, float walkSpeed)
    {
        transform.Translate(Vector3.forward * Time.deltaTime * walkSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, direct, Time.deltaTime * 4.0f);
    }

    
}
