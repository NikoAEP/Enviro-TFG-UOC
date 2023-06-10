using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    // Se define la lista de tipos de coleccionables
    public CollectibleTypeList collectibleTypes;

    // Se definen los transforms que guardan los puntos de spawn
    public List<Transform> totalSpawnPoints;
    private List<Transform> availableSpawnPoints; // puntos de spawn disponibles
    private List<Transform> occupiedSpawnPoints;  // puntos de spawn ocupados
    

    private void Start()
    {
        int difficulty = GameManager.instance.difficulty; // la difficultad será la que sea definida por el GM
        print(difficulty);

        availableSpawnPoints = new List<Transform>(totalSpawnPoints); // los puntos disponibles será, inicialmente, todos los definidos
        Shuffle(availableSpawnPoints); // se mezclan los puntos de spawn
        occupiedSpawnPoints = new List<Transform>(); // se genera una lista vacía de puntos ocupados
        // Genera collectibles basado en el nivel de dificultad
        SpawnCollectibles(difficulty);
    }

    private void SpawnCollectibles(int difficulty)
    {
        int maxSpawnPoints; // máximo número de puntos a utilizar según la dificultad
        if(difficulty == collectibleTypes.maxDifficulty) // si la dificultad es la máxima,
        {
            maxSpawnPoints = totalSpawnPoints.Count - collectibleTypes.maxDifficulty; // se utilizan los puntos definidos menos la dificultad máxima
        }
        else if (difficulty == 1) // si es 1
        {
            maxSpawnPoints = totalSpawnPoints.Count - difficulty; // se usan todos menos 1
        }
        else 
        {
            maxSpawnPoints = totalSpawnPoints.Count; // si es la más fácil, se usan todos
        }
        
        // Se eliminan spawn points que sobran
        while (availableSpawnPoints.Count > maxSpawnPoints)
        {
            availableSpawnPoints.RemoveAt(Random.Range(0, availableSpawnPoints.Count));
        }

        // Se generan coleccionables en cada punto de spawn
        foreach (Transform spawnPoint in availableSpawnPoints)
        {
            // Primero mira si el punto está ocupado
            if (occupiedSpawnPoints.Contains(spawnPoint))
            {
                continue; // si lo está, pasa al siguiente, si no sigue con el código
            }
            CollectibleType collectibleType = SelectCollectibleType(difficulty); // selecciona un tipo de enemigo según la dificultad
            GameObject collectibleObject = Instantiate(collectibleType.prefab, spawnPoint.position, Quaternion.identity); // se genera un coleccionable en el punto actual
            occupiedSpawnPoints.Add(spawnPoint); // se añade el punto actual a la lista de ocupados
        }
        
    }

    // Selecciona un tipo de coleccionable según la dificultad
    private CollectibleType SelectCollectibleType(int difficulty)
    {
        float spawnChanceTotal = 0f; // la probabilidad de spawn total es 0 inicialmente
        foreach (CollectibleType collectibleType in collectibleTypes.types) // para cada coleccionable dentro de la lista de coleccionables
        {
            spawnChanceTotal += collectibleType.spawnChance[difficulty]; // se sumará la probabilidad de cada coleccionable según la dificultad actual 
        }
        
        float spawnChanceThreshold = Random.Range(0f, spawnChanceTotal); // se selecciona un número entre 0 y la probabilidad total
        foreach (CollectibleType collectibleType in collectibleTypes.types) // para cada coleccionable dentro de la lista de coleccionables
        {
            float spawnChance = collectibleType.spawnChance[difficulty]; // la probabilidad de spawn es la que sea según la dificultad actual
            if (spawnChanceThreshold <= spawnChance) // si esta probabilidad es superior a la que se ha seleccionado aleatoriamente,
            {
                return collectibleType; // se elige ese coleccionable                
            }
            else
            {
                spawnChanceThreshold -= spawnChance; // si no, se resta el valor de probabilidad de spawn
            }
        }
        return null; // no debería llegar a esta línea, pero por respaldo se incluye
    }

    private void Shuffle(List<Transform> list) // método de utilidad para mezclar una lista
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
