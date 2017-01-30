using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public Rigidbody2D rb2d;
    public float speed;
    public float jumpHeight;

	/// <summary>
    /// 
    /// </summary>
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	/// <summary>
    /// 
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
    void TruckHorizontalMovement ()
    {
        bool movementRight = Input.GetKey(KeyCode.RightArrow);
        bool movementLeft = Input.GetKey(KeyCode.LeftArrow);

        if (movementRight)
        {
            rb2d.velocity = new Vector2(speed, 0);
        }

        else if (movementLeft)
        {
            rb2d.velocity = new Vector2(-speed, 0);
        }

        else
        {
            rb2d.velocity = Vector2.zero;
        }
    }

    /// <summary>
    /// 
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
    /// 
    /// </summary>
    void TruckJump ()
    {
        bool jump = Input.GetKey(KeyCode.UpArrow);

        if (jump)
        {
            rb2d.AddForce(Vector2.up * jumpHeight);
        }

    }
}
