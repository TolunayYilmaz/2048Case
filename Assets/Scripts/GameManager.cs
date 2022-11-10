using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        scoreManager.HighScoreUpdate();
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");

    }

}
