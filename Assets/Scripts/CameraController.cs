using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Reference to the player's transform
    public Vector3 offset = new Vector3(0f, 2.5f, -5f); // Offset of the camera from the player

    public float smoothSpeed = 0.125f; // Speed at which the camera follows the player

    private void LateUpdate()
    {
        if (target == null)
            return;

        // Calculate target position with offset
        Vector3 desiredPosition = target.position + offset;

        // Set the camera's position directly to the desired position
        transform.position = desiredPosition;

        // Rotate the camera to always look at the player
       // transform.LookAt(target);
    }
}
