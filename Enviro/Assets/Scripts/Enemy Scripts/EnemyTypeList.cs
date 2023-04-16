using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyTypeList", menuName = "ScriptableObjects/EnemyTypeList", order = 2)]
public class EnemyTypeList : ScriptableObject
{
    public List<EnemyType> types;
    public int maxDifficulty;
}