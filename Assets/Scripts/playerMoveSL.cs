using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMoveSL : MonoBehaviour
{
    public float jumpAmount;
    public float gravityScale;
    public float fallingGravityScale;
    public float moveSpeed;

    private float moveHorizontal;
    private float moveVertical;
    private bool isGrounded;
    private bool isClimbing;
    private bool isFacingRight;
    private Vector3 climbXPosition;
    private SpriteRenderer playerRenderer;

    private groundCheck playerGroundCheck;
    [SerializeField] GameObject groundCheck;
   
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerRenderer = GetComponent<SpriteRenderer>();

        //playerGroundCheck = groundCheck.GetComponent<groundCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        playerGroundCheck = groundCheck.GetComponent<groundCheck>();

        //Debug.Log("isGrounded is: " + playerGroundCheck.isGrounded);

        if (playerGroundCheck.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {

            rb.velocity = new Vector2(rb.velocity.x, jumpAmount);

        }

        if (rb.velocity.y >= 0 && !isClimbing)
        {
            rb.gravityScale = gravityScale;
            rb.drag = 0;

        }
        else if (rb.velocity.y < 0 && !isClimbing)
        {
            rb.gravityScale = fallingGravityScale;
            rb.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        //INPUT GETAXIS HORZONTAL DETERMINES WHETHER THE PLAYER IS MOVING LEFT (-1), RIGHT (+1) OR NOT MOVING (0)
        moveHorizontal = Input.GetAxis("Horizontal");
        //INPUT GETAXIS HORZONTAL DETERMINES WHETHER THE PLAYER IS MOVING DOWN (-1), UP (+1) OR NOT MOVING (0)
        moveVertical = Input.GetAxis("Vertical");


        if(moveHorizontal > .01f)
        {
            playerRenderer.flipX = false;
        }
        else if (moveHorizontal < -.01f)
        {
            playerRenderer.flipX = true;
        }

     
        //VELOCITY IS APPLIED TO THE RIGIDBODY ANYTIME THE HORIZONTAL INPUT CHANGES AND IT IS MULTIPLIED BY SPEED. Y VELOCITY NOT AFFECTED.
        rb.velocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y);

       

        if (isClimbing && Mathf.Abs(moveVertical) > 0f)
        {
            Debug.Log("Climbing");
            //SET THE GRAVITY SCALE TO ZERO SO THERE IS NO RESISTANCE
            rb.gravityScale = 0;
            rb.drag = 5;

            rb.transform.position = new Vector3(climbXPosition.x, rb.transform.position.y);

            //VELOCITY IS APPLIED TO THE RIGIDBODY IN THE VERTICAL DIRECTION
            rb.velocity = new Vector2(rb.velocity.x, moveVertical * moveSpeed);
        }
     
        

    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Ladder")
        {

            Debug.Log("In Ladder");
            isClimbing = true;
            climbXPosition = new Vector3(collision.transform.position.x, collision.transform.position.y);

        }

        /*if (collision.gameObject.tag == "Point")
        {
            Debug.Log("POINT!");

            //FIND THE GAME MANANGER SCRIPT IN THE SCENE AND TRIGGER THE INCRESESCORE FUNCTION ASSOCIATED WITH IT
            FindObjectOfType<GameManager>().IncreaseScore();

            //THEN DESTROY THE POINT OBJECT
            Destroy(collision.gameObject);
        } */
         if (collision.gameObject.tag == "Enemy")
        {

            FindObjectOfType<GameManager>().GameOver();

        }




        }

    void OnTriggerExit2D(Collider2D collision)
    {

        /*if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;

        }*/
        if (collision.gameObject.tag == "Ladder")
        {
            Debug.Log("Out Ladder");
            isClimbing = false;

        }

        if (collision.gameObject.tag == "Boundary")
        {

            FindObjectOfType<GameManager>().GameOver();

        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spikes")
        {
            FindObjectOfType<GameManager>().GameOver();
        }

       
        
    }
}
