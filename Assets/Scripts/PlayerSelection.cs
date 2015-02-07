using UnityEngine;
using System.Collections;

public class PlayerSelection : MonoBehaviour {
	int playersReady = 0;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {


		
        

		for(int i = 0; i < 4;i++) { // Check if they are pressing A to join
            if (Input.GetButtonDown("A_" + (i+1)))
			{
				if (GameObject.Find ("Player_" + i).GetComponent<Player>().isJoined == false){

				playersReady++;
				GameObject.Find ("Player_" + i).GetComponent<Player>().isJoined = true;
				//GameObject.Find ("Player_" + i).renderer.material.color = Color.red;
				}
				else
				{
					GameObject.Find ("Player_" + i).GetComponent<Player>().isJoined = false;
					//GameObject.Find ("Player_" + i).renderer.material.color = Color.white;
					playersReady--;
				}
			}
			
		}
		
		if (Input.GetButtonDown("X_1") && playersReady >= 2) // Check if two players are ready and starts the game
        {
			GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
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
