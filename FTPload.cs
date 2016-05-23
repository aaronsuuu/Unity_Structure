using UnityEngine;
using System.Collections;
using System.ComponentModel;
using System.Linq;

public class FTPload{
	public FTPClient ftp;
	public string url = null;

	public byte[] ConnectToDownload(){
		//if (url != null)StartCoroutine (DownloadFromFTP ());
		//DownloadFromFTP ();
		ftp = new FTPClient("ftp://"+url+":2121/sdcard/Pictures/structure.jpg", "collar", "password");
		//Debug.Log ("FTPload URL:" + url);
		ftp.Download ();
		if (ftp.complete) {
			ftp.complete = false;
			return ftp.raw;
		} else {
			Debug.Log ("ftp.raw is NULL...");
			return ftp.raw;
		}

	}
}
