using UnityEngine;
using System.Collections;
using System.Threading;
using UnityEngine.UI;

public class DownloadImage : MonoBehaviour {
	string url;
	// Use this for initialization
	Renderer plane,plane2;
	Texture2D textureweb;
	//bool waitingTime = true;
	bool checkImageDownload = true;
	public Material mmchocolate;
	UnityEngine.UI.Text tt;
	public GameObject text;
	WWW web,web2;
	//int count = 1;
	void Start () {
		//StartCoroutine (WebImage());
		tt = text.GetComponent<UnityEngine.UI.Text> ();
		url = "http://192.168.0.7:8080/Pictures/structure.jpg";
		//plane = GetComponent<Renderer> ();
		//web = new WWW (url);
	}

	// Update is called once per frame
	void Update () {
		if (!checkImageDownload) {
			StartCoroutine (WebImage ());
		} else {
			StartCoroutine(webImage2());
		}
	}

	IEnumerator WebImage(){
		if (!checkImageDownload) {
			checkImageDownload = true;
			//url = "http://www.wired.com/wp-content/uploads/2015/09/google-logo.jpg";
			web = new WWW (url);
			yield return web;
			if (web != null) {
				if (web.error == null) {
					textureweb = web.texture;
					mmchocolate.mainTexture = textureweb;
					plane = GetComponent<Renderer> ();
					plane.material.mainTexture = mmchocolate.mainTexture;
				} else {
					tt.text = web.error;
					StopCoroutine (WebImage ());
				}

			
			}
			web.Dispose ();
			web = null;
			yield return new WaitForSeconds (0.3f);
		}
	}

	IEnumerator webImage2(){
		if (checkImageDownload) {
			checkImageDownload = false;
			web2 = new WWW(url);
			yield return web2;
			if(web != null){
				if(web.error == null){
					plane2 = GetComponent<Renderer>();
					plane2.material.mainTexture = web2.texture;
			}
				else{
					StopCoroutine(webImage2());
				}
		}
			web2.Dispose ();
			web2 = null;
			yield return new WaitForSeconds (0.3f);
	}


	}
}


















