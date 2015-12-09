using UnityEngine;
using System.Collections;

public class HeavyBolter : MonoBehaviour {

	Vector3 screenBoxTopRight ;
	Vector3 screenBoxBottomLeft;
	public float offScreenRange = 1;

	void Start () {
		float distance = this.transform.position.z - Camera.main.transform.position.z;
		screenBoxTopRight = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, distance));
		screenBoxBottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));

	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.left * 0.75f * Time.deltaTime;
			
		if ((transform.position.x < screenBoxBottomLeft.x - offScreenRange) || 
		    (transform.position.x > screenBoxTopRight.x + offScreenRange) ||
		    (transform.position.y < screenBoxBottomLeft.y - offScreenRange) ||
		    (transform.position.y > screenBoxTopRight.y + offScreenRange)) {
			Destroy(gameObject);
		}
	}
}
