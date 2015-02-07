using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int health;
	public int DmgTakeScale;


	void OnCollisionEnter(Collision collision){



		if(collision.gameObject.tag == "Enemy" && collision.relativeVelocity.magnitude > 0){

			health -= (int)(collision.relativeVelocity.magnitude * DmgTakeScale);

		}

	}

}
