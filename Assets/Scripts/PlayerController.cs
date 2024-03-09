using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the player moves

    private Vector3 targetPosition; // Target position for player movement
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    private void Update()
    {
        // Move the player forward automatically
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // Handle player input
        HandleInput();
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
}
