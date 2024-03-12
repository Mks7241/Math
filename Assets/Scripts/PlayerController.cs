using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 4f; // Speed at which the player moves

    private Vector3 targetPosition; // Target position for player movement
    private Rigidbody rb;
    private Animator animator;
    private bool isRight;
    private bool isWrong;
    public AudioSource breakAudio;
    public AudioSource deathAudio;
    public bool isFinish;
    AudioManager audioManager;
    private Vector2 startTouchPosition;
    public LayerMask groundLayer;
    public bool isGrounded;
    public GameObject gameOver;
    public float deathHeight = -2.0f;

    private void Start()
    {
        targetPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        rb.freezeRotation = true;
        animator = GetComponent<Animator>();
        isRight = false;
        isWrong = false;
        isFinish = false;


    }
    private void Update()
    {
        // Move the player forward automatically
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        if (transform.position.y < deathHeight)
        {
            Die();
        }
        // Handle player input
        HandleInput();
        PlayerAnimation();
    }

    private void HandleInput()
    {
        isGrounded = Physics.Raycast(transform.position,Vector3.down,0.1f,groundLayer);
        /*
        // Check for horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate movement direction based on input
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, 0f).normalized;

        // Calculate target position for player movement
        targetPosition = transform.position + movementDirection * moveSpeed * Time.deltaTime;

        // Move the player to the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.5f); */
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            isRight = true;
            Debug.Log("block detected");
            breakAudio.Play();
        }
        else if (collision.gameObject.CompareTag("wrongBlock"))
        {
            isWrong = true;
            deathAudio.Play();
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
            Debug.Log("set trigger kick");
            isRight = false;
            StartCoroutine(PlayRunAnimationAfterKick());
           
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
        Debug.Log("Set trigger Run");
    }
    private IEnumerator PlayerDeathAnimation()
    {
        yield return new WaitForSeconds(0.01f);
        animator.SetTrigger("death");
        Debug.Log("death trigger");
        moveSpeed = 0f;
        Die();

    }
    public void Die()
    {
        rb.velocity = Vector3.zero;
        
        gameOver.SetActive(true);
    }
}
