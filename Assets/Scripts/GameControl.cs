using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour
{
	public GameObject[] players;
		public bool[] isDead = new bool[4];
		int activePlayers = 0;

		// Use this for initialization
		void Start ()
		{
		players = GameObject.FindGameObjectsWithTag("Player");
				for (int i = 0; i < isDead.Length; i++) {
						if (GameObject.Find ("Player_" + i)) {
								isDead [i] = false;
								activePlayers++;
						} else {
								isDead [i] = true;
								GameObject.Find ("HPBG" + i + 1).transform.parent.gameObject.SetActive (false);
						}
				}

		}
	
		// Update is called once per frame
		void Update ()
		{

				
			
		}
	
		void CheckDead ()
		{
				int deadCount = 0;
				for (int i = 0; i < isDead.Length; i++) {
						if (isDead [i]) {
								deadCount++;
						}
				}
				if (deadCount >= activePlayers - 1) {
			for (int i = 0; i < isDead.Length; i++){
			StartCoroutine(AnnounceWinner())
			}
				}
		}

		public IEnumerator AnnounceWinner (int winner)
		{
		yield return new WaitForSeconds(3);

		for (int i = 0; i < players.Length; i++){
			players[i].SetActive(true);
			GameObject.Find ("PlayerSpawn" + i).GetComponent<PlayerSpawner>().Spawn();
			yield return new WaitForSeconds(0.5f);
			}
		}

}