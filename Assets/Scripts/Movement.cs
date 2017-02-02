using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public Rigidbody2D rb2d;
    public float moveForce;
    public float speed;
    public float maxSpeed;
    public float jumpForce;
    public bool grounded;


	/// <summary>
    /// Called on first frame
    /// </summary>
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	/// <summary>
    /// Calls methods to deal with truck movement, jumping, and facing direction
    /// TODO Clamp the velocity of the truck to maxSpeed
    /// </summary>
	void Update ()
    {
        Mathf.Clamp(rb2d.velocity.x, 0, maxSpeed);
        TruckHorizontalMovement();
        TruckJump();
        FacingDirection();
        speed = rb2d.velocity.x; //This is to check if the speed is being clamped
	}

    /// <summary>
    /// Checks if the Truck has collided with the ground and changes grounded to true
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }

    }

    /// <summary>
    /// TODO Need to know if the truck is not grounded 
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit2D(Collision2D collision)
    {

    }

    /// <summary>
    /// Deals with horizontal movement of the truck
    /// </summary>
    void TruckHorizontalMovement ()
    {
        bool movementRight = Input.GetKey(KeyCode.RightArrow);
        bool movementLeft = Input.GetKey(KeyCode.LeftArrow);

        if (movementRight)
        {
            rb2d.AddForce(Vector2.right * moveForce);
        }

        else if (movementLeft)
        {
            rb2d.AddForce(Vector2.left * moveForce);
        }

        else
        {
            rb2d.AddForce(Vector2.zero);
        }
    }

    /// <summary>
    /// Changes the direction the truck faces based on the direction the truck is traveling
    /// </summary>
    void FacingDirection()
    {
        bool movementRight = Input.GetKey(KeyCode.RightArrow);
        bool movementLeft = Input.GetKey(KeyCode.LeftArrow);

        if (movementRight)
        {
            rb2d.transform.localScale = new Vector3(1, 1, 1);
        }

        if (movementLeft)
        {
            rb2d.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    /// <summary>
    /// Deals with implementing jumping. If the truck is not grounded do not allow the truck to jump.
    /// See OnCollisionExit2D
    /// </summary>
    void TruckJump ()
    {
        bool jump = Input.GetKey(KeyCode.UpArrow);

        if (jump && grounded == true)
        {
            rb2d.AddForce(Vector2.up * jumpForce);
            grounded = false;
        }

    }
}
