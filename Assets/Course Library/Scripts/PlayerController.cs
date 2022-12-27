using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnimator;

    private MoveLeft moveLeft;
    private MoveLeft moveLeftGround;

    public ParticleSystem explosionParticles;
    public ParticleSystem dirtParticles;

    public float jumpForce;
    public float jumpForceTwo;
    public float gravityModifier;

    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudioSource;

    public bool isOnGround = true;
    public bool gameOver = false;
    public bool inFly = false;
    public bool rushUp = false;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        //Physics.gravity = Physics.gravity * gravityModifier
        Physics.gravity *= gravityModifier;
        playerAudioSource = GetComponent<AudioSource>();
        moveLeft = GameObject.Find("BackGround").GetComponent<MoveLeft>();
        moveLeftGround = GameObject.Find("Ground").GetComponent<MoveLeft>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnimator.SetTrigger("Jump_trig");
            dirtParticles.Stop();
            //play one time
            playerAudioSource.PlayOneShot(jumpSound, 1.0f);
            inFly = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !gameOver && inFly)
        {
            playerRb.AddForce(Vector3.up * jumpForceTwo, ForceMode.Impulse);
            isOnGround = false;
            playerAnimator.SetTrigger("Jump_trig");
            dirtParticles.Stop();
            //play one time
            playerAudioSource.PlayOneShot(jumpSound, 1.0f);
            inFly = false;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rushUp = true;
            playerAnimator.SetFloat("Speed_Multiplier", 2.0f);
        }
        else if(rushUp)
        {
            rushUp = false;
            playerAnimator.SetFloat("Speed_Multiplier", 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            isOnGround = true;
            dirtParticles.Play();
        }
         else if (collision.gameObject.CompareTag("Obstacle"))
         {
            gameOver = true;
            Debug.Log("Game Over!");
            isOnGround = false;
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
            explosionParticles.Play();
            dirtParticles.Stop();
            playerAudioSource.PlayOneShot(crashSound, 1.0f);
         }
    }
    
}
