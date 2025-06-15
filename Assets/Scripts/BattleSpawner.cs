using UnityEngine;

public class BattleSpawner : MonoBehaviour
{
    public UnitFactory unitFactory;
    public MissionConfig missionConfig;
    public Transform playerParent;
    public Transform enemyParent;

    private int playerSpawnIndex = 0;
    private int enemySpawnIndex = 0;

    public void SpawnUnits()
    {
        if (missionConfig == null)
        {
            Debug.LogError("MissionConfig не задан!");
            return;
        }
        if (unitFactory == null)
        {
            Debug.LogError("UnitFactory не задан!");
            return;
        }
        foreach (var config in missionConfig.playerTeam)
        {
            var unit = unitFactory.CreateUnit(config, GetPlayerSpawnPoint(), Quaternion.identity, playerParent, TeamType.Player);
            BattleManager.Instance.RegisterUnit(unit);
        }
        foreach (var config in missionConfig.enemyTeam)
        {
            var unit = unitFactory.CreateUnit(config, GetEnemySpawnPoint(), Quaternion.identity, enemyParent, TeamType.Enemy);
            BattleManager.Instance.RegisterUnit(unit);
        }
    }

    private Vector3 GetPlayerSpawnPoint()
    {
        Vector3 pos = new Vector3(-5 + playerSpawnIndex * 2, 0, 0); // Сдвиг по X
        playerSpawnIndex++;
        return pos;
    }
    private Vector3 GetEnemySpawnPoint()
    {
        Vector3 pos = new Vector3(5 + enemySpawnIndex * 2, 0, 0); // Сдвиг по X
        enemySpawnIndex++;
        return pos;
    }
}