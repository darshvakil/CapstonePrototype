using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject bossPrefab;  // Assign the boss prefab in the Inspector
    public Transform spawnPoint;   // Set the location where the boss will appear
    private bool bossSpawned = false; // Prevents multiple spawns

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered by: " + other.name); // Check what is triggering the event

        if (other.CompareTag("Player") && !bossSpawned)
        {
            SpawnBoss();
            bossSpawned = true; // Prevent multiple spawns
        }
    }


    void SpawnBoss()
    {
        Instantiate(bossPrefab, spawnPoint.position, Quaternion.identity);
        Debug.Log("Boss Spawned!");
    }
}
