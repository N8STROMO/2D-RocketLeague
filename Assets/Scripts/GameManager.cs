using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour {

    public Ball ball;
    public Movement movement;
    public Text player1ScoreText;
    public Text player2ScoreText;
    [SyncVar]
    public int player1Score = 0, player2Score = 0;

    /// <summary>
    /// If player one scores add a point to their score and increase the score; reset the game
    /// </summary>
    [Command]
    public void CmdPlayer1Scores()
    {
        player1Score++;
        player1ScoreText.text = player1Score + "";
        CmdResetAfterScore();
    }

    /// <summary>
    /// If player two scores add a point to their score and increase the score; reset the game
    /// </summary>
    [Command]
    public void CmdPlayer2Scores()
    {
        player2Score++;
        player2ScoreText.text = player2Score + "";
        CmdResetAfterScore();
    }

    /// <summary>
    /// TODO: Reset Networked Trucks to appropriate positions on scoring 
    /// </summary>
    [Command]
    void CmdResetAfterScore()
    {
        ball.gameObject.transform.position = new Vector3(0, -4.4f, 0);
        ball.rb2d.velocity = new Vector3(0, 0, 0);
    }


    void Update() {
        player1ScoreText.text = player1Score + "";
        player2ScoreText.text = player2Score + "";
    }

}
