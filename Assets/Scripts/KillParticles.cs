using UnityEngine;
using System.Collections;

public class KillParticles : MonoBehaviour {
    ParticleSystem p;

	// Use this for initialization
	void Start () {
        p = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (p.time > 2)
        {
            Destroy(this.gameObject);
        }
	}
}
