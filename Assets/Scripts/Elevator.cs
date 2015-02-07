using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {
	public bool up;
	public int level;
	public float travel;
	public float waitTime;
	public float travelTime;
	public bool moving = false;
	public int maxLevel;
	int minLevel = 0;
	float startPos;
	float yPos;
	public float previousPos;
	public	float currentPos;
	// Use this for initialization
	void Start () {
		StartCoroutine(Elevate());
	}
	
	// Update is called once per frame
	void Update () {
		previousPos = currentPos;
		currentPos = transform.position.y;
		if (moving){
			if (up){
			yPos = Mathf.Lerp(transform.position.y,startPos + travel, travelTime * Time.deltaTime);
			}
			else{
				yPos = Mathf.Lerp(transform.position.y,startPos - travel, travelTime * Time.deltaTime);
			}
			transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
		}
	}
	IEnumerator Elevate(){
		yield return new WaitForSeconds(waitTime);
		if (up){
			if (level == maxLevel){
				up = false;
				level--;
			}
			else {
				level++;
			}
		}
		else{
			if (level == minLevel){
				up = true;
				level++;
			}
			else{
				level--;
			}
		}
		startPos = transform.position.y;
		moving = true;
		StartCoroutine(Elevate());
	}

}
