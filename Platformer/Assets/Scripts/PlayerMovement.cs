using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //variables for the game
    float speed;        //determine move speed
    float move;         //determine direction of movement

    float jump;         //determine how high the jump is
    bool isJumping;     //tracks if object is jumping or not

    Rigidbody2D rb;

    public static PlayerMovement instance;

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //  public Transform startPos

    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;                //set speed value to ten
        jump = 400f;                //set jump value to 400f

        rb = GetComponent<Rigidbody2D>();       //store the rb of the object
    }

    // Update is called once per frame
    void Update()
    {
        //move the player
        move = Input.GetAxis("Horizontal");         //set move to read any of the unity Horizontal keybinds

        rb.velocity = new Vector2(speed * move, rb.velocity.y);         //move on the x axis (left or right)

        //single jump limit
        if (Input.GetButtonDown("Jump") && !isJumping)              //when the unity jump keybind is pressed and if the object is not already
        {
            rb.AddForce (new Vector2(rb.velocity.x, jump));         //jump
            isJumping = true;       //set jumping to true
        }
    }

    //Called when a Collision is detected
   void OnCollisionEnter2D(Collision2D other)
   {
        if (other.gameObject.CompareTag("Ground"))          //if the other object is tag as ground
        {
            isJumping = false;          //set jumping to false
        }
   }
}