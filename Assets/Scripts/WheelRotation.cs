using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotation : MonoBehaviour {

    public Rigidbody2D rb2b;
    public Movement movement;
    public float rotation;

	/// <summary>
    /// Called on first frame
    /// </summary>
	void Start ()
    {
        rb2b = GetComponent<Rigidbody2D>();
	}
	
	/// <summary>
    /// Call method to rotate wheels
    /// </summary>
	void Update ()
    {
        Rotate();
	}

    /// <summary>
    /// Based on which truck way the truck is facing rotate the wheels in the approriapte directions around the Z axis
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
