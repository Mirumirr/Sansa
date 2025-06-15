using UnityEngine;

[CreateAssetMenu(menuName = "Battle/SkillConfig")]
public class SkillConfig : ScriptableObject
{
    public SkillBase skill;
    public float baseCooldown = 1f;
} 