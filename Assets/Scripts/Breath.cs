using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breath : MonoBehaviour
{
    float timeCounter = 0;
    public float changeBreathPeriod;
    public float breathPeriod;
    Vector3 startScale;


    // Start is called before the first frame update
    void Start()
    {
        startScale = transform.localScale;
        changeBreathPeriod = breathPeriod;
    }

    // Update is called once per frame
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
    // private IEnumerator Breathing()
    // {
    //     Vector3 reScale = Vector3.one * 0.003f;
    //     while(true)
    //     {
    //         for (float i = 0; i < breathPeriod + 1; i += 1)
    //         {
    //             transform.localScale += reScale * Mathf.Sin(2 * Mathf.PI * i / breathPeriod);
    //             yield return new WaitForSeconds(1f / 25f);
    //         }            
    //     } 
    // }
}
