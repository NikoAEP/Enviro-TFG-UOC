using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CollectibleTypeList", menuName = "ScriptableObjects/CollectibleTypeList", order = 4)]
public class CollectibleTypeList : ScriptableObject
{
    public List<CollectibleType> types; // Lista de tipos de Recyclos
    public int maxDifficulty; // Máxima dificultad
}