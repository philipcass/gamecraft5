using UnityEngine;
using System.Collections;
using System;

public class Leader : MonoBehaviour {
	public LeaderConfig conf;
	public Allegiance Allegiance;

	// Use this for initialization
	void Start () {
		this.GetComponent<SpriteRenderer> ().sprite = conf.Sprite [Array.IndexOf (conf.Allegiance, Allegiance)];
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
