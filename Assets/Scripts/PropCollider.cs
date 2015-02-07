using UnityEngine;
using System.Collections;

public class PropCollider : MonoBehaviour {
	public bool isLarge = false;
	public float stamp;
	public int playerHit = 0;
	public GameObject sibling;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isLarge && Time.time > stamp + 0.5f){
			if (rigidbody.velocity.magnitude == 0){
				sibling.gameObject.collider.isTrigger = true;
				isLarge = false;
				playerHit = 0;
			}
		}
	}
	public void SetPlayer(int player){
		if (playerHit == 0){
			playerHit = player;
		}
	}
}
