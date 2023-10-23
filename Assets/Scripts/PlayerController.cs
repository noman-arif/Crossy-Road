using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float gravityMul;
    public bool isGround = true;
    public float speedX = 200f;
    public float jumpForce = 500f;
    public float positionX = 16f;
    public bool isStop = false;
    private ScoreManager score;
    // Start is called before the first frame update
    void Start()
    {
        //create ridgidbody so that we can perform function using script
        rb = GetComponent<Rigidbody>();
        //this line below is used to apply gravity pull based on user need
        Physics.gravity *= gravityMul;
        //to access the function of score manager script we use this tag to find that function from that script
        score = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Player Boundries so that it not move beyond the viewable area or platform
        if (transform.position.x < -positionX)
        {
            transform.position = new Vector3(-positionX, transform.position.y, transform.position.z);
        }
        if (transform.position.x > positionX)
        {
            transform.position = new Vector3(positionX, transform.position.y, transform.position.z);
        }
        //Code below is movement control for the player where I use AddForce function for Player Movement 
        if (isStop != true)
        {
            if (Input.GetKeyDown(KeyCode.W) && isGround)
            {
                rb.AddForce(0, 1 * jumpForce, 1 * speedX, ForceMode.Acceleration);
                isGround = false;
            }
            else if (Input.GetKeyDown(KeyCode.A) && isGround)
            {
                rb.AddForce(-1 * speedX, 1 * jumpForce, 0, ForceMode.Acceleration);
                isGround = false;

            }
            else if (Input.GetKeyDown(KeyCode.D) && isGround)
            {
                rb.AddForce(1 * speedX, 1 * jumpForce, 0, ForceMode.Acceleration);
                isGround = false;

            }
            else if (Input.GetKeyDown(KeyCode.S) && isGround)
            {
                rb.AddForce(0, 1 * jumpForce, -1 * speedX, ForceMode.Acceleration);
                isGround = false;
            }
        }
        //Code below are used to mkae object to stop in air and to make it invisble if it fall from platform
        if (transform.position.y < -1)
        {
            score.GameOver();
            rb.isKinematic = true;
            transform.GetComponent<MeshRenderer>().enabled = false;
        }

    }
    //detect collision and perform task according to tags and functionality written in it
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
        else if (collision.gameObject.CompareTag("Vehicle"))
        {
            score.GameOver();
            isStop = true;
        }
    }
    //detect triggered and perform task according to tags and functionality written in it

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FinishLine"))
        {
            score.LevelCompeled();
            isStop = true;
        }
        else if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            score.AddScore();
        }
    }

}
