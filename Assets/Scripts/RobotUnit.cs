using UnityEngine;

public class RobotUnit : MonoBehaviour
{
    public string robotName;
    public int maxHP = 100;
    public int currentHP;
    public int attack = 20;

    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log($"{robotName} took {damage} damage. HP: {currentHP}");
    }
}