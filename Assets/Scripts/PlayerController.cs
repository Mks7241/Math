using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6f; // Speed at which the player moves

    private Vector3 targetPosition; // Target position for player movement
    private Rigidbody rb;
    private Animator animator;
    private bool isRight;
    private bool isWrong;
    public AudioSource breakAudio;
    public AudioSource deathAudio;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        animator = GetComponent<Animator>();
        isRight = false;
        isWrong = false;
    }
    private void Update()
    {
        // Move the player forward automatically
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // Handle player input
        HandleInput();
        PlayerAnimation();
    }

    private void HandleInput()
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
            Debug.Log("block detected");
            breakAudio.Play();
        }
        else if (collision.gameObject.CompareTag("wrongBlock"))
        {
            isWrong = true;
            deathAudio.Play();
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

    }
}
