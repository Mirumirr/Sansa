using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    public GameObject gameManagerPrefab;

    void Awake()
    {
        if (GameManager.Instance == null)
        {
            Instantiate(gameManagerPrefab);
        }
    }
}