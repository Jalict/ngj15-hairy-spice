using UnityEngine;
using System.Collections;

public class PlayerSelection : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");

        int playersReady = 0;

		for(int i = 0; i < players.Length;i++) { // Check if they are pressing A to join
            if (Input.GetButton("A_" + (i+1)))
            {
                playersReady++;

                players[i].renderer.material.color = Color.red;
                players[i].GetComponent<Player>().isJoined = true;
            }
            else
            {
                players[i].renderer.material.color = Color.white;
                players[i].GetComponent<Player>().isJoined = false;
            }
		}

		if (Input.GetButtonDown("X_1") && playersReady >= 2) // Check if two players are ready and starts the game
        {
            foreach (GameObject g in players)
            {
                if (g.GetComponent<Player>().isJoined)
                {
                    Debug.Log(g.name + " joined the game");
                    g.GetComponent<Player>().isJoined = true;
                    g.GetComponent<Player>().enabled = true;
                    DontDestroyOnLoad(g);
                }
                else
                {
                    Destroy(g);
                }
                
            }

            Application.LoadLevel(1);
		}

	}
}
