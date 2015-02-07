using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	float[] playersY;
	GameObject[] players ;
	public float originalSize;
	// Use this for initialization
	void Start () {
		players = GameObject.FindGameObjectsWithTag("Player");
		playersY = new float[players.Length];
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < playersY.Length; i++){
			playersY[i] = players[i].transform.position.y;
		}
		float maxDistY = 0;
		float maxY = playersY[0];
		float minY = playersY[0];
		for (int i = 0; i < playersY.Length -1; i++){
			for (int j = 0; j < playersY.Length; j++){
				if (Mathf.Abs(playersY[i] - playersY[j]) > maxDistY){
					maxDistY = Mathf.Abs(playersY[i] - playersY[j]);
				}
			} 
		}
		for (int i = 0; i < playersY.Length; i++){
			if (playersY[i] > maxY){
				maxY = playersY[i];
			}
			if (playersY[i] < minY){
				minY = playersY[i];
			}
		}
		if (maxDistY > originalSize * 2){
			GetComponent<Camera>().orthographicSize = 3 + (maxDistY / 2);
		}
		transform.position = new Vector3 (transform.position.x, (minY + maxY) / 2, -10);
	    
	}
}
