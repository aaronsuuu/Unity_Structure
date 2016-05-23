using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour {
	string url;
	public InputField inputURL;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartITRIscene(){
		if (inputURL.text != null) {
			url = inputURL.text;
			PlayerPrefs.SetString("URL",url);
			//Debug.Log ("ButtonClickURL:" + url);
		} else {
			//Debug.Log("NULL input...");
		}
		Application.LoadLevel ("ITRI");
	}
}
