using UnityEngine;
using System.Collections;
using System;

public class Leader : MonoBehaviour {
	public LeaderConfig conf;
	public Allegiance myAllegiance;
	public BaseController BaseSpace;

	public UIController ui;
	public float power = 0;
	public float powerUse = 0.10f;
	public float powerGain = 0.01f;

	// Use this for initialization
	void Start () {
		ui = this.GetComponent<UIController> ();

		if(GameObject.Find ("Settings") != null){
			myAllegiance = GameObject.Find ("Settings").GetComponent<Settings> ().playerAllegiances [this.GetComponent<PlayerController> ().player];
		}
		this.GetComponent<SpriteRenderer> ().sprite = conf.Sprite [Array.IndexOf (conf.Allegiance, myAllegiance)];

		this.BaseSpace.Allegiance = this.myAllegiance;
	}
	
	// Update is called once per frame
	void Update () {
		power += Time.deltaTime * powerGain;
		power = Mathf.Clamp (power, 0, 1);
		ui.progress = power;
	}


}
