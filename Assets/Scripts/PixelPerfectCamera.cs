using UnityEngine;

public class PixelPerfectCamera : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject
    private Camera mainCamera;

    public float pixelToUnits = 40f; // Determines the scale of a Unity unit in pixels

    void Start()
    {
        mainCamera = Camera.main; // Get the main camera
    }

    void LateUpdate() // Using LateUpdate ensures movement calculations are done first
    {
        if (player != null)
        {
            float player_x = player.transform.position.x;
            float player_y = player.transform.position.y;

            float rounded_x = RoundToNearestPixel(player_x);
            float rounded_y = RoundToNearestPixel(player_y);

            Vector3 new_pos = new Vector3(rounded_x, rounded_y, -10.0f); // Ensure camera remains in 2D
            mainCamera.transform.position = new_pos;
        }
    }

    private float RoundToNearestPixel(float unityUnits)
    {
        float valueInPixels = unityUnits * pixelToUnits;
        valueInPixels = Mathf.Round(valueInPixels); // Round to nearest pixel
        return valueInPixels * (1 / pixelToUnits); // Convert back to Unity units
    }
}
