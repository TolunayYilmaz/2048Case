using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Text highScoreText;
    [SerializeField]Slider LoadSlider;

    private int highScore = 0;
    void Start()
    {
        ScoreControl();
       
    }
    public void LoadGame(int Scene)
    {

        StartCoroutine(LoadScene(Scene));
        //Farklý sahneler olduðu için bool deðeri ramde tutularak istenildiði zaman ulaþýlmaktadýr.
        Loading.run = true;
    }
    
    /// <summary>
    /// Render Süres,ne baðlý olarak Loading ekranýna geçer.
    /// </summary>
    /// <param name="Scene"></param>
    /// <returns></returns>
    IEnumerator LoadScene(int Scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(Scene);
        while (!operation.isDone)
        {
            LoadSlider.value=operation.progress;
            yield return null;
        }
    }
    public void Exit()
    {
        Application.Quit();
    }

    /// <summary>
    /// Ekran açýldýðýnda score kontrol eder ve atamasýný yapar.
    /// </summary>
    private void ScoreControl()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            highScore = PlayerPrefs.GetInt("Score");
            highScoreText.text = "HighScore: " + highScore;

        }
        else
        {
            highScoreText.text = "HighScore: " + 0;
        }
    }
}
