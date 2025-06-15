using UnityEngine;
using UnityEngine.UI;

public class UnitUI : MonoBehaviour
{
    public string UnitName;
    public Slider hpBar;
    public Slider shieldBar;
    public Button ultimateButton;

    private UnitBase unit;

    public void SetUnit(UnitBase unit)
    {
        this.unit = unit;
        UpdateHP(unit);
        UpdateShield(unit);
    }

    public void UpdateHP(UnitBase unit)
    {
        if (hpBar != null)
            hpBar.value = (float)unit.HP / unit.MaxHP;
    }

    public void UpdateShield(UnitBase unit)
    {
        if (shieldBar != null)
            shieldBar.value = unit.MaxShield > 0 ? (float)unit.Shield / unit.MaxShield : 0f;
    }

    public void OnDeath(UnitBase unit)
    {
        if (ultimateButton != null)
            ultimateButton.interactable = false;
    }

    public void OnUltimateButtonClicked()
    {
        if (unit is PlayerUnit player)
        {
            // player.ActivateUltimate();
        }
    }
} 