using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public Rigidbody2D rb2d;
    public float moveForce;
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
    /// </summary>
	void Update ()
    {
        TruckHorizontalMovement();
        TruckJump();
        FacingDirection();
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
    /// Deals with horizontal movement of the truck
    /// Implemented a maxspeed within the if construct
    /// </summary>
    void TruckHorizontalMovement ()
    {
        bool movementRight = Input.GetKey(KeyCode.RightArrow);
        bool movementLeft = Input.GetKey(KeyCode.LeftArrow);

        if (movementRight && (Mathf.Abs(rb2d.velocity.x) <= maxSpeed))
        {
            rb2d.AddForce(Vector2.right * moveForce);
        }

        else if (movementLeft && (Mathf.Abs(rb2d.velocity.x) <= maxSpeed))
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
            rb2d.transform.localScale = new Vector3(-1.5f, 1.5f, 1);
        }

        if (movementLeft)
        {
            rb2d.transform.localScale = new Vector3(1.5f, 1.5f, 1);
        }
    }

    /// <summary>
    /// Deals with implementing jumping. If the truck is not grounded do not allow the truck to jump.
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
