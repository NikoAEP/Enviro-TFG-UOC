using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    
    public CollectibleTypeList collectibleTypes;

    // Define variables for position ranges
    public List<Transform> totalSpawnPoints;
    private List<Transform> availableSpawnPoints;
    private List<Transform> occupiedSpawnPoints;
    

    private void Start()
    {
        int difficulty = GameManager.instance.difficulty;
        print(difficulty);

        availableSpawnPoints = new List<Transform>(totalSpawnPoints);
        Shuffle(availableSpawnPoints);
        occupiedSpawnPoints = new List<Transform>();
        // Genera collectibles basado en el nivel de dificultad
        SpawnCollectibles(difficulty);
    }

    private void SpawnCollectibles(int difficulty)
    {
        int maxSpawnPoints;
        if(difficulty == collectibleTypes.maxDifficulty)
        {
            maxSpawnPoints = totalSpawnPoints.Count;
        }
        else {
            maxSpawnPoints = totalSpawnPoints.Count - (collectibleTypes.maxDifficulty - difficulty);
        }
        print("Total SP: " + totalSpawnPoints.Count);
        print("Max SP: " + maxSpawnPoints);
        print("Current Dif.: " + difficulty);

        // Se eliminan spawn points que sobran
        while (availableSpawnPoints.Count > maxSpawnPoints)
        {
            availableSpawnPoints.RemoveAt(Random.Range(0, availableSpawnPoints.Count));
        }

        // Se generan coleccionables en cada punto de spawn
        foreach (Transform spawnPoint in availableSpawnPoints)
        {
            // Revisa si el punto de spawn está ocupado
            if (occupiedSpawnPoints.Contains(spawnPoint))
            {
                continue;
            }
            CollectibleType collectibleType = SelectCollectibleType(difficulty);
            GameObject collectibleObject = Instantiate(collectibleType.prefab, spawnPoint.position, Quaternion.identity);
            occupiedSpawnPoints.Add(spawnPoint);
        }
        
    }

    private CollectibleType SelectCollectibleType(int difficulty)
    {
        float spawnChanceTotal = 0f;
        foreach (CollectibleType collectibleType in collectibleTypes.types)
        {
            spawnChanceTotal += collectibleType.spawnChance[difficulty];
        }
        
        float spawnChanceThreshold = Random.Range(0f, spawnChanceTotal);
        foreach (CollectibleType collectibleType in collectibleTypes.types)
        {
            float spawnChance = collectibleType.spawnChance[difficulty];
            if (spawnChanceThreshold <= spawnChance)
            {
                print(collectibleType.typeName);
                return collectibleType;                
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
