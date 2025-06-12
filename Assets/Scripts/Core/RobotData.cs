
using UnityEngine;

[CreateAssetMenu(fileName = "NewRobotData", menuName = "Prototype01/Robot Data")]
public class RobotData : ScriptableObject
{
    public string robotName;
    public int maxHP;
    public int baseAttack;
    public GameObject robotPrefab;
}
