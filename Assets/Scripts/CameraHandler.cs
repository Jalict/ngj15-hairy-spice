using UnityEngine;
using System.Collections;

public class CameraHandler : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        CameraFocus(players);

	}

    private IEnumerable ScreenShake(bool isShaking) {
        //TODO Make things shake

        yield return new WaitForEndOfFrame();
    }

    private void CameraFocus(GameObject[] players)
    {
        Vector3 average = Vector3.zero;

        float dist = 0;

        foreach (GameObject p in players)
        {
            average += p.transform.position;
            foreach (GameObject p2 in players)
            {
                if (!p.Equals(p2))
                {
                    if (Vector3.Distance(p.transform.position, p2.transform.position) > dist)
                        dist = Vector3.Distance(p.transform.position, p2.transform.position);
                }
            }
        }
        average /= players.Length;
        average.z -= (((dist + 10)*3) - average.z) * 0.125f;
        average.z += easeInOutExpo(average.z, -dist+4, 0.05f, 10);
        //average.z = Mathf.Lerp(average.z, dist - 40, 0.5f);

        transform.position = average;
        //transform.position = Vector3.Lerp(transform.position, average + (Vector3.one + Vector3.up) * 8, 0.2f);
        //transform.LookAt(transform.position - (Vector3.one + Vector3.up));

        //camera.fieldOfView = dist + 20;
    }

    float easeInOutExpo(float t,float b,float c,float d) {
	    t /= d/2;
	    if (t < 1) return c/2 * Mathf.Pow( 2, 10 * (t - 1) ) + b;
	    t--;
	    return c/2 * ( -Mathf.Pow( 2, -10 * t) + 2 ) + b;
    }
}
