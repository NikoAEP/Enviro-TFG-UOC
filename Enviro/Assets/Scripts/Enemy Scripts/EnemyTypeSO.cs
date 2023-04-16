using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyType", menuName = "ScriptableObjects/EnemyType", order = 1)]
public class EnemyType : ScriptableObject
{
    public GameObject prefab;
    public string typeName;
    public int health;
    public int attackDamage;
    public int value;
    public float[] spawnChance;
}
