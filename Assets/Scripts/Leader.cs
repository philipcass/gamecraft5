﻿using UnityEngine;
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
			myAllegiance = GameObject.Find ("Settings").GetComponent<Settings> ().playerAllegiances [this.GetComponent<PlayerController> ().player-1];
			//Debug.Log(string.Format("{0}_{1}", this.GetComponent<PlayerController> ().player,myAllegiance));
		}
		this.GetComponent<SpriteRenderer> ().sprite = conf.Sprite [Array.IndexOf (conf.Allegiance, myAllegiance)];
		this.BaseSpace.setAllegiance(this.myAllegiance);
		this.transform.position = this.BaseSpace.transform.position;
		try{
			this.GetComponent<PlayerController> ().startAnimation ();
		}catch(Exception e){

		}
	}
	
	// Update is called once per frame
	void Update () {
		power += Time.deltaTime * powerGain;
		power = Mathf.Clamp (power, 0, 1);
		ui.progress = power;
		if (this.BaseSpace.renderer.bounds.Contains (this.transform.position)) {
			power += Time.deltaTime * 50;
		}
	}


}
