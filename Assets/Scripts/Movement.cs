using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
 
    public Rigidbody2D rb2d;
    public Transform frontWheel;
    public Transform backWheel;
    public float zRotation;
    public float moveForce;
    public float maxSpeed;
    public float jumpForce;
    public bool grounded;
    public int groundMask = 1 << 9; // 0000000001 << 2 = 0000000100
    public float rayCastDistance;

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
        MovementInZ();
	}

    /// <summary>
    /// Casts two rays from the center of the wheels to the floor
    /// If either hit is not equal to null the truck is grounded
    /// </summary>
    void FixedUpdate()
    {
        RaycastHit2D hitFront;
        RaycastHit2D hitBack;

        Debug.DrawRay(frontWheel.position, Vector3.down * rayCastDistance, Color.red);
        Debug.DrawRay(backWheel.position, Vector3.down * rayCastDistance, Color.red);

        hitFront = Physics2D.Raycast(frontWheel.position, Vector2.down, rayCastDistance, groundMask);
        hitBack = Physics2D.Raycast(backWheel.position, Vector2.down, rayCastDistance, groundMask);

        grounded = hitFront.collider != null || hitBack.collider != null; //something wrong here
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
            rb2d.transform.localScale = new Vector3(-.65f, .65f, 1);
        }

        if (movementLeft)
        {
            rb2d.transform.localScale = new Vector3(.65f, .65f, 1);
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

    /// <summary>
    /// Allows the Truck to rotate along the Z Axis
    /// </summary>
    void MovementInZ()
    {
        bool rotateRight = Input.GetKey(KeyCode.D);
        bool rotateLeft = Input.GetKey(KeyCode.A);

        if(rotateRight)
        {
            transform.Rotate(new Vector3(0, 0, zRotation), Space.World);
        }

        if(rotateLeft)
        {
            transform.Rotate(new Vector3(0, 0, -zRotation), Space.World);
        }
    }
}
