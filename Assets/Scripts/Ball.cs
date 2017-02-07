using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Rigidbody2D rb2d;
    public GameManager manager;

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
		
	}

    /// <summary>
    /// 
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
}
