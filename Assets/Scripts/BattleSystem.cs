using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BattleSystem : MonoBehaviour
{
    public RobotUnit player;
    public RobotUnit enemy;
    public Button startButton;

    void Start()
    {
        startButton.onClick.AddListener(StartBattle);
    }

    public void StartBattle()
    {
        startButton.gameObject.SetActive(false); // Скрыть кнопку
        StartCoroutine(FightLoop());
    }

    IEnumerator FightLoop()
    {
        while (player.currentHP > 0 && enemy.currentHP > 0)
        {
            yield return new WaitForSeconds(1.0f);

            enemy.TakeDamage(player.attack);
            if (enemy.currentHP <= 0) break;

            player.TakeDamage(enemy.attack);
        }

        if (player.currentHP <= 0)
            Debug.Log("You Lose");
        else
            Debug.Log("You Win");
    }
}