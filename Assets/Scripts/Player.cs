using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public int xboxController;
	public float jumpSpeed;
	public float gravity;
	public float movementSpeed;

	bool isDead;
	public Vector3 movement;

	CharacterController controller;


	// Use this for initialization 
	void Start () {
		controller = GetComponent<CharacterController> ();

		isDead = true;
	}
	
	// Update is called once per frame
	void Update () {
		movement.y -= gravity * Time.deltaTime; 

		// Jumping
		if(Input.GetButtonDown("A_"+ (xboxController+1))) {
			movement.y = jumpSpeed;

		}

		// Check for left, right movement
		movement.x = Input.GetAxis ("L_XAxis_" + (xboxController + 1)) * movementSpeed;
		
		controller.Move(movement * Time.deltaTime);

		// Check death, respawn
		if (isDead) {
			// Get list of respawn positions for player spawning
			// TODO: Make sure that the respawn positions haven't just been used
			GameObject[] respawnPositions = GameObject.FindGameObjectsWithTag("Respawn");

			// Just choose a random one (Bad lol)
			transform.position = respawnPositions[Random.Range(0,respawnPositions.Length)].transform.position;

			isDead = false;
		}


	}

	public void Kill() {
		isDead = true;
	}
}
