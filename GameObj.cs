using UnityEngine;
using System.Collections;
using System.Threading;
using System.ComponentModel;

public class GameObj : MonoBehaviour
{
	string url = null;
    FTPClient ftp;
	Renderer planeRenderer;
	//bool check = true;
	private BackgroundWorker backworker;
	FTPload load = new FTPload();
	byte[] raw = null;

	void Awake(){
		backworker = new BackgroundWorker();
		planeRenderer = GetComponent<Renderer> ();
		url =PlayerPrefs.GetString ("URL");
		load.url = url;
		if(url!=null)RunBackground ();
	}

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		if (raw != null) {
			Texture2D t = new Texture2D (1, 1);
			t.LoadImage (raw);
			planeRenderer.material.mainTexture = t;
		}

    }
	#region Start Background Running
	private void RunBackground(){
		InitBackworker ();
		//FTPload load = new FTPload ();
		//load.url = url;
		backworker.RunWorkerAsync (load);
		Debug.Log ("RunBackground...");
	}
	#endregion



	#region Paste Material on the Plane
	private void backworker_RunworkCompelete(object sender,RunWorkerCompletedEventArgs args){
		if (!backworker.WorkerSupportsCancellation) {
			raw = (byte[])args.Result;
			backworker.RunWorkerAsync (load);
			Debug.Log ("backworker_RunworkCompelete...");
		}
	}
	#endregion



	#region Set the Method of FTPload
	private void backwork_Dowork(object sender,DoWorkEventArgs args){
		if (!backworker.WorkerSupportsCancellation) {
			FTPload load = (FTPload)args.Argument;
			args.Result = load.ConnectToDownload ();
			Debug.Log ("backwork_Dowork...");
		}
	}
	#endregion

	//PlayerPref

	#region Set Handler Wait Feedback
	private void InitBackworker(){
		backworker.DoWork += new DoWorkEventHandler (backwork_Dowork);
		backworker.RunWorkerCompleted += new RunWorkerCompletedEventHandler (backworker_RunworkCompelete);
		Debug.Log ("InitBackworker");
	}
	#endregion


	#region Stop Background Running Button
	public void StopBackground(){
		backworker.WorkerSupportsCancellation = true;
		Debug.Log ("Background is Stop.");
	}
	#endregion
}




