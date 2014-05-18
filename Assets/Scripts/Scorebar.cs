using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Scorebar : MonoBehaviour {
	public float percentage;
	public Allegiance myAllegiance;
	public LeaderConfig conf;
	public int height;
	// Use this for initialization
	Vector2 p;
	void Start () {
		p = this.transform.position;
		this.GetComponentInChildren<BannerSelector> ().SetBanner (conf.CrestSprite[Array.IndexOf(conf.Allegiance, this.myAllegiance)]);

		GameController gc = GameObject.Find("GameController").GetComponent<GameController>();

		foreach( KeyValuePair<Allegiance,float> kv in gc.allegiances){

			if (kv.Key == myAllegiance)
				percentage = kv.Value;
		}


	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = Vector2.Lerp (this.transform.position, p + new Vector2 (0, height)*percentage, Time.deltaTime);
	}
}
