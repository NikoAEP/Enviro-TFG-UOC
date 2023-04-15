using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    public EnemyTypeList enemyTypes;

    // Define variables for position ranges
    public List<Transform> totalSpawnPoints;

    private void Start()
    {
        int difficulty = GameManager.instance.difficulty;
        print(difficulty);
        // Generate enemies and collectibles based on difficulty level
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

        for (int i = 0; i < maxSpawnPoints; i++)
        {
            int spawnIndex = Random.Range(0, totalSpawnPoints.Count);
            Transform spawnPoint = totalSpawnPoints[spawnIndex];

            EnemyType enemyType = SelectEnemyType(difficulty);
            GameObject enemyObject = Instantiate(enemyType.prefab, spawnPoint.position, Quaternion.identity);
        }
        
    }

    private EnemyType SelectEnemyType(int difficulty)
    {
        float enemyTypeRoll = Random.value;
        foreach (EnemyType enemyType in enemyTypes.types)
        {
            if (enemyTypeRoll <= enemyType.spawnChance[difficulty])
            {
                print(enemyType.typeName);
                return enemyType;                
            }
            enemyTypeRoll -= enemyType.spawnChance[difficulty];
        }
        return null;
    }

}
