using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;

    public List<RobotUnit> playerUnits = new List<RobotUnit>();
    public List<RobotUnit> enemyUnits = new List<RobotUnit>();
    private bool battleInProgress = false;

    private void Awake()
    {
        Instance = this;
        battleInProgress = false;
    }

    public void RegisterPlayer(RobotUnit unit)
    {
        playerUnits.Add(unit);
    }

    public void RegisterEnemy(RobotUnit unit)
    {
        enemyUnits.Add(unit);
    }

    public void StartBattle()
    {
        battleInProgress = true;
        Debug.Log("Бой начался!");
    }

    public RobotUnit GetEnemyTargetFor(RobotUnit attacker)
    {
        var targets = attacker.isEnemy ? playerUnits : enemyUnits;

        foreach (var target in targets)
        {
            if (target != null && target.IsAlive())
                return target;
        }

        return null;
    }

    public void CheckEndBattle()
    {
        bool allEnemiesDead = enemyUnits.TrueForAll(u => u == null || !u.IsAlive());
        bool allPlayersDead = playerUnits.TrueForAll(u => u == null || !u.IsAlive());

        if (allEnemiesDead)
        {
            Debug.Log("Победа! Все враги побеждены.");
            EndBattle(true);
        }
        else if (allPlayersDead)
        {
            Debug.Log("Поражение... Все союзники погибли.");
            EndBattle(false);
        }
    }

    private void EndBattle(bool isVictory)
    {
        battleInProgress = false;
        if (isVictory)
        {
            Debug.Log("Показать экран победы");
        }
        else
        {
            Debug.Log("Показать экран поражения");
        }
    }

    public bool IsBattleActive() => battleInProgress;
}