﻿using UnityEngine;
using System.Collections;

public class ObjectFollow : MonoBehaviour {
	public GameObject target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = target.transform.position;
		//transform.Rotate(new Vector3(0,0,target.transform.rotation.z - transform.rotation.z));
	}
}
