using UnityEngine;
using UnityEngine.UI;

public class MissionManager : MonoBehaviour
{
    public GameObject missionIntroPanel;

    public void StartMission()
    {
        missionIntroPanel.SetActive(false);
        // Все нужные действия — спавн, включение ботов — происходят внутри BattleSpawner
    }
}