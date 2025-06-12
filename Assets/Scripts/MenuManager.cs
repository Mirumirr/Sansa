using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartNewGame()
    {
        SceneManager.LoadScene("Mission01");
    }
}
