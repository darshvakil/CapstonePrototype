using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player; // Reference to the player
    [SerializeField] private float smoothSpeed = 5f; // Adjust for smoothness
    [SerializeField] private Vector3 offset; // Offset to maintain desired position

    void LateUpdate()
    {
        if (player != null)
        {
            // Target position
            Vector3 targetPosition = player.position + offset;

            // Smoothly move towards the target position
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }
}