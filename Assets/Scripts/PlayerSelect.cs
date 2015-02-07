using UnityEngine;
using System.Collections;

public class PlayerSelect : MonoBehaviour {
	public int xboxController;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () { 
		if(Input.GetButton("A_" + (xboxController+1))) {
			renderer.material.color = Color.red;
		} else {
			renderer.material.color = Color.white;
		}
	}
}
