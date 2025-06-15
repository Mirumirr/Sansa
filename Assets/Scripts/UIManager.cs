using UnityEngine;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public GameObject victoryPanel;
    public GameObject defeatPanel;
    public List<UnitUI> playerUnitUIs;

    private void OnEnable()
    {
        if (BattleManager.Instance == null) return;
        BattleManager.Instance.OnBattleStart += OnBattleStart;
        BattleManager.Instance.OnBattleEnd += OnBattleEnd;
        BattleManager.Instance.OnUnitSpawned += OnUnitSpawned;
    }

    private void OnDisable()
    {
        if (BattleManager.Instance == null) return;
        BattleManager.Instance.OnBattleStart -= OnBattleStart;
        BattleManager.Instance.OnBattleEnd -= OnBattleEnd;
        BattleManager.Instance.OnUnitSpawned -= OnUnitSpawned;
    }

    private void OnBattleStart()
    {
        if (victoryPanel) victoryPanel.SetActive(false);
        if (defeatPanel) defeatPanel.SetActive(false);
    }

    private void OnBattleEnd()
    {
        if (BattleManager.Instance.State == BattleState.Victory && victoryPanel)
            victoryPanel.SetActive(true);
        else if (BattleManager.Instance.State == BattleState.Defeat && defeatPanel)
            defeatPanel.SetActive(true);
    }

    private void OnUnitSpawned(UnitBase unit)
    {
        var ui = FindUIForUnit(unit);
        if (ui != null)
        {
            unit.OnHPChanged += ui.UpdateHP;
            unit.OnShieldChanged += ui.UpdateShield;
            unit.OnDeath += ui.OnDeath;
            ui.SetUnit(unit);
        }
    }

    private UnitUI FindUIForUnit(UnitBase unit)
    {
        return playerUnitUIs.Find(u => u.UnitName == unit.UnitName);
    }
} 