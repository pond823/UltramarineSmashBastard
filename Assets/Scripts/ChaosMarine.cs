using UnityEngine;
using System.Collections;

public class ChaosMarine : MonoBehaviour {

	Vector3 screenBoxTopRight ;
	Vector3 screenBoxBottomLeft;
	public float speed = 5.0f;
	public float deadSpeed = 0.005f;

	public float offScreenRange = 0.5f;
	public int hitPoints = 5;
	public GameObject blood;
	public GameObject bigBlood;
	public Kills kills;
	public AudioClip urgh;
	public AudioClip die;
	public bool isDead = false;

	private Animator animator;
	private Objectives objectives;

	void Start () {
		float distance = this.transform.position.z - Camera.main.transform.position.z;
		screenBoxTopRight = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, distance));
		screenBoxBottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		animator = GetComponent<Animator> ();
		kills = GameObject.Find ("Kills").GetComponent<Kills> ();
		objectives = GameObject.Find ("Objectives").GetComponent<Objectives> ();
		speed = Random.Range (speed*0.8f, objectives.getObjectiveCount() + (speed * 2));

		
	}

	void Update () {
		if (!isDead) {
			transform.position += Vector3.left * Random.Range (speed / 2, speed) * Time.deltaTime;
		} else {
			transform.position += Vector3.left * deadSpeed * Time.deltaTime;
		}
		
		if ((transform.position.x < screenBoxBottomLeft.x - offScreenRange) || 
		    (transform.position.x > screenBoxTopRight.x + offScreenRange) ||
		    (transform.position.y < screenBoxBottomLeft.y - offScreenRange) ||
		    (transform.position.y > screenBoxTopRight.y + offScreenRange)) {
			Destroy(gameObject);
		}

		if (hitPoints < 1 && !isDead) {
			Instantiate (bigBlood, this.transform.position, Quaternion.identity);
			
			//Destroy (gameObject);
			kills.addToScore(1);
			AudioSource.PlayClipAtPoint(die, this.transform.position);
			animator.SetTrigger("isDead");
			isDead = true;
			transform.position += Vector3.forward;
			speed = deadSpeed;

		}
	}

	void OnTriggerEnter2D(Collider2D collider) {

		if (!isDead) {
			Shot shot = collider.gameObject.GetComponent<Shot> ();
			if (shot != null) {

				Instantiate (blood, this.transform.position, Quaternion.identity);
				hitPoints -= shot.damage;
				Destroy(shot.gameObject);
				AudioSource.PlayClipAtPoint(urgh, transform.position);
			}
		}
	}
}
