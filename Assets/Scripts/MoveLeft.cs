using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private PlayerController player;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        //to access the function of player script we use this tag to find that function from that script
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isStop != true)
        {
            //move obstacle to left side 
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
