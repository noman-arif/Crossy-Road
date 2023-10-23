using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerCam : MonoBehaviour
{
    //creating gameobject to hold player reference 
    public GameObject player;
    Vector3 camOffset = new Vector3(3.81f, 8.17f, -3.57f);  //hold position of camera from this distance it will follow player
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + camOffset;  //update camera position when player move       
    }
}
