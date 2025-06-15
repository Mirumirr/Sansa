using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance { get; private set; }

    public BattleState State { get; private set; } = BattleState.NotStarted;
    private List<UnitBase> playerUnits = new List<UnitBase>();
    private List<UnitBase> enemyUnits = new List<UnitBase>();

    // События для UI
    public event Action OnBattleStart;
    public event Action OnBattleEnd;
    public event Action<UnitBase> OnUnitSpawned;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void RegisterUnit(UnitBase unit)
    {
        if (unit == null) return;
        if (unit.Team == TeamType.Player)
            playerUnits.Add(unit);
        else
            enemyUnits.Add(unit);

        OnUnitSpawned?.Invoke(unit);
    }

    public void StartBattle()
    {
        State = BattleState.InProgress;
        OnBattleStart?.Invoke();
        // Запуск логики боя
    }

    public void EndBattle(bool victory)
    {
        State = victory ? BattleState.Victory : BattleState.Defeat;
        OnBattleEnd?.Invoke();
        // Показать награды, итоги и т.д.
    }

    // Пример метода для получения живых юнитов
    public IReadOnlyList<UnitBase> GetAliveUnits(TeamType team)
    {
        return team == TeamType.Player
            ? playerUnits.FindAll(u => u.IsAlive)
            : enemyUnits.FindAll(u => u.IsAlive);
    }

    public bool IsBattleActive() => State == BattleState.InProgress;
}