using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {
	public GameObject projectile;
	public float projectileSpeed;
	public int xboxController;
	GameObject lastSpawn;
	public GameObject gunTarget;
	Vector3 originalPos;

	// Use this for initialization
	void Start () {
		originalPos = gunTarget.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Mathf.Abs(Input.GetAxis("R_XAxis_" + (xboxController+1))) > 0.5f || Mathf.Abs(Input.GetAxis("R_YAxis_" +( xboxController + 1))) > 0.5f){
		gunTarget.transform.localPosition = new Vector3(originalPos.x + Input.GetAxis("R_XAxis_" + (xboxController+1)) * 10 ,originalPos.y + Input.GetAxis("R_YAxis_" +( xboxController + 1)) * 10,0);
		}
		transform.LookAt(gunTarget.transform);
		if (Input.GetButtonDown("RB_"+ (xboxController+1))){
			lastSpawn = (GameObject) Instantiate(projectile, new Vector3(transform.position.x,transform.position.y,0),transform.localRotation);
			lastSpawn.GetComponent<Projectile>().playerFired = xboxController + 1;
			lastSpawn.rigidbody.AddForce(lastSpawn.transform.forward * projectileSpeed);
		}
	}
}
