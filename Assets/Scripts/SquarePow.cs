using System.Collections.Generic;
using UnityEngine;

public class SquarePow : MonoBehaviour
{

    private Rigidbody2D speed;
    private bool _match = true;
    public bool match { get { return _match; } set { _match = value; } }
    private Move squareMove;
    public List<Color> Colors = new List<Color>();
    public int rank=0;
    private ScoreManager scoreManager;

    private void Awake()
    {
        speed = GetComponent<Rigidbody2D>();
        squareMove = GetComponent<Move>();
        scoreManager = FindObjectOfType<ScoreManager>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SquareCollision(collision);
    }


    /// <summary>
    /// Renk deðiþimi yapmaktadýr.
    /// </summary>
    /// <param name="i"></param>
    /// <param name="collision"></param>
   private void ChooseColor(int i,Collider2D collision)
    {
        collision.GetComponent<SquarePow>().rank += i;
        collision.gameObject.GetComponent<SpriteRenderer>().color = Colors[rank]; 
    }



    /// <summary>
    /// Karenin tagini deðiþtirir ve çarpan kareyi yok eder.
    /// </summary>
    /// <param name="collision"></param>
    /// <param name="match"></param>
    private void SquareTagUpdate(Collider2D collision,bool match)
    {
        int squareTagNumber = int.Parse(gameObject.tag.Substring(6));
        int plusSquare = 2 * squareTagNumber;
        scoreManager.ScoreUpdate(plusSquare);

       
        //Eski Eleman Yok Edilir.
        Destroy(gameObject);
        //Yeni oluþan elemanýn tagi
        collision.tag = "Square" + plusSquare;
        ChooseColor(1,collision);

        //sayýlar her basýldýðýnda bi kere eþleþmesi gerkir.
        collision.GetComponent<SquarePow>().match = match;
    }


    /// <summary>
    /// Y konumu için bir kere eþleþme saðlar sað ve sol ayrýlmasý gerekir.
    /// </summary>
    /// <param name="pos"></param>
    public void SquarePositionYAxis(float pos,Collider2D collision)
    {
        float y = collision.transform.position.y + pos;
        transform.position = new Vector2(transform.position.x, y);
    }


    /// <summary>
    /// X konumu için bir kere eþleþme saðlar sað ve sol ayrýlmasý gerekir.
    /// </summary>
    /// <param name="pos"></param>
   public void SquarePositionXAxis(float pos, Collider2D collision)
    {
        float x = collision.transform.position.x +pos;
        transform.position = new Vector2(x, transform.position.y);

    }


    /// <summary>
    /// Sayýlarýn çarpýþmasýný kontrol eder.
    /// </summary>
    /// <param name="collision"></param>
    void SquareCollision(Collider2D collision)
    {
        if (gameObject.tag == collision.gameObject.tag)
        {
       
            if (match == true)
            {
                if (speed.velocity.x > 0)
                {
                    SquareTagUpdate(collision, false);
               
                }
                else if (speed.velocity.x < 0)
                {
                    SquareTagUpdate(collision, false);
                  
                }

                if (speed.velocity.y > 0)
                {
                    SquareTagUpdate(collision, false);
                 

                }
                else if (speed.velocity.y < 0)
                {
                    SquareTagUpdate(collision, false);
             
                }
            }


            else
            {

                if (speed.velocity.x > 0)
                {
                    speed.velocity = Vector2.zero;
                    SquarePositionXAxis(-1f, collision);
                    collision.GetComponent<SquarePow>().match = true;
                   
                 
                }
                else if (speed.velocity.x < 0)
                {
                    speed.velocity = Vector2.zero;
                    SquarePositionXAxis(1f, collision);
                    collision.GetComponent<SquarePow>().match = true;
                    
                }

                if (speed.velocity.y > 0)
                {
                    speed.velocity = Vector2.zero;
                    SquarePositionYAxis(-1f, collision);
                    collision.GetComponent<SquarePow>().match = true;
                    
                }
                if (speed.velocity.y < 0)
                {
                    speed.velocity = Vector2.zero;
                    SquarePositionYAxis(1f, collision);
                    collision.GetComponent<SquarePow>().match = true;
                    
                }


            }


        }
        else if (gameObject.tag != collision.gameObject.tag && collision.gameObject.tag.Substring(0, 4) != "Wall" && collision.gameObject.tag != "field")
        {
        
            
            if (speed.velocity.x > 0)
            {
                speed.velocity = Vector2.zero;
                SquarePositionXAxis(-1f, collision);
                squareMove.isLeft = true;
                
            }
             else  if (speed.velocity.x < 0)
            {
                speed.velocity = Vector2.zero;
                SquarePositionXAxis(1f, collision);
                squareMove.isRight = true;
              
            }
            if (speed.velocity.y > 0)
            {
                speed.velocity = Vector2.zero;
                SquarePositionYAxis(-1f, collision);
                squareMove.isDown = true;
              
            }
            else if (speed.velocity.y < 0)
            {
                speed.velocity = Vector2.zero;
                SquarePositionYAxis(1f, collision);
                squareMove.isUp = true;
              
             
            }

        }

    }

}

