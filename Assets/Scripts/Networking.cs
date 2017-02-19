using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Networking : NetworkBehaviour {

    [SyncVar]
    public int playerOneScore, playerTwoScore;
	
    /// <summary>
    /// 
    /// </summary>
	void Start ()
    {
		if(isLocalPlayer)
        {
            GetComponent<Movement>().enabled = true;
        }
	}

    [Command]
    public void CmdSyncScore()
    {

    }
}
