using UnityEngine;

[CreateAssetMenu(menuName = "Battle/Skills/AutoAttackSkill")]
public class AutoAttackSkill : SkillBase
{
    public int damage = 10;

    public override void Activate(UnitBase user, UnitBase target)
    {
        if (user == null || target == null || !target.IsAlive)
            return;
        target.TakeDamage(damage);
        Debug.Log($"{user.UnitName} автоатакует {target.UnitName} и наносит {damage} урона!");
        RaiseSkillUsed();
    }
} 