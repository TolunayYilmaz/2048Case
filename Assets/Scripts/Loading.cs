using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    [SerializeField] private float standbyTime = 0;

    [SerializeField] Slider loading;
    public static bool run = false;
    private float startTime = 0;

    private void Update()
    {
        if (run == true)
        {
            LoadGame(standbyTime);
        }
    }

    /// <summary>
    /// Belirlenen S�re Sonunda  Oyun ekran�na ge�er.
    /// </summary>
    /// <param name="maxValue"></param>
    public void LoadGame(float maxValue)
    {
        startTime += Time.deltaTime;
        loading.value = startTime;
        loading.maxValue = maxValue;
        loading.minValue = 0;

        if (loading.value == 5)
        {
            SceneManager.LoadScene("Game");
            run = false;
            startTime = 0;
        }
    }
}
