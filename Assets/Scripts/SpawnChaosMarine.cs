using UnityEngine;
using System.Collections;

public class SpawnChaosMarine : MonoBehaviour {

	public GameObject chaosMarine;
	public GameObject heavyBolter;
	public GameObject bolter;
	public GameObject objective;


	public float speed=3.0f;
	Vector3 screenBoxTopRight;
	Vector3 screenBoxBottomLeft;
	public float offScreenRange = 0.1f;
	public float nextSpawn = 100f;
	void Start () {
		float distance = this.transform.position.z - Camera.main.transform.position.z;

		screenBoxTopRight = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, distance));
		screenBoxBottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		InvokeRepeating("spawnChaosMarine", nextSpawn/2, nextSpawn+Random.Range(0,nextSpawn));
		InvokeRepeating ("spawnHeavyBolter", Random.Range (10,15),Random.Range(8,17));
		InvokeRepeating ("spawnBolter", Random.Range (7,10),Random.Range(3,15));
		InvokeRepeating ("spawnObjective", Random.Range (20,25),Random.Range(15,20));
	}
	

	void Update () {

	}


	void spawnChaosMarine() {
		GameObject enemy = Instantiate (chaosMarine, new Vector3(screenBoxTopRight.x, Random.Range(screenBoxBottomLeft.y, screenBoxTopRight.y)) , Quaternion.identity) as GameObject;

	}

	void spawnHeavyBolter() {
		GameObject hb = Instantiate (heavyBolter, new Vector3(screenBoxTopRight.x, Random.Range(screenBoxBottomLeft.y, screenBoxTopRight.y)) , Quaternion.identity) as GameObject;

	}

	void spawnBolter() {
		GameObject b = Instantiate (bolter, new Vector3(screenBoxTopRight.x, Random.Range(screenBoxBottomLeft.y, screenBoxTopRight.y)) , Quaternion.identity) as GameObject;
		
	}

	void spawnObjective() {
		GameObject o = Instantiate (objective, new Vector3(screenBoxTopRight.x, Random.Range(screenBoxBottomLeft.y, screenBoxTopRight.y)) , Quaternion.identity) as GameObject;
		
	}
		
}
