using UnityEngine;
using System.Collections;

public class NewScreenDownload : MonoBehaviour {
	string url = "http://192.168.0.7:8080/Pictures/structure.jpg";
	Renderer plane;
	//bool checkImageState = true;
	IEnumerator Start () {
		plane = GetComponent<Renderer> ();
		while (true) {
			WWW web = new WWW(url);
			yield return web;
			if(web.error == null){
				plane.material.mainTexture = web.texture;
				web.Dispose();
				web = null;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
