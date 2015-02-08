using UnityEngine;
using System.Collections;

public class ProjectileAnimator : MonoBehaviour {
	public Sprite[] animation = new Sprite[13];
	SpriteRenderer anim;
	public int fps;
	// Use this for initialization
	void Start () {
		anim = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

		anim.sprite = animation [ (int) ((fps * Time.time) % animation.Length)];
	}
}
