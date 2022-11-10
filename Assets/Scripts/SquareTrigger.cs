using UnityEngine;

public class SquareTrigger : MonoBehaviour
{
    private Move squareMove;
    private Rigidbody2D squareRigidbody2D;
    
    private void Awake()
    {
        squareMove = GetComponent<Move>();
        squareRigidbody2D = GetComponent<Rigidbody2D>();
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        WallControl(collision);

    }

    /// <summary>
    /// Duvarlarý kontrol eder ve kare sýnýr dýþýna çýkmaz.
    /// </summary>
    /// <param name="collision"></param>
    private void WallControl(Collider2D collision)
    {
        if (collision.gameObject.tag == "WallRight")
        {
            squareRigidbody2D.velocity = Vector2.zero;
            squareMove.isLeft = true;
            squareMove.isRight = false;
          

        }

        else if (collision.gameObject.tag == "WallLeft")
        {

            squareRigidbody2D.velocity = Vector2.zero;
            squareMove.isLeft = false;
            squareMove.isRight = true;
           

        }
        if (collision.gameObject.tag == "WallUp")
        {
            squareRigidbody2D.velocity = Vector2.zero;
            squareMove.isUp = false;
            squareMove.isDown = true;
           
        }

        else if (collision.gameObject.tag == "WallDown")
        {

            squareRigidbody2D.velocity = Vector2.zero;
            squareMove.isDown = false;
            squareMove.isUp = true;
          

        }
    }

}
