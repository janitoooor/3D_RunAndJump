using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float _speed = 35.0f;
    private float _leftBound = -15.0f;

    private PlayerController playerControllerScript;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    
    void Update()
    {
       if(playerControllerScript.gameOver == false)
        {
            if(playerControllerScript.rushUp)
            {
                transform.Translate(Vector3.left * Time.deltaTime * (_speed * 2));
            }
            else
            {
                transform.Translate(Vector3.left * Time.deltaTime * _speed);
            }
        }
        
       if(transform.position.x < _leftBound && gameObject.CompareTag("Obstacle"))
            Destroy(gameObject);
    }
}
