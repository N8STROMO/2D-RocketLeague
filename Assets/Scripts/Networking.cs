using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Networking : NetworkBehaviour {

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
	
	/// <summary>
    /// 
    /// </summary>
	void Update () {
		
	}
}
