using UnityEngine;
using System.Collections;

public class ElevatorFollow : MonoBehaviour {
	public GameObject elevator;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player" || other.tag == "Enemy"){

			other.transform.parent = this.transform;
			}
		}
	void OnTriggerExit(Collider other){
		if (other.tag == "Player" || other.tag == "Enemy"){
			
			other.transform.parent = null;
		}
	}
	}


