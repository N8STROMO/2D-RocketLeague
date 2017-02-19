using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Rigidbody2D rb2d;
    public GameManager manager;
    public float maxXVelocity;
    public float velocity;
    public float minimumXVelcoity;
	
    /// <summary>
    /// Called on first frame
    /// </summary>
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	/// <summary>
    /// TODO give the ball dynamic collisions where it is not just simply bouncing, but moving at an angle 
    /// based from the was the truck collides with the ball
    /// </summary>
	void Update ()
    {
        velocity = rb2d.velocity.x;
        CapBallmovement();
    }

    /// <summary>
    /// Deals with which goal is hit and awarding the proper player with a goal
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player1Goal"))
        {
            manager.Player2Scores();
        }

        if(collision.gameObject.CompareTag("Player2Goal"))
        {
            manager.Player1Scores();
        }

   }

    /// <summary>
    /// TODO Max velocity of ball
    /// </summary>
    void CapBallmovement()
    {
        float clampedSpeed = Mathf.Clamp(rb2d.velocity.x, minimumXVelcoity, maxXVelocity);

        rb2d.velocity = new Vector2(clampedSpeed, rb2d.velocity.y);
    }
}

