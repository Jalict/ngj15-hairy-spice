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

		GameObject.Find("Player_"+player).transform.position = transform.position;

	}
}
