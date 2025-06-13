using UnityEngine;

[CreateAssetMenu(fileName = "NewMissionConfig", menuName = "Prototype01/Mission Config")]
public class MissionConfig : ScriptableObject
{
    public string missionName;
    [TextArea] public string description;
    public Sprite background;

    public EnemyData[] enemies; // Пока просто массив врагов (будем расширять позже)
}