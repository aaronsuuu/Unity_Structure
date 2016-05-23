using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIButton : MonoBehaviour {
	
	public Sprite Shake;
	public Sprite Machine;
	public Sprite Knife;
	public Sprite Tem;
	public Sprite Work;

	public GameObject ShakeButton;
	public GameObject MachineButton;
	public GameObject KnifeButton;
	public GameObject TemButton;
	public GameObject WorkButton;

	Image change,_machine;
	// Use this for initialization
	void Start () {
		ShakeButton = GameObject.Find("ShakeButton");
		MachineButton = GameObject.Find ("MachineButton");
		KnifeButton = GameObject.Find ("KnifeButton");
		TemButton = GameObject.Find ("TemButton");
		WorkButton = GameObject.Find ("WorkButton");
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void ShakeButtonClick(){
		//shakeButton = GameObject.Find ("ShakeButton").GetComponents<Image>();
			change = ShakeButton.GetComponent<Image>();
			change.sprite = Shake;
	}
	
	public void MachineButtonClick(){
			_machine = MachineButton.GetComponent<Image>();
			_machine.sprite = Machine;
	}
	
	public void KnifeButtonClick(){
			change = KnifeButton.GetComponent<Image>();
			change.sprite = Knife;
	}
	
	public void TemButtonClick(){
			change = TemButton.GetComponent<Image>();
			change.sprite = Tem;
	}
	
	public void WorkButtonClick(){
			change = WorkButton.GetComponent<Image>();
			change.sprite = Work;
	}
}
