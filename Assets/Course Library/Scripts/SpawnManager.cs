using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private int indexPrefab;
    private float startDelay = 2;
    private float spawnInterval = 2;

    private PlayerController playerControllerScript;

    private Vector3 spawnPos = new Vector3(30, 1, 0);
    // Start is called before the first frame update
    void Start()
    {
        // // find the player object that has its PlayerController component
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        indexPrefab = Random.Range(0, obstaclePrefab.Length);

        if (playerControllerScript.gameOver == false)
            Instantiate(obstaclePrefab[indexPrefab], spawnPos, obstaclePrefab[indexPrefab].transform.rotation);
    }
}
