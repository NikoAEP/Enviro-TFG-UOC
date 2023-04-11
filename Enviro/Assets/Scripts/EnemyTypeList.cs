using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyTypeList", menuName = "ScriptableObjects/EnemyTypeList", order = 1)]
public class EnemyTypeList : ScriptableObject
{
    public List<EnemyType> enemyTypes;
    public int maxDifficulty;
}