using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    private float spawnRangeX = 10;
    private float spawnZMin = 15;
    private float spawnZMax = 25;

    public int enemyCount;
    public int waveCount = 1;

    public GameObject player;

    // Enemy speed
    public float enemySpeed = 5f;
    public float speedIncreasePerWave = 1f;

    // Update is called once per frame
    void Update()
    {
        // Count enemies
        enemyCount =
            GameObject.FindGameObjectsWithTag("Enemy").Length;

        // If all enemies have been removed,
        // spawn the next wave
        if (enemyCount == 0)
        {
            SpawnEnemyWave(waveCount);
        }
    }

    // Generate random spawn position
    Vector3 GenerateSpawnPosition()
    {
        float xPos =
            Random.Range(-spawnRangeX, spawnRangeX);

        float zPos =
            Random.Range(spawnZMin, spawnZMax);

        return new Vector3(xPos, 0, zPos);
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        Vector3 powerupSpawnOffset =
            new Vector3(0, 0, -15);

        // If no powerups remain, spawn a powerup
        if (GameObject.FindGameObjectsWithTag("Powerup").Length == 0)
        {
            Instantiate(
                powerupPrefab,
                GenerateSpawnPosition() + powerupSpawnOffset,
                powerupPrefab.transform.rotation
            );
        }

        // Spawn enemies based on wave number
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            GameObject enemy = Instantiate(
                enemyPrefab,
                GenerateSpawnPosition(),
                enemyPrefab.transform.rotation
            );

            // Set enemy speed
            EnemyX enemyScript =
                enemy.GetComponent<EnemyX>();

            if (enemyScript != null)
            {
                enemyScript.speed = enemySpeed;
            }
        }

        // Increase enemy speed for next wave
        enemySpeed += speedIncreasePerWave;

        // Increase wave count
        waveCount++;

        // Reset player position
        ResetPlayerPosition();
    }

    // Move player back to position in front of own goal
    void ResetPlayerPosition()
    {
        player.transform.position =
            new Vector3(0, 1, -7);

        player.GetComponent<Rigidbody>().linearVelocity =
            Vector3.zero;

        player.GetComponent<Rigidbody>().angularVelocity =
            Vector3.zero;
    }
}