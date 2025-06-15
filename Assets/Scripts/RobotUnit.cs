using UnityEngine;

public class RobotUnit : MonoBehaviour
{
    public string unitName;
    public int maxHP = 100;
    public int currentHP;
    public int autoAttackDamage = 15;
    public bool isEnemy;
    public GameObject floatingTextPrefab;
    public int initiative = 10;

    public float attackCooldown = 2f;
    private float attackTimer = 0f;

    public float ultimateCooldown = 10f;
    private float ultimateTimer = 0f;
    public bool isPlayerControlled = false;

    private void Start()
    {
        currentHP = maxHP;
        attackTimer = attackCooldown;
        ultimateTimer = 0f;

        if (isEnemy)
            BattleManager.Instance.RegisterEnemy(this);
        else
            BattleManager.Instance.RegisterPlayer(this);
    }

    private void Update()
    {
        if (!IsAlive() || !BattleManager.Instance.IsBattleActive()) return;

        // Автоатака
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0f)
        {
            AutoAttack();
            attackTimer = attackCooldown;
        }

        // Кулдаун ульты
        if (ultimateTimer > 0f)
            ultimateTimer -= Time.deltaTime;
    }

    private void AutoAttack()
    {
        var target = BattleManager.Instance.GetEnemyTargetFor(this);
        if (target != null)
        {
            Debug.Log($"{unitName} автоатакует {target.unitName} и наносит {autoAttackDamage} урона!");
            target.TakeDamage(autoAttackDamage);
        }
    }

    public void ActivateUltimate()
    {
        if (ultimateTimer > 0f)
        {
            Debug.Log($"{unitName}: ульта не готова! Осталось {ultimateTimer:F1} сек.");
            return;
        }
        UseUltimate();
        ultimateTimer = ultimateCooldown;
    }

    private void UseUltimate()
    {
        var target = BattleManager.Instance.GetEnemyTargetFor(this);
        if (target != null)
        {
            int ultimateDamage = autoAttackDamage * 3;
            Debug.Log($"{unitName} использует УЛЬТУ по {target.unitName} и наносит {ultimateDamage} урона!");
            target.TakeDamage(ultimateDamage);
        }
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        ShowFloatingText($"-{amount}");
        Debug.Log($"{unitName} получает {amount} урона!");

        if (currentHP <= 0)
        {
            currentHP = 0;
            Debug.Log($"{unitName} уничтожен!");
            RemoveFromBattle();
            gameObject.SetActive(false);
        }

        BattleManager.Instance.CheckEndBattle();
    }

    private void RemoveFromBattle()
    {
        if (isEnemy)
            BattleManager.Instance.enemyUnits.Remove(this);
        else
            BattleManager.Instance.playerUnits.Remove(this);
        // Также удаляем из очереди инициативы
        // Если юнит был текущим, индекс сдвинется корректно в следующем ходе
        // Если юнитов не осталось, бой завершится
    }

    void ShowFloatingText(string text)
    {
        if (floatingTextPrefab == null)
        {
            Debug.LogWarning($"{unitName}: floatingTextPrefab не назначен!");
            return;
        }

        GameObject ft = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
        ft.GetComponent<FloatingText>().SetText(text);
    }

    public bool IsAlive() => currentHP > 0;
}
