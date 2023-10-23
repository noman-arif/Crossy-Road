using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    public float destroyRangeX = 74;
    private PlayerController player;
    private void Start()
    {
        //to access the function of player script we use this tag to find that function from that script
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        if (player.isStop != true)
        {
            //the code below is just destroy those object which get out of the mention axes
            if (transform.position.x < -destroyRangeX)
            {
                Destroy(gameObject);
            }
            if (transform.position.x > destroyRangeX)
            {
                Destroy(gameObject);
            }
        }
    }
}
