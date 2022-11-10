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
        //Farkl� sahneler oldu�u i�in bool de�eri ramde tutularak istenildi�i zaman ula��lmaktad�r.
        Loading.run = true;
    }
    
    /// <summary>
    /// Render S�res,ne ba�l� olarak Loading ekran�na ge�er.
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
    /// Ekran a��ld���nda score kontrol eder ve atamas�n� yapar.
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
