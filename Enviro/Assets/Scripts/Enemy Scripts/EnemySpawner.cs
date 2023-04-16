using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Se define la lista de tipos de enemigos
    [SerializeField] private EnemyTypeList enemyTypes;

    // Se definen los transforms que guardan los puntos de spawn
    [SerializeField] private List<Transform> totalSpawnPoints;

    private List<Transform> availableSpawnPoints; // puntos de spawn disponibles
    private List<Transform> occupiedSpawnPoints; // puntos de spawn ocupados
    
    private void Start()
    {
        int difficulty = GameManager.instance.difficulty; // la difficultad será la que sea definida por el GM
        print(difficulty);
        availableSpawnPoints = new List<Transform>(totalSpawnPoints); // los puntos disponibles será, inicialmente, todos los definidos
        Shuffle(availableSpawnPoints); // se mezclan los puntos de spawn
        occupiedSpawnPoints = new List<Transform>(); // se genera una lista vacía de puntos ocupados
        SpawnEnemies(difficulty); // se Spawnean enemigos según dificultad
    }

    private void SpawnEnemies(int difficulty)
    {
        int maxSpawnPoints; // máximo número de puntos a utilizar según la dificultad
        if(difficulty == enemyTypes.maxDifficulty) // si la dificultad es la máxima,
        {
            maxSpawnPoints = totalSpawnPoints.Count; // se utilizan todos los puntos definidos
        }
        else if (difficulty == 1) // si la dificultad es 1,
        {
            maxSpawnPoints = totalSpawnPoints.Count - difficulty; // se usan todos menos el valor de la dificultad
        }
        else {
            maxSpawnPoints = totalSpawnPoints.Count - (enemyTypes.maxDifficulty - difficulty); // si no se utiliza la diferencia entre todos los puntos y la máxima dificultad menos la dificultad actual
        }

        // Se eliminan spawn points que sobran
        while (availableSpawnPoints.Count > maxSpawnPoints)
        {
            availableSpawnPoints.RemoveAt(Random.Range(0, availableSpawnPoints.Count));
        }
        
        // Se spawnean enemigos en cada punto disponible
        foreach (Transform spawnPoint in availableSpawnPoints)
        {
            // Primero mira si el punto está ocupado
            if (occupiedSpawnPoints.Contains(spawnPoint))
            {
                continue; // si lo está, pasa al siguiente, si no sigue con el código
            }

            EnemyType enemyType = SelectEnemyType(difficulty); // selecciona un tipo de enemigo según la dificultad
            GameObject enemyObject = Instantiate(enemyType.prefab, spawnPoint.position, Quaternion.identity); // se genera un enemigo en el punto actual
            occupiedSpawnPoints.Add(spawnPoint); // se añade el punto actual a la lista de ocupados
        }        
    }

    // Selecciona un tipo de enemigo según la dificultad
    private EnemyType SelectEnemyType(int difficulty)
    {
        float spawnChanceTotal = 0f; // la probabilidad de spawn total es 0 inicialmente
        foreach (EnemyType enemyType in enemyTypes.types) // para cada enemigo dentro de la lista de enemigos
        {
            spawnChanceTotal += enemyType.spawnChance[difficulty]; // se sumará la probabilidad de cada enemigo según la dificultad actual 
        }
        
        float spawnChanceThreshold = Random.Range(0f, spawnChanceTotal); // se selecciona un número entre 0 y la probabilidad total
        foreach (EnemyType enemyType in enemyTypes.types) // para cada enemigo dentro de la lista de enemigos
        {
            float spawnChance = enemyType.spawnChance[difficulty]; // la probabilidad de spawn es la que sea según la dificultad actual
            if (spawnChanceThreshold <= spawnChance) // si esta probabilidad es superior a la que se ha seleccionado aleatoriamente,
            {
                return enemyType; // se elige ese enemigo               
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
