
using UnityEngine;

[CreateAssetMenu(fileName = "NewMissionConfig", menuName = "Prototype01/Mission Config")]
public class MissionConfig : ScriptableObject
{
    public int difficultyLevel;
    public Sprite backgroundImage;
    public string introText;
}
