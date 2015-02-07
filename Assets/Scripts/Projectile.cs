using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public float power;
	public float radius;
	public float upMod;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Boxes"){
			Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
			foreach (Collider hit in colliders) {
				if (hit && hit.rigidbody)
					hit.rigidbody.AddExplosionForce(power, transform.position, radius, upMod);
				
			}

			Destroy(this.gameObject);
		}

	}
}
