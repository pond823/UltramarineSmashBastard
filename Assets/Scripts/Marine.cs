using UnityEngine;
using System.Collections;

public class Marine : MonoBehaviour {
	public GameObject blood;
	public Shot shot;
	public float speed = 0.1f;
	public float padding =1.0f;
	private float waitLenghth = 0.8f;

	public Kills kills;
	public Objectives objectives;
	public Wounds wounds;

	public AudioClip gunshot;
	public AudioClip argh;
	public AudioClip yeah;
	public AudioClip heavyBolter;

	private float maxX,maxY,minX,minY; 
	private Animator animator;
	private int weapon = 0;

	private Vector3 origin;
	// Use this for initialization
	void Start () {
		origin = this.transform.position;
		Instantiate (blood, origin, Quaternion.identity);
		this.transform.Rotate(0, 180, 0);

		float distance = this.transform.position.z - Camera.main.transform.position.z;
		Vector3 screenBoxTopRight = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, distance));
		Vector3 screenBoxBottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));

		maxX = screenBoxTopRight.x-padding;
		maxY = screenBoxTopRight.y-padding;
		minX = screenBoxBottomLeft.x + padding;
		minY = screenBoxBottomLeft.y + padding;

		Debug.Log ("getting animator");
		animator = GetComponent<Animator>();
		Debug.Log ("animator - " + animator);
		animator.SetInteger("Weapon",0);

		kills = GameObject.Find ("Kills").GetComponent<Kills> ();
		objectives = GameObject.Find ("Objectives").GetComponent<Objectives> ();
		wounds = GameObject.Find ("Wounds").GetComponent<Wounds> ();


	}
	
	// Update is called once per frame
	void Update () {

		if (wounds.value < 1) {
			PlayerPrefs.SetInt("Objectives", objectives.getObjectiveCount());
			PlayerPrefs.SetInt("Kills", kills.getKills());
			PlayerPrefs.Save();

			Destroy(this.gameObject);
			Application.LoadLevel ("Failed");
		}

		if (Input.GetKeyDown("'")) {
			InvokeRepeating("fireGun", 0.00001f, waitLenghth);
		} else if (Input.GetKeyUp("'")) {
			CancelInvoke("fireGun");
		}


		if (Input.GetKey("z")) {
			this.transform.position += Vector3.left * speed * Time.deltaTime;  
	
		}
		if (Input.GetKey("x")) {
			this.transform.position += Vector3.right * speed * Time.deltaTime;  
		}
		if (Input.GetKey(";")) {
			this.transform.position += Vector3.up * speed * Time.deltaTime;  
		}
		if (Input.GetKey(".")) {
			this.transform.position += Vector3.down * speed * Time.deltaTime;  
		}
		float newX = Mathf.Clamp (this.transform.position.x, minX, maxX);
		float newY = Mathf.Clamp (this.transform.position.y, minY, maxY);

		this.transform.position = new Vector3(newX,newY,0);
	
	}


	void fireGun() {

		Shot shotFired = (Shot)Instantiate (shot, this.transform.position, Quaternion.identity);

		if (weapon == 1) {
			shotFired.setRange (7.0f); 
			shotFired.damage = 2;
			AudioSource.PlayClipAtPoint (heavyBolter, transform.position);

		} else {
			shotFired.setRange (5.0f);
			AudioSource.PlayClipAtPoint (gunshot, transform.position);

		}


	}

	void OnTriggerEnter2D(Collider2D collider) {
		ChaosMarine chaosMarine = collider.gameObject.GetComponent<ChaosMarine> ();
		if (chaosMarine != null && !chaosMarine.isDead) {
			Instantiate (blood, this.transform.position, Quaternion.identity);
			wounds.takeDamage(1);
			//Destroy(chaosMarine.gameObject);
			AudioSource.PlayClipAtPoint(argh, transform.position);

		}

		HeavyBolter heavyBolter = collider.gameObject.GetComponent<HeavyBolter> ();
		if (heavyBolter != null) {
			AudioSource.PlayClipAtPoint(yeah, transform.position);
			Destroy(heavyBolter.gameObject);
			waitLenghth = 0.4f;
			speed = 1.2f;
			weapon =1;
			animator.SetInteger("Weapon",1);	
		}

		Bolter bolter = collider.gameObject.GetComponent<Bolter> ();
		if (bolter != null) {
			AudioSource.PlayClipAtPoint(yeah, transform.position);
			Destroy(bolter.gameObject);
			waitLenghth = 0.8f;
			speed = 2.0f;
			weapon =0;
			animator.SetInteger("Weapon",0);
		}

		Objective objective = collider.gameObject.GetComponent<Objective> ();
		if (objective != null) {
			AudioSource.PlayClipAtPoint(yeah, transform.position);
			Destroy(objective.gameObject);
			objectives.addToObjectives(1);
		}

	
	}


}
