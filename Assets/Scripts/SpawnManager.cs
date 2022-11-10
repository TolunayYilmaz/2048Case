using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]private float spawnTime;
    [SerializeField] private GameObject squarePrefab;
    [SerializeField] private GameObject backGroundPrefab;
    [SerializeField] private float widht;
    [SerializeField] private float height;
    [SerializeField] GameObject[] numberPrefab;
    public List<GameObject> wayPointList = new List<GameObject>();
     private  ScoreManager scoreManager;
    [SerializeField] GameObject[] gameOverPanel;

 
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        SpawnSquareField();
        Create(2);
 
    }
    
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
          StartCoroutine(SpawnSquare());
        }

    }


    /// <summary>
    /// GameField
    /// </summary>
    void SpawnSquareField()
    {
        Instantiate(backGroundPrefab, new Vector2((widht-1)/2f, (height-1)/2f), Quaternion.identity);

        for (int x = 0; x < widht; x++)
        {

            for (int y = 0; y < height; y++)
            {
               GameObject  squareField= Instantiate(squarePrefab, new Vector2(x, y), Quaternion.identity);
               squareField.GetComponent<NumberControl>().isNumber = false;
               wayPointList.Add(squareField);
               
            }
          
        }
    }

    /// <summary>
    /// Listeyi kontrol eder üstünde eleman olaný çýkarýr listeden kalan yere spawn eder.
    /// </summary>
    public void SpawnNumber()
    {
        Create(1);
    }
   

    /// <summary>
    /// Belirlenen Süre içinde Spawn eder.
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnSquare()
    {
        yield return new WaitForSeconds(spawnTime);
        SpawnNumber();
    }

    /// <summary>
    /// Verilen Sayý ve çeþit kadar üretir.
    /// </summary>
    /// <param name="pieces"></param>
    private void Create(int pieces)
    {
        Control();
       
        for (int i = 0; i < pieces; i++)
        {
            //Random Üretilen Sayýdýr.
            int randomNumber= Random.Range(0, 2);
           
            if (wayPointList.Count != 0)
            {
                int RandomField = Random.Range(0, wayPointList.Count - 1);
             
                Transform randomPos = wayPointList[RandomField].transform;
                Instantiate(numberPrefab[randomNumber], randomPos.position, Quaternion.identity);

            }
            else
            {
                //SquarePow[] eslesme = FindObjectsOfType<SquarePow>();
                //foreach (SquarePow item in eslesme)
                //{
                //    if (item.esles)
                //    {
                //        int RandomField = Random.Range(0, wayPointList.Count - 1);
                //        Control();
                //        Transform randomPos = wayPointList[RandomField].transform;
                //        Instantiate(numberPrefab[randomNumber], randomPos.position, Quaternion.identity);

                //    }
                //    else
                //    {
                //        Debug.Log("GameOver");
                //        scoreManager.HighScoreUpdate();
                //        gameOverPanel[0].SetActive(true);
                //        gameOverPanel[1].SetActive(false);
                //    }

                //}
            
                    Debug.Log("GameOver");
                    scoreManager.HighScoreUpdate();
                    gameOverPanel[0].SetActive(true);
                    gameOverPanel[1].SetActive(false);
                
               
            }
        }

    }


    /// <summary>
    /// Belirlenen Süre içinde Kontrol Eder ve ona göre yeni spawn oluþur.
    /// </summary>
    void Control()
    {
      
        for (int i = 0; i < wayPointList.Count; i++)
        {

            if (wayPointList[i].GetComponent<NumberControl>().isNumber == true)
            {
                wayPointList.Remove(wayPointList[i]);

            }
        }
    }

}
