using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {
	public GameObject projectile;
	public float projectileSpeed;
	public int xboxController;
	GameObject lastSpawn;
	public GameObject gunTarget;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs(Input.GetAxis("R_XAxis_" + (xboxController+1))) > 0.5f || Mathf.Abs(Input.GetAxis("R_YAxis_" +( xboxController + 1))) > 0.5f){
		gunTarget.transform.localPosition = new Vector3(Input.GetAxis("R_XAxis_" + (xboxController+1)) * 2,Input.GetAxis("R_YAxis_" +( xboxController + 1)) * 2,0);
		}
		transform.LookAt(gunTarget.transform);
		if (Input.GetButtonDown("RB_"+ (xboxController+1))){
			lastSpawn = (GameObject) Instantiate(projectile, transform.position, transform.localRotation);
			lastSpawn.rigidbody.AddForce(lastSpawn.transform.forward * projectileSpeed);
		}
	}
}
