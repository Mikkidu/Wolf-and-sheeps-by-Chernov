using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    void Start()
    {

    }
    void LateUpdate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, player.rotation, Time.deltaTime * 10.0f);
        transform.position = player.position;       
    }
}
