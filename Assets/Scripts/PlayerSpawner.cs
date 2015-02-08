using UnityEngine;
using System.Collections;

public class PlayerSpawner : MonoBehaviour {
	public int player;
	// Use this for initialization
	void Start () {
		Spawn();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Spawn(){
		GameObject.Find("Player_"+player).GetComponent<Player>().health = 100;
		GameObject.Find("Player_"+player).transform.position = transform.position;

		GameObject.Find("HPBG"+(player+1)).GetComponent<UIProgressBar>().value = 1; 

	}
}
