using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public int xboxController;

	CharacterController controller;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		// Check for left, right movement
		float x = Input.GetAxis ("L_XAxis_" + (xboxController + 1)) * 80;

		controller.SimpleMove(new Vector3 (x , 0, 0) * Time.deltaTime);

		// Jumping
		if(Input.GetButton("A_"+ (xboxController+1))) {
			controller.SimpleMove(new Vector3 (0, 20, 0) * Time.deltaTime);
		}
	}
}
