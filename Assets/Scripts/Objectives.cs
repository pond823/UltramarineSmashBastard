using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Objectives : MonoBehaviour {

	private int value =0;
	Text text;

	void Start () {
		text = this.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addToObjectives(int addition) {
		value += addition;
		text.text = "Objectives " + value.ToString();

	}

	public int getObjectiveCount() {
		return value;
	}
}
