using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Kills : MonoBehaviour {

	private int value =0;
	Text text;

	void Start () {
		text = this.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addToScore(int addition) {
		value += addition;
		text.text = "Kills " + value.ToString();

	}

	public int getKills() {
		return value;
	}
}

