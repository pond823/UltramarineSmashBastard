using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

	Vector3 screenBoxTopRight ;
	Vector3 screenBoxBottomLeft;
	public float speed = 5.0f;
	public float offScreenRange = 0.1f;
	private float range = 5.0f;
	private float startX = 0;
	public int damage = 1;
	// Use this for initialization
	void Start () {
		float distance = this.transform.position.z - Camera.main.transform.position.z;
		screenBoxTopRight = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, distance));
		screenBoxBottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		startX = transform.position.x;
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.right * speed * Time.deltaTime;

		if ((transform.position.x < screenBoxBottomLeft.x - offScreenRange) || 
		    (transform.position.x > screenBoxTopRight.x + offScreenRange) ||
		    (transform.position.y < screenBoxBottomLeft.y - offScreenRange) ||
		    (transform.position.y > screenBoxTopRight.y + offScreenRange) ||
			(transform.position.x > startX + range)) {
			Destroy(gameObject);
		}

	}

	public void setRange(float newRange){
		range = newRange;
	}
}
