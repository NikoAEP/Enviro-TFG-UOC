using UnityEngine;

[CreateAssetMenu(fileName = "NewCollectibleType", menuName = "ScriptableObjects/CollectibleType", order = 3)]
public class CollectibleType : ScriptableObject
{
    public GameObject prefab; // un prefab de Recyclo
    public string typeName; // el nombre del tipo de Recyclo
    public int value; // el valor que da el Recyclo
    public float[] spawnChance; // la probabilidad de spawn del Recyclo
}

