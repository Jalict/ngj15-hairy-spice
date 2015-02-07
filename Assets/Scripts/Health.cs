using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int health = 100;
	public int DmgTakeScale = 1;


	void OnCollisionEnter(Collision collision){

		print("Collision!");

		if(collision.gameObject.tag == "enemy" && collision.relativeVelocity.magnitude > 0){

			health -= (int)(collision.relativeVelocity.magnitude * DmgTakeScale);

		}

	}

}
