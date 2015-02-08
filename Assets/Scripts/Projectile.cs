using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public float power;
	public float radius;
	public float upMod;
	public int playerFired;
    public AudioClip[] shootSound = new AudioClip[6];

	// Use this for initialization
	void Start () {
        GetComponent<AudioSource>().clip = shootSound[(int)(Random.value * shootSound.Length)];
        GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Wall"){
			if (other.gameObject.tag == "Enemy"){
				other.rigidbody.AddForce(new Vector3(transform.position.x - other.transform.position.x, transform.position.y - other.transform.position.y, 0) * power);
			}
			Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
			foreach (Collider hit in colliders) {
				if (hit && hit.rigidbody && hit.gameObject.tag == "Enemy" && hit != other.gameObject){
					hit.rigidbody.AddExplosionForce(power, transform.position, radius, upMod);
					hit.GetComponent<PropCollider>().sibling.collider.isTrigger = false;
				hit.GetComponent<PropCollider>().isLarge = true;
					hit.GetComponent<PropCollider>().stamp = Time.time;
					hit.GetComponent<PropCollider>().SetPlayer(playerFired);
					}
				
			}

			Destroy(this.gameObject);
		}


	}
}
