using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : Singleton<UnitManager>
{
    public GameObject enemyPrefab;  // The enemy prefab to spawn.
    public int maxEnemies = 10;     // The maximum number of enemies to spawn.
    public float spawnInterval = 2.0f; // The time between enemy spawns.
    public float lowerBound;
    public float upperBound;

    private Transform spawnPoint;
    private float timer = 0.0f;
    private Vector2 spawnPosition;

    void Start()
    {
        spawnPoint = GameManager.Instance.player; // Use the position of this GameObject as the spawn point.
    }

    void Update()
    {
        // Check if it's time to spawn a new enemy and if we haven't reached the maximum enemy count.
        if (GameManager.Instance.enemyCount < maxEnemies && timer >= spawnInterval)
        {
            float radius = 0;
            while (Mathf.Abs(radius) < lowerBound)
                radius = Random.Range(-upperBound, upperBound);

            Vector2 randomPosition = Random.insideUnitCircle * radius;
            spawnPosition = spawnPoint.position + new Vector3(randomPosition.x, randomPosition.y);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            GameManager.Instance.enemyCount++;
            timer = 0.0f;
        }

        timer += Time.deltaTime;
    }

    public static void spawnEnemies()
    {
        
    }
}
