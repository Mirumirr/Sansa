using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Battle/MissionConfig")]
public class MissionConfig : ScriptableObject
{
    public string missionName;
    [TextArea] public string description;
    public List<UnitConfig> playerTeam;
    public List<UnitConfig> enemyTeam;
    // Можно добавить награды, условия победы и т.д.
}