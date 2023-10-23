using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] planePrefab;
    public GameObject planeObject;
    public float startDelay = 2f;
    public float spawnInterval = 4f;
    public Transform[] carLeftPos;
    public GameObject[] carLeftPrefab;
    public Transform[] carRightPos;
    public GameObject[] carRightPrefab;
    public Transform trainPos;
    public GameObject trainPrefab;
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        //to access the function of player script we use this tag to find that function from that script
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        //Function below are call after given time and keep repeating
        InvokeRepeating("SpawnPlanePrefabs", startDelay, spawnInterval);
        InvokeRepeating("SpawnLeftCarPrefab", startDelay, spawnInterval);
        InvokeRepeating("SpawnRightCarPrefab", startDelay, spawnInterval);
        InvokeRepeating("SpawnTrainPrefab", startDelay, spawnInterval);
    }
    //this function is Instantiate the move platform in our game
    void SpawnPlanePrefabs()
    {
        if (player.isStop != true)
        {
            for (int i = 0; i < planePrefab.Length; i++)
            {
                Instantiate(planeObject, planePrefab[i].position, planePrefab[i].transform.rotation);
            }
        }
    }
    //this function Instantiate the Random Car from left side
    void SpawnLeftCarPrefab()
    {
        if (player.isStop != true)
        {
            for (int i = 0; i < carLeftPos.Length; i++)
            {
                int index = Random.Range(0, carLeftPrefab.Length);
                Instantiate(carLeftPrefab[index], carLeftPos[i].position, carLeftPos[i].transform.rotation);
            }
        }
    }
    //this function Instantiate the Random Car from Right side
    void SpawnRightCarPrefab()
    {
        if (player.isStop != true)
        {
            for (int i = 0; i < carRightPrefab.Length; i++)
            {
                int index = Random.Range(0, carRightPrefab.Length);
                Instantiate(carRightPrefab[index], carRightPos[i].position, carRightPos[i].transform.rotation);
            }
        }
    }
    //this function Instantiate the Train from left side
    void SpawnTrainPrefab()
    {
        if (player.isStop != true)
        {
            Instantiate(trainPrefab, trainPos.position, trainPrefab.transform.rotation);
        }
    }

}
