using UnityEngine;
using UnityEngine.Events;

public class CombatUnit : MonoBehaviour
{
    [Header("Основные параметры")]
    public string unitName;
    public float maxHealth = 100f;
    public float currentHealth;

    [Header("Инициатива")]
    public float initiativeSpeed = 10f; // чем больше — тем быстрее ход
    private float currentInitiative = 0f;
    public float initiativeThreshold = 100f;

    [Header("Автоатака")]
    public float autoAttackDamage = 10f;
    public UnityEvent OnAutoAttackReady;

    [Header("Команда")]
    public bool isPlayerTeam;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (currentHealth <= 0) return;

        currentInitiative += initiativeSpeed * Time.deltaTime;

        if (currentInitiative >= initiativeThreshold)
        {
            currentInitiative = 0f;
            AutoAttack();
        }
    }

    private void AutoAttack()
    {
        // В будущем передадим цель из BattleManager
        Debug.Log($"{unitName} совершает автоатаку на врага и наносит {autoAttackDamage} урона!");
        OnAutoAttackReady.Invoke(); // Можно связать с UI, анимацией
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log($"{unitName} погиб.");
            // TODO: Уведомить BattleManager
        }
    }
}