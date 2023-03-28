using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollectibleSpawner : MonoBehaviour
{
    // Define variables for difficulty level and enemy/collectible prefabs
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private List<GameObject> collectiblePrefabs;

    // Define variables for position ranges
    [SerializeField] private Transform enemySpawnRangeMin;
    [SerializeField] private Transform enemySpawnRangeMax;
    [SerializeField] private Transform collectibleSpawnRangeMin;
    [SerializeField] private Transform collectibleSpawnRangeMax;

    [SerializeField] private LayerMask spawnableGround;
    // Define variables for the number of enemies and collectibles to generate
    [SerializeField] private int numEnemies;
    [SerializeField] private int numCollectibles;

    private void Start()
    {
        int difficulty = GameManager.instance.difficulty;
        // Generate enemies and collectibles based on difficulty level
        GenerateEnemies(difficulty);
        GenerateCollectibles(difficulty);
    }

    private void GenerateEnemies(int difficulty)
    {
        // Define a random number generator
        System.Random rnd = new System.Random();
        
        // Loop through the desired number of enemies to generate
        numEnemies = GameManager.instance.difficulty * 2;
        for (int i = 0; i < numEnemies; i++)
        {
           // Generate a random position within the enemy spawn range
            float x = Random.Range(enemySpawnRangeMin.position.x, enemySpawnRangeMax.position.x);
            float y = Random.Range(enemySpawnRangeMin.position.y, enemySpawnRangeMax.position.y);
            Vector2 enemyPos = new Vector2(x, y);

            // Select a random enemy prefab based on difficulty level
            GameObject enemyPrefab = enemyPrefabs[rnd.Next(enemyPrefabs.Count)];          

            // Instantiate the selected enemy prefab at the random position
            Instantiate(enemyPrefab, enemyPos, Quaternion.identity);

        }
    }

    private void GenerateCollectibles(int difficulty)
    {
        // Define a random number generator
        System.Random rnd = new System.Random();
        
        numCollectibles = GameManager.instance.difficulty * 2;
        // Loop through the desired number of collectibles to generate
        for (int i = 0; i < numCollectibles; i++)
        {
            // Generate a random position within the collectible spawn range        
            float x = Random.Range(collectibleSpawnRangeMin.position.x, collectibleSpawnRangeMax.position.x);
            float y = Random.Range(collectibleSpawnRangeMin.position.y, collectibleSpawnRangeMax.position.y);
            Vector2 collectiblePos = new Vector2(x, y);

            // Select a random collectible prefab based on difficulty level
            GameObject collectiblePrefab = collectiblePrefabs[rnd.Next(collectiblePrefabs.Count)];

            // Instantiate the selected collectible prefab at the random position
            Instantiate(collectiblePrefab, collectiblePos, Quaternion.identity);

        }
    }

}
