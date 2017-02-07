using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotation : MonoBehaviour {

    public Rigidbody2D rb2b;
    public Movement movement;
    public float rotation;

	/// <summary>
    /// 
    /// </summary>
	void Start ()
    {
        rb2b = GetComponent<Rigidbody2D>();
	}
	
	/// <summary>
    /// 
    /// </summary>
	void Update ()
    {
        Rotate();
	}

    /// <summary>
    /// 
    /// </summary>
    void Rotate()
    {
        bool movementRight = Input.GetKey(KeyCode.RightArrow);
        bool movementLeft = Input.GetKey(KeyCode.LeftArrow);

        if (movementRight)
        {
            rb2b.transform.Rotate(new Vector3(0, 0, -rotation * movement.rb2d.velocity.x));
        }

        if (movementLeft)
        {
            rb2b.transform.Rotate(new Vector3(0, 0, rotation * movement.rb2d.velocity.x));
        }
    }
}
