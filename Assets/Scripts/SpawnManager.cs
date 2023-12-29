using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstacles;
    public float startDelay = 2;
    public float repeatRate = 2;
    private Vector3 spawnPos = new Vector3(40, 0, 0);
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
       
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }


    public void SpawnObstacle()
    {
        if (!playerController.gameOver)
        {
            int obstacleIndex = Random.Range(0, obstacles.Length);
            Instantiate(obstacles[obstacleIndex], spawnPos, obstacles[obstacleIndex].transform.rotation);
        }
    }
}
