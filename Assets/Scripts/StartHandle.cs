using UnityEngine;
using System.Collections;

public class StartHandle : MonoBehaviour {
	float timestamp;
	int playersReady;

	// Use this for initialization
	void Start () {
		timestamp = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");

		playersReady = 0;

		for(int i = 0; i < players.Length;i++) {
			if(players[i].GetComponent<PlayerSelect>().isReady) {
				playersReady++;
			}
		}

		bool isTwoPlayersReady = playersReady >= 2;

		if (Input.GetButtonDown("X_1") && isTwoPlayersReady) {
			timestamp = Time.realtimeSinceStartup;

			//if(isTwoPlayersReady) {
				Application.LoadLevel("Frans-main");
			//}
		}

	}

	void OnGUI() {
		GUI.Label (new Rect (10, 10, 100, 30), (20 - timestamp)+"");
		GUI.Label (new Rect (10, 40, 30, 30), ""+playersReady);
	}
}
