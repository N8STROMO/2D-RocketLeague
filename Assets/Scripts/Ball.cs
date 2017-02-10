using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Rigidbody2D rb2d;
    public GameManager manager;
    public float maxVelocity;
    public float velocity;
    public float moveForce;
	
    /// <summary>
    /// Called on first frame
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
        velocity = rb2d.velocity.x;
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
    /// Max velocity of ball
    /// </summary>
    void CapBallMovement ()
    {
        if //collision from left side of ball && (rb2d.velocity.x) <= Mathf.Abs(maxVelocity))
        {
            rb2d.AddForce(Vector2.right * moveForce);
        }

        if //collision from right side of ball && (rb2d.velocity.x) <= Mathf.Abos(maxVelocity))
        {
            rb2d.AddForce(Vector2.left * moveForce);
        }
    }
}

