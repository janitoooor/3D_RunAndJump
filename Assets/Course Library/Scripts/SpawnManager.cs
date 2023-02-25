using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _obstaclePrefab;
    private int _indexPrefab;
    private float _startDelay = 2;
    private float _spawnInterval = 2;

    private PlayerController _playerControllerScript;

    private Vector3 _spawnPos = new Vector3(30, 1, 0);
    // Start is called before the first frame update
    void Start()
    {
        // // find the player object that has its PlayerController component
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", _startDelay, _spawnInterval);
    }
    
    void SpawnObstacle()
    {
        _indexPrefab = Random.Range(0, _obstaclePrefab.Length);

        if (_playerControllerScript.gameOver == false)
            Instantiate(_obstaclePrefab[indexPrefab], spawnPos, o_bstaclePrefab[_indexPrefab].transform.rotation);
    }
}
