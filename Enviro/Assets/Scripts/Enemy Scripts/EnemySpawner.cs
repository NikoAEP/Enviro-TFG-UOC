using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyTypeList enemyTypes;

    // Define variables for position ranges
    [SerializeField] private List<Transform> totalSpawnPoints;

    private List<Transform> availableSpawnPoints;
    private List<Transform> occupiedSpawnPoints;
    
    private void Start()
    {
        int difficulty = GameManager.instance.difficulty;
        print(difficulty);
        availableSpawnPoints = new List<Transform>(totalSpawnPoints);
        Shuffle(availableSpawnPoints);
        occupiedSpawnPoints = new List<Transform>();
        SpawnEnemies(difficulty);
    }

    private void SpawnEnemies(int difficulty)
    {
        int maxSpawnPoints;
        if(difficulty == enemyTypes.maxDifficulty)
        {
            maxSpawnPoints = totalSpawnPoints.Count;
        }
        else {
            maxSpawnPoints = totalSpawnPoints.Count - (enemyTypes.maxDifficulty - difficulty);
        }
        print("Total SP: " + totalSpawnPoints.Count);
        print("Max SP: " + maxSpawnPoints);
        print("Current Dif.: " + difficulty);

        // Se eliminan spawn points que sobran
        while (availableSpawnPoints.Count > maxSpawnPoints)
        {
            availableSpawnPoints.RemoveAt(Random.Range(0, availableSpawnPoints.Count));
        }
        
        // Spawn enemies at each available spawn point
        foreach (Transform spawnPoint in availableSpawnPoints)
        {
            // Check if the spawn point is already occupied
            if (occupiedSpawnPoints.Contains(spawnPoint))
            {
                continue;
            }

            EnemyType enemyType = SelectEnemyType(difficulty);
            GameObject enemyObject = Instantiate(enemyType.prefab, spawnPoint.position, Quaternion.identity);
            occupiedSpawnPoints.Add(spawnPoint);
        }        
    }

    // Selecciona un tipo de enemigo según la dificultad
    private EnemyType SelectEnemyType(int difficulty)
    {
        float spawnChanceTotal = 0f;
        foreach (EnemyType enemyType in enemyTypes.types)
        {
            spawnChanceTotal += enemyType.spawnChance[difficulty];
        }
        
        float spawnChanceThreshold = Random.Range(0f, spawnChanceTotal);
        foreach (EnemyType enemyType in enemyTypes.types)
        {
            float spawnChance = enemyType.spawnChance[difficulty];
            if (spawnChanceThreshold <= spawnChance)
            {
                print(enemyType.typeName);
                return enemyType;                
            }
            else
            {
                spawnChanceThreshold -= spawnChance;
            }
        }
        return null;
    }

    private void Shuffle(List<Transform> list)
    {
        var count = list.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i) {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = list[i];
            list[i] = list[r];
            list[r] = tmp;
        }
    }
}
