using UnityEngine;
using System.Collections;

public class PlayerSpawner : MonoBehaviour {
	public int player;
	// Use this for initialization
	void Start () {
		GameObject.Find("Player_"+player).transform.position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
