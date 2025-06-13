using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "Prototype01/Enemy Data")]
public class EnemyData : ScriptableObject
{
    public GameObject enemyPrefab;
    public int maxHP;
    public int attack;
    // можно добавить дополнительные поля при необходимости
}