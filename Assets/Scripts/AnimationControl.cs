using UnityEngine;
using System.Collections;

public class AnimationControl : MonoBehaviour {
	public GameObject parent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Animator>()){
		GetComponent<Animator>().SetFloat("Speed",Mathf.Abs (Input.GetAxis ("L_XAxis_" + (parent.GetComponent<Player>().xboxController+1))));
			GetComponent<Animator>().SetBool("Grounded",parent.GetComponent<CharacterController>().isGrounded);
		}
	}
}
