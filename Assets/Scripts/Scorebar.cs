﻿using UnityEngine;
using System.Collections;
using System;

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

		VoterManager vm = FindObjectOfType<VoterManager>();
		float totalVoters = vm.transform.childCount;
		foreach(Transform child in vm.transform)
		{
			VoterController voter = child.gameObject.GetComponent<VoterController>();
			percentage = voter.allegiances[myAllegiance] / totalVoters;
		}
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = Vector2.Lerp (this.transform.position, p + new Vector2 (0, height)*percentage, Time.deltaTime);
	}
}
