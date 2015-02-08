using UnityEngine;
using System.Collections;

public class PulseLight : MonoBehaviour {
    float n;

	// Use this for initialization
	void Start () {
        n = 0;
	}
	
	// Update is called once per frame
	void Update () {
        n += .3f;
        //GetComponent<Light>().intensity = (Mathf.Sin(n)*1.5f)+4;
        GetComponent<Light>().range = (Mathf.Cos(n) * 0.5f) + 3;
	}
}
