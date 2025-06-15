using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Battle/UnitConfig")]
public class UnitConfig : ScriptableObject
{
    public string unitName;
    public GameObject prefab;
    public int baseHP = 100;
    public int baseShield = 0;
    public float baseInitiative = 10f;
    public List<SkillConfig> skills;
    // Можно добавить другие параметры (атака, тип, агро и т.д.)
} 