using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Ball ball;
    public Movement movement;
    public Text player1ScoreText;
    public Text player2ScoreText;
    private int player1Score = 0;
    private int player2Score = 0;

    /// <summary>
    /// 
    /// </summary>
	void Start()
    {
		
	}
	
	/// <summary>
    /// 
    /// </summary>
	void Update()
    {
		
	}

    /// <summary>
    /// If player one scores add a point to their score and increase the score; reset the game
    /// </summary>
    public void Player1Scores()
    {
        player1Score++;
        player1ScoreText.text = player1Score + "";
        ResetAfterScore();
    }

    /// <summary>
    /// If player two scores add a point to their score and increase the score; reset the game
    /// </summary>
    public void Player2Scores()
    {
        player2Score++;
        player2ScoreText.text = player2Score + "";
        ResetAfterScore();
    }

    /// <summary>
    /// TODO: Reset Networked Trucks to appropriate positions on scoring 
    /// </summary>
    void ResetAfterScore()
    {
        ball.gameObject.transform.position = new Vector3(0, -4.4f, 0);
        ball.rb2d.velocity = new Vector3(0, 0, 0);
    }
}
