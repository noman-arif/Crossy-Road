using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCoin : MonoBehaviour
{
    public float speed = 10f;
    private PlayerController player;
    void Start()
    {
        //to access the function of player script we use this tag to find that function from that script
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        //this will rotate coin unitl game is not over or level completed
        if (player.isStop != true)
        {
            transform.Rotate(0, 0, 1 * speed * Time.deltaTime);
        }
    }
}
