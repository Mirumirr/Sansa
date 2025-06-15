using UnityEngine;
using System;
using System.Collections.Generic;

public abstract class UnitBase : MonoBehaviour
{
    public string UnitName { get; protected set; }
    public int MaxHP { get; protected set; }
    public int HP { get; protected set; }
    public int MaxShield { get; protected set; }
    public int Shield { get; protected set; }
    public float Initiative { get; protected set; }
    public List<SkillBase> Skills { get; protected set; }
    public TeamType Team { get; protected set; }
    public bool IsAlive => HP > 0;

    // События для UI
    public event Action<UnitBase> OnHPChanged;
    public event Action<UnitBase> OnShieldChanged;
    public event Action<UnitBase> OnDeath;

    public virtual void InitFromConfig(UnitConfig config, TeamType team)
    {
        if (config == null) throw new ArgumentNullException(nameof(config));
        UnitName = config.unitName;
        MaxHP = HP = config.baseHP;
        MaxShield = Shield = config.baseShield;
        Initiative = config.baseInitiative;
        Team = team;
        Skills = new List<SkillBase>();
        if (config.skills != null)
        {
            foreach (var skillCfg in config.skills)
            {
                if (skillCfg?.skill != null)
                    Skills.Add(ScriptableObject.Instantiate(skillCfg.skill));
            }
        }
    }

    public virtual void TakeDamage(int amount)
    {
        if (amount < 0) return;
        int damageToShield = Mathf.Min(Shield, amount);
        Shield -= damageToShield;
        int damageToHP = amount - damageToShield;
        HP = Mathf.Max(0, HP - damageToHP);

        OnShieldChanged?.Invoke(this);
        OnHPChanged?.Invoke(this);

        if (HP <= 0)
            Die();
    }

    protected virtual void Die()
    {
        OnDeath?.Invoke(this);
        // Можно добавить анимацию, удаление с поля и т.д.
    }
} 