using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Ball ball;
    public Networking networking;
    public Movement movement;
    public Text player1ScoreText;
    public Text player2ScoreText;
    public int player1Score = 0;
    public int player2Score = 0;

    /// <summary>
    /// If player one scores add a point to their score and increase the score; reset the game
    /// </summary>
    public void Player1Scores()
    {
        player1Score++;
        player1ScoreText.text = networking.playerOneScore + "";
        ResetAfterScore();
    }

    /// <summary>
    /// If player two scores add a point to their score and increase the score; reset the game
    /// </summary>
    public void Player2Scores()
    {
        player2Score++;
        player2ScoreText.text = networking.playerTwoScore + "";
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
