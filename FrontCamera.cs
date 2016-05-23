using UnityEngine;
using System.Collections;

public class FrontCamera : MonoBehaviour {
	Renderer plane;
	WebCamDevice[] device = WebCamTexture.devices;
	WebCamTexture back;
	// Use this for initialization
	void Start () {
		plane = GetComponent<Renderer> ();
		int index = 0;
		foreach (WebCamDevice cam in device) {
			index++;
			if(cam.isFrontFacing){
				WebCamTexture back = new WebCamTexture(index,Screen.width,Screen.height);
				back.deviceName = cam.name;
				plane.material.mainTexture = back;
				back.Play();
			}
			Debug.Log("device:"+index);
		}
		/*plane = GetComponent<Renderer> ();
		for (int cameraIndex = 0; cameraIndex<device.Length; cameraIndex++) {
			if(device[cameraIndex].isFrontFacing){
				back = new WebCamTexture(cameraIndex,Screen.width,Screen.height);
			}
		}
		plane.material.mainTexture = back;
		back.Play ();*/
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
