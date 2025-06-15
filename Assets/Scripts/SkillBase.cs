using UnityEngine;
using System;

public abstract class SkillBase : ScriptableObject
{
    public string skillName;
    public float cooldown;

    // Событие для UI и логики
    public event Action<SkillBase> OnSkillUsed;
    protected void RaiseSkillUsed() => OnSkillUsed?.Invoke(this);

    // Применение скилла (user — кто применяет, target — цель)
    public abstract void Activate(UnitBase user, UnitBase target);
} 