using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // The enemy prefab to spawn.
    public int maxEnemies = 10;     // The maximum number of enemies to spawn.
    public float spawnInterval = 2.0f; // The time between enemy spawns.
    public Transform player;
    public float lowerBound;
    public float upperBound;

    private Transform spawnPoint;
    private float timer = 0.0f;
    private Vector2 spawnPosition;

    void Start()
    {
        spawnPoint = transform; // Use the position of this GameObject as the spawn point.
    }

    void Update()
    {
        // Check if it's time to spawn a new enemy and if we haven't reached the maximum enemy count.
        if (GameManager.instance.enemyCount < maxEnemies && timer >= spawnInterval)
        {
            // Spawn a new enemy at a random position within the spawn radius.
            /*while(true)
            {
                Vector2 randomPosition;
                randomPosition.x = Random.Range(-transform.lossyScale.x/2, transform.lossyScale.x/2);
                randomPosition.y = Random.Range(-transform.lossyScale.y/2, transform.lossyScale.y/2);
                float deltaX = player.position.x - randomPosition.x;
                if ((deltaX > lowerBound.x || deltaX < -lowerBound.x) && (deltaX < upperBound.x || deltaX > -upperBound.x))
                {
                    float deltaY = player.position.y - randomPosition.y;
                    if ((deltaY > lowerBound.y || deltaY < -lowerBound.y) && (deltaY < upperBound.y || deltaY > -upperBound.y))
                    {
                        spawnPosition = spawnPoint.position + new Vector3(randomPosition.x, randomPosition.y, 0);
                        // Instantiate the enemy prefab at the calculated position and reset the timer.
                        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                        GameManager.instance.enemyCount ++;
                        
                        break;
                    }
                }
                    
            }*/
            
            float radius = 0;
            while (Mathf.Abs(radius) < lowerBound)
                radius = Random.Range(-upperBound, upperBound);

            Vector2 randomPosition = Random.insideUnitCircle * radius;
            spawnPosition = spawnPoint.position + new Vector3(randomPosition.x, randomPosition.y);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            GameManager.instance.enemyCount++;
            timer = 0.0f;



        }

        timer += Time.deltaTime;
    }
}
