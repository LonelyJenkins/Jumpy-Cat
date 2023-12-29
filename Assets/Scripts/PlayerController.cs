using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private ScoreText scoreText;
    private AudioSource audioSource;
    private float gravityModifier = 3;
    static public bool gravityActive = false;
    public float jumpForce = 100f;
    public float dblJumpForce = 50f;
    public bool isOnGround;
    public bool gameOver = false;
    public int timesJumped;
    public ParticleSystem dirtKick;
    public ParticleSystem liftOff;
    public ParticleSystem liftOff1;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("ScoreManager").GetComponent<ScoreText>();
        playerAnim = GameObject.Find("Cat Lite").GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        if (gravityActive == false)
        {
            Physics.gravity *= gravityModifier;
            gravityActive = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && timesJumped < 2 && gameOver == false)

        {
            audioSource.PlayOneShot(jumpSound, 1.0f);
            Jump();
            JetLaunch();
            timesJumped += 1;
            isOnGround = false;
            
        }

        if (!isOnGround)
        {
            dirtKick.Stop();
        }

     
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            timesJumped = 0;
            dirtKick.Play();
            
            
        }

       if(collision.gameObject.CompareTag("Obstacle"))
        {
            audioSource.PlayOneShot(crashSound, 1.0f);
            playerAnim.SetBool("playerCollision", true);
            gameOver = true;
            dirtKick.Stop();
            scoreText.GameOver();
        }
       
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gate"))
        {
            Destroy(other.gameObject);
            scoreText.AddScore(1);
        }
    }

    private void JetLaunch()
    {
        liftOff.Play();
        liftOff1.Play();
    }

    private void Jump()
    {
        if (timesJumped <= 0)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (timesJumped > 0)
        {
            playerRb.AddForce(Vector3.up * dblJumpForce, ForceMode.Impulse);
        }
    }

}
