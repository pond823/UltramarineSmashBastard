using UnityEngine;
using System.Collections;

public class Objective : MonoBehaviour {
	
	Vector3 screenBoxTopRight ;
	Vector3 screenBoxBottomLeft;
	public float speed = 0.1f;

	
	public float offScreenRange = 0.5f;

	
	private Animator animator;
	
	void Start () {
		float distance = this.transform.position.z - Camera.main.transform.position.z;
		screenBoxTopRight = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, distance));
		screenBoxBottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		//score = GameObject.Find ("Score").GetComponent<Score> ();
	
	}
	
	void Update () {
		transform.position += Vector3.left * speed * Time.deltaTime;

		if ((transform.position.x < screenBoxBottomLeft.x - offScreenRange) || 
		    (transform.position.x > screenBoxTopRight.x + offScreenRange) ||
		    (transform.position.y < screenBoxBottomLeft.y - offScreenRange) ||
		    (transform.position.y > screenBoxTopRight.y + offScreenRange)) {
			Destroy(gameObject);
		}

	}

}
