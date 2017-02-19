using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Networking : NetworkBehaviour {
    GameManager manager;
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

}
