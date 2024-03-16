using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float maxMoveSpeed = 5.0f;
    private Vector3 targetPosition; // Target position for player movement
    private Rigidbody rb;
    private Animator animator;
    private bool isRight;
    private bool isWrong;
    //public AudioSource breakAudio;
    //public AudioSource deathAudio;
    public bool isFinish;
    public bool isDead;
    AudioManager audioManager;
    private Vector2 startTouchPosition;
    public LayerMask groundLayer;
    public bool isGrounded;
    public GameObject gameOver;
    public float deathHeight = -2.0f;
    //Swipe lane
    private int desiredLane = 1;
    public float laneDistance = 5f;

    private void Start()
    {
        //targetPosition = transform.position;
        transform.position = Vector3.zero;
        rb = GetComponent<Rigidbody>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        rb.freezeRotation = true;
        animator = GetComponent<Animator>();
        isRight = false;
        isWrong = false;
        isFinish = false;
        isDead = false;


    }
    private void Update()
    {
        // Move the player forward automatically
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        if (transform.position.y < deathHeight)
        {
            Die();
        }
        else if(isDead)
        {
            Die();
        }
        // Handle player input
        //HandleMobileInput();
        //HandleMobileInput();
        //HandleInput();
        HandleSwipeInput();
        PlayerAnimation();
        

    }
    private void HandleSwipeInput()
    {
        if (SwipeManager.swipeRight)
        {
            desiredLane = Mathf.Clamp(desiredLane + 1, 0, 2);
        }
        else if (SwipeManager.swipeLeft)
        {
            desiredLane = Mathf.Clamp(desiredLane - 1, 0, 2);
        }

        // Calculate target position based on desired lane
        Vector3 targetPosition = transform.position;

        switch (desiredLane)
        {
            case 0:
                targetPosition = new Vector3(-laneDistance, transform.position.y, transform.position.z);
                break;
            case 1:
                targetPosition = new Vector3(0f, transform.position.y, transform.position.z);
                break;
            case 2:
                targetPosition = new Vector3(laneDistance, transform.position.y, transform.position.z);
                break;
        }

        float platformWidth = 1.6f; // Adjust this value according to your platform's width
        targetPosition.x = Mathf.Clamp(targetPosition.x, -platformWidth / 2f, platformWidth / 2f);

        // Smoothly move the player to the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.1f);
    }
    private void HandleMobileInput()
    {
        isGrounded = Physics.Raycast(transform.position,Vector3.down,0.1f,groundLayer);
       //mobile input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Calculate horizontal input based on touch position
            float horizontalInput = 0f;

            if (touch.phase == TouchPhase.Began)
            {
                // Record the touch position at the beginning of the touch
                startTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                // Calculate the horizontal movement based on touch position delta
                float touchDeltaX = touch.position.x - startTouchPosition.x;

                // Normalize the movement to be between -1 and 1
                horizontalInput = Mathf.Clamp(touchDeltaX / Screen.width, -1f, 1f);
            }

            // Calculate movement direction based on input
            Vector3 movementDirection = new Vector3(horizontalInput, 0f, 0f).normalized;

            // Calculate target position for player movement
            targetPosition = transform.position + movementDirection * moveSpeed * Time.deltaTime;

            // Move the player to the target position
            transform.position = Vector3.Lerp(transform.position, targetPosition, 0.5f);
        }//mobbile input End
    }
    public void HandleInput()
    {
        
        // Check for horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate movement direction based on input
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, 0f).normalized;

        // Calculate target position for player movement
        targetPosition = transform.position + movementDirection * moveSpeed * Time.deltaTime;

        // Move the player to the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.5f); 
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            isRight = true;
            //Debug.Log("block detected");
            //breakAudio.Play();
            audioManager.PlaySfx(audioManager.breakWall);
            ScoreManager.instance.AddScore();
        }
        else if (collision.gameObject.CompareTag("wrongBlock"))
        {
            isWrong = true;
            //deathAudio.Play();
            audioManager.PlaySfx(audioManager.death);
        }
        else if(collision.gameObject.CompareTag("Finish")) 
        {
            isFinish = true;
            animator.SetTrigger("win");
            audioManager.PlaySfx(audioManager.winSound);
            moveSpeed = 0f;
            
        }
    }
    private void PlayerAnimation()
    {
        if (isRight)
        {

            animator.SetTrigger("kick");
           // breakAudio.Play();
            //Debug.Log("set trigger kick");
            isRight = false;
            StartCoroutine(PlayRunAnimationAfterKick());
            //ScoreManager.instance.AddScore();
            //IncreasedSpeed();
           
        }
        else if (isWrong)
        {
            StartCoroutine(PlayerDeathAnimation());
            
        }
    }
    private IEnumerator PlayRunAnimationAfterKick()
    {
        // Wait for a short duration to ensure the kick animation has time to start playing
        yield return new WaitForSeconds(0.4f);

        // Trigger the run animation after the kick animation has played
        animator.SetTrigger("run");
        //Debug.Log("Set trigger Run");
    }
    private IEnumerator PlayerDeathAnimation()
    {
        yield return new WaitForSeconds(0.01f);
        animator.SetTrigger("death");
       // Debug.Log("death trigger");
        moveSpeed = 0f;
        //Die();
        isDead = true;

    }
    public void Die()
    {
        rb.velocity = Vector3.zero;
        
        gameOver.SetActive(true);
    }
    public void IncreasedSpeed()//not using.........
    {
        if(ScoreManager.instance.score % 20 == 0 && moveSpeed<maxMoveSpeed)
        {
            moveSpeed += 0.5f;
        }
    }
}
