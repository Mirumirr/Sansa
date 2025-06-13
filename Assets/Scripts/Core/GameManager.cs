using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Текущие данные игрока")]
    public List<RobotInstance> playerTeam = new List<RobotInstance>();
    public MissionConfig currentMission;

    public MissionConfig GetCurrentMission()
    {
        return currentMission;
    }

    void Awake()
    {
        // Синглтон
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Не уничтожать между сценами
        }
        else
        {
            Destroy(gameObject);
        }
    }
}