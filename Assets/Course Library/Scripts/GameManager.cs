using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private float _walkSpeed;
    public Score {get; private set;}
    private PlayerController _playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        Score = 0;
        p_layerControllerScript.gameOver = true;
        StartCoroutine(PlayIntro());
    }

    // Update is called once per frame
    void Update()
    {
        if(!_playerControllerScript.gameOver)
        {
            if(_playerControllerScript.rushUp)
            {
                Score += 2;
            }
            else
            {
                Score++;
            }
            Debug.Log("Score:" + Score);
        }
    }

    //This new method will move the player to the starting point.
    IEnumerator PlayIntro()
    {
        Vector3 startPos = playerControllerScript.transform.position;
        Vector3 endPos = startPoint.position;
        float journeyLength = Vector3.Distance(startPos, endPos);
        float startTime = Time.time;

        float distanceCovered = (Time.time - startTime) * walkSpeed;
        float fractionJourney = distanceCovered / journeyLength;

        _playerControllerScript.GetComponent<Animator>().SetFloat("Speed_Multiplier", 0.5f);

        while (fractionJourney < 1)
        {
            distanceCovered = (Time.time - startTime) * walkSpeed;
            fractionJourney = distanceCovered / journeyLength;
            _playerControllerScript.transform.position = Vector3.Lerp(startPos, endPos, fractionJourney);
            yield return null;
        }

        _playerControllerScript.GetComponent<Animator>().SetFloat("Speed_Multiplier", 1.0f);
        _playerControllerScript.gameOver = false;

    }
}
