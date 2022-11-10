using UnityEngine;

public class Move : MonoBehaviour
{

   private Rigidbody2D squareRb;
   [SerializeField] int speed;
    private bool _isRight = true;
    private bool _isLeft = true;
    private bool _isUp = true;
    private bool _isDown = true;
    public bool isLeft { set { _isLeft = value; } }
    public bool isRight{  set{_isRight = value;}}

    public bool isUp { set { _isUp = value; } }
    public bool isDown { set { _isDown = value; } }

    void Start()
    {
        squareRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveSquare();
    }

    /// <summary>
    /// Yön kontrolü yapar hareketsiz ise hareket eder.
    /// </summary>
    private void MoveSquare()
    {
   
   
        float inputSpeed = 1f * speed;

        if (Input.GetKeyDown(KeyCode.D)&& squareRb.velocity.y == 0 && _isRight == true)
        {

          MatchOpen();
            squareRb.velocity = Vector2.right * inputSpeed;
            _isLeft = false;
            
          
        }

        else if (Input.GetKeyDown(KeyCode.A) && squareRb.velocity.y == 0 && _isLeft == true )
        {

          MatchOpen();
            squareRb.velocity = Vector2.left * inputSpeed;
            _isRight = false;
          

        }

        if (Input.GetKeyDown(KeyCode.W) && squareRb.velocity.x == 0 && _isUp == true )
        {
           MatchOpen();
            squareRb.velocity = Vector2.up * inputSpeed;
            _isDown = false;
           

        }
        else if (Input.GetKeyDown(KeyCode.S) && squareRb.velocity.x == 0 &&_isDown==true )
        {
           MatchOpen();
            squareRb.velocity = Vector2.down * inputSpeed;
            _isUp = false;
         


        }

    }

    /// <summary>
    /// Kare Durduðu zaman eþleþmesi kapanmaktadýr.Method Sayesinde tekrar açýlýr.
    /// </summary>
   void MatchOpen()
   {
       SquarePow[] squarePows = FindObjectsOfType<SquarePow>();
       for (int i = 0; i < squarePows.Length; i++)
       {
           squarePows[i].match = true;
       }
   }


  

}
