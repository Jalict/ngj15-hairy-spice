using UnityEngine;
using System.Collections;

public class PlayerSelect : MonoBehaviour {
	public int xboxController;
	public bool isReady;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () { 
		if(Input.GetButton("A_" + xboxController)) {
			renderer.material.color = Color.red;
			isReady = true;
		} else {
			renderer.material.color = Color.white;
			isReady = false;
		}
	}
}
