using System.Collections.Generic;
using UnityEngine;

public class BattleSpawner : MonoBehaviour
{
    public Transform[] playerSpawnPoints;

    void Start()
    {
        SpawnPlayerTeam();
    }

    void SpawnPlayerTeam()
    {
        List<RobotInstance> team = GameManager.Instance.playerTeam;

        for (int i = 0; i < team.Count && i < playerSpawnPoints.Length; i++)
        {
            RobotInstance instance = team[i];

            GameObject bot = Instantiate(instance.Prefab, playerSpawnPoints[i].position, Quaternion.identity);

            // В будущем можно сюда добавить: установка HP, модулей, скиллов и т.п.
        }
    }
}