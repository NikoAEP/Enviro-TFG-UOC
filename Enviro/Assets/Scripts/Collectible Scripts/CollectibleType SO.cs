using UnityEngine;

[CreateAssetMenu(fileName = "NewCollectibleType", menuName = "ScriptableObjects/CollectibleType", order = 3)]
public class CollectibleType : ScriptableObject
{
    public GameObject prefab;
    public string typeName;
    public int value;
    public float[] spawnChance;
}

