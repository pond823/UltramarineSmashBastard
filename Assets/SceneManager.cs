using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneManager : MonoBehaviour {

	public void changeScene(string scene){
		Debug.Log (scene);
		Application.LoadLevel (scene);
	}

}
