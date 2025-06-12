using UnityEngine;
using UnityEngine.UI;

public class MissionManager : MonoBehaviour
{
    public GameObject missionIntroPanel;
    public GameObject playerRobot;
    public GameObject enemyRobot;

    public BattleSystem battleSystem; // чтобы вызывать StartBattle()

    public void StartMission()
    {
        missionIntroPanel.SetActive(false);

        playerRobot.SetActive(true);
        enemyRobot.SetActive(true);

        battleSystem.StartBattle();
    }
}