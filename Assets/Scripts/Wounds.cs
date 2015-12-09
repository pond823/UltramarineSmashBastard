using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Wounds : MonoBehaviour {

	public int value =3;
	Text text;
	
	void Start () {
		text = this.GetComponent<Text>();
		Debug.Log (text);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void takeDamage(int addition) {
		value -= addition;
			text.text = "Wounds " + value.ToString ();
	}
}
