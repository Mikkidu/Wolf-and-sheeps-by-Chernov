using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breath : MonoBehaviour
{
    float timeCounter = 0;
    public float changeBreathPeriod;
    public float breathPeriod;
    Vector3 startScale;



    void Start()
    {
        startScale = transform.localScale;
        changeBreathPeriod = breathPeriod;
    }


    void Update()
    {
       

        transform.localScale += startScale * 0.0005f * Mathf.Sin(2 * Mathf.PI * timeCounter / breathPeriod);
        timeCounter += Time.deltaTime;
        if (timeCounter >= breathPeriod)
        {
            timeCounter = 0;
            breathPeriod = changeBreathPeriod;
        }
        
    }
}
