using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyType", menuName = "ScriptableObjects/EnemyType", order = 1)]
public class EnemyType : ScriptableObject
{
    public GameObject prefab; // prefab de la Suraba
    public string typeName; // Nombre del tipo de Suraba
    public int health; // la vida de la Suraba
    public int attackDamage; // la cantidad daño que hace
    public int value; // el valor que da al derrotar
    public float[] spawnChance; // la probabilidad de spawn
}
