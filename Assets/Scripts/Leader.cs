using UnityEngine;
using System.Collections;
using System;

public class Leader : MonoBehaviour {
	public LeaderConfig conf;
	public Allegiance myAllegiance;
	public BaseController BaseSpace;

	// Use this for initialization
	void Start () {
		this.GetComponent<SpriteRenderer> ().sprite = conf.Sprite [Array.IndexOf (conf.Allegiance, myAllegiance)];

		foreach (GameObject go in GameObject.FindGameObjectsWithTag ("Base")) {
			BaseController bc = go.GetComponent<BaseController>();
			if(this.myAllegiance == bc.Allegiance){
				this.BaseSpace = bc;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
