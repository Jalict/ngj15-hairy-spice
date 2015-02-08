using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public int xboxController;
	public float jumpSpeed;
	public float gravity;
	public float movementSpeed;
	public int health;
	public int maxHealth;
	public float DmgTakeScale;
	public bool isDead;
    public bool isJoined;
	public Vector3 movement;
	GameObject lastHitBy;
	public GameObject sprite;
	public int scaleFactor;
    public GameObject splat;

	CharacterController controller;

	// Use this for initialization 
	void Start () {
		controller = GetComponent<CharacterController> ();

	
	}

	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs (Input.GetAxis("L_XAxis_" + (xboxController + 1))) > 0.6f){
			sprite.transform.localScale = new Vector3((-Input.GetAxis("L_XAxis_" + (xboxController+1)) / Mathf.Abs(Input.GetAxis("L_XAxis_" + (xboxController+1)))) * 2 * scaleFactor,sprite.transform.localScale.y,sprite.transform.localScale.z);
		}

		if (!controller.isGrounded){
			movement.y -= gravity * Time.deltaTime; 
		}

		// Jumping
		if(Input.GetButtonDown("A_"+ (xboxController+1)) && controller.isGrounded) {
			movement.y = jumpSpeed;
		}

		// Check for left, right movement

		movement.x = Input.GetAxis ("L_XAxis_" + (xboxController + 1)) * movementSpeed;

		controller.Move(movement * Time.deltaTime);

		// Check death, respawn
		//if (isDead) {
			// Get list of respawn positions for player spawning
			// TODO: Make sure that the respawn positions haven't just been used
			//GameObject[] respawnPositions = GameObject.FindGameObjectsWithTag("Respawn");

			// Just choose a random one (Bad lol)
			//transform.position = respawnPositions[Random.Range(0,respawnPositions.Length)].transform.position;

			//isDead = false;
		transform.position = new Vector3(transform.position.x, transform.position.y, -2);
		if (health <= 0){
			GameObject.Find("GameController").GetComponent<GameControl>().isDead[xboxController] = true;
			isDead = true;
			gameObject.SetActive(false);
			GameObject.Find ("GameController").GetComponent<GameControl>().CheckDead();
		}
		
	}

	public void Kill() {
		isDead = true;
        
	}
	void OnControllerColliderHit(ControllerColliderHit collision){
		
		if (collision.gameObject.tag == "Enemy"){
		
		GameObject hitby = collision.gameObject.GetComponent<ObjectFollow>().target;
		if(hitby.rigidbody.velocity.magnitude > 0 && collision.gameObject != lastHitBy && hitby.GetComponent<PropCollider>().playerHit != xboxController+1){
			print("colissioN!");
			lastHitBy = collision.gameObject;
				health -= (int)(hitby.gameObject.rigidbody.velocity.magnitude * DmgTakeScale);
				print("Damage taken: " + hitby.gameObject.rigidbody.velocity.magnitude * DmgTakeScale);
			print((float) (health / maxHealth));
			GameObject.Find ("HPBAR" + (xboxController+1)).GetComponent<UIProgressBar>().value =  ((float)health / (float)maxHealth);
            Instantiate(splat, transform.position, Quaternion.identity);
		}
		}
		if (collision.gameObject.tag == "Hole"){
			transform.position = GameObject.Find("PlayerSpawn" + xboxController).transform.position;
		}
		
	}
}
