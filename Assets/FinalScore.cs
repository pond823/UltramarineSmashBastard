using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FinalScore : MonoBehaviour {

	Text text;
	
	void Start () {
		text = this.GetComponent<Text>();

		int objs = PlayerPrefs.GetInt("Objectives");
		int kills = PlayerPrefs.GetInt("Kills");

		text.text = "You Failed The Emperor!" + " Objectives " + objs + " Kills " + kills;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
