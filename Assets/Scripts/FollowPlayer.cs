using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //player
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, player.rotation, Time.deltaTime * 10.0f);
        transform.position = player.position;
        
    }
}
