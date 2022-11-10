using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text scoreTextPanel1, scoreTextPanel2;
    [SerializeField] Text highScoreTextPanel1, highScoreTextPanel2;
    private int _scoreStart = 0;
    private  int highScore=0;
   
    public int scoreStart { get { return _scoreStart; } }
    // Update is called once per frame

    private void Start()
    {
        ScoreAwake();
    }


    /// <summary>
    /// Score güncelemesi yapmaktadýr.Highscore geçilirse yeni score atanýr.
    /// </summary>
    /// <param name="Score"></param>
    public void ScoreUpdate(int Score)
    {   
        _scoreStart += Score;
        if (_scoreStart > highScore)
        {
            highScore = _scoreStart;
            highScoreTextPanel1.text = "HighScore: " + highScore;
            highScoreTextPanel2.text = "HighScore: " + highScore;
        }
            scoreTextPanel1.text = "Score: " + _scoreStart;
            scoreTextPanel2.text= "Score: " + _scoreStart;
    }

    /// <summary>
    /// Highscore güncellemesi yapýp kaydetmektedir.
    public void HighScoreUpdate()
    {

      if (PlayerPrefs.HasKey("Score"))
      {
          if (PlayerPrefs.GetInt("Score") < _scoreStart)
          {
              PlayerPrefs.SetInt("Score", _scoreStart);
          }
         
        }

      else
      {
          PlayerPrefs.SetInt("Score", _scoreStart);
           
      }
    }
    public void ScoreAwake()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            highScore = PlayerPrefs.GetInt("Score");
            highScoreTextPanel1.text = "HighScore: " + highScore;
            highScoreTextPanel2.text = "HighScore: " + highScore;

        }
        else
        {
            highScoreTextPanel1.text = "HighScore: " + 0;
            highScoreTextPanel2.text = "HighScore: " + highScore;

        }
    }
}
