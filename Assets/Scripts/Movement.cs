using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    //TODO allow for movement around the Z axis mid air to be able to hit the ball at different angles 

    public Rigidbody2D rb2d;
    public float moveForce;
    public float maxSpeed;
    public float jumpForce;
    public bool grounded;
    public int groundMask = 1 << 9; // 0000000001 << 2 = 0000000100
    public float rayCastDistance;

    public Transform wheel1;
    public Transform wheel2;


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
    /// 
    /// </summary>
    void FixedUpdate()
    {
        RaycastHit2D hit;
        Debug.DrawRay(transform.position, Vector3.down * rayCastDistance, Color.red);
        hit = Physics2D.Raycast(transform.position, Vector2.down, rayCastDistance, groundMask);
        grounded = hit.collider != null;
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
