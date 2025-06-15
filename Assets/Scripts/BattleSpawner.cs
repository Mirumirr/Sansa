using System.Collections.Generic;
using UnityEngine;

public class BattleSpawner : MonoBehaviour
{
    public Transform[] playerSpawnPoints;
    public Transform[] enemySpawnPoints;

    void Start()
    {
        SpawnPlayerTeam();
        SpawnEnemies();
        // BattleManager.Instance.StartBattle(); // Удалено, бой стартует после нажатия кнопки
    }

    void SpawnPlayerTeam()
    {
        List<RobotInstance> team = GameManager.Instance.playerTeam;

        for (int i = 0; i < team.Count && i < playerSpawnPoints.Length; i++)
        {
            RobotInstance instance = team[i];
            GameObject bot = Instantiate(instance.Prefab, playerSpawnPoints[i].position, Quaternion.identity);

            // В будущем: установка ХП, модулей и т.д.
        }
    }

    void SpawnEnemies()
    {
        var mission = GameManager.Instance.GetCurrentMission();
        if (mission == null || mission.enemies == null) return;

        for (int i = 0; i < mission.enemies.Length && i < enemySpawnPoints.Length; i++)
        {
            Instantiate(mission.enemies[i].enemyPrefab, enemySpawnPoints[i].position, Quaternion.identity);
        }
    }
}