using UnityEngine;
using UnityEngine.UI;

public class MissionManager : MonoBehaviour
{
    public GameObject missionIntroPanel;
    public BattleSpawner battleSpawner;

    public void StartMission()
    {
        missionIntroPanel.SetActive(false);
        battleSpawner.SpawnUnits();
        BattleManager.Instance.StartBattle();
    }
}