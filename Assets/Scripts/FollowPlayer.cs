using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //player
    public GameObject player;
    
    private Vector3 startPosition;
    private Quaternion startRotation;

    
    // Start is called before the first frame update
    void Start()
    {  
        startPosition = transform.position;
        startRotation = transform.rotation;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, player.transform.rotation, Time.deltaTime * 10.0f);
       
        transform.position = player.transform.position;
    }
}
