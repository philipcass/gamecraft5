using UnityEngine;
using System.Collections;
using System;

public class BaseController : MonoBehaviour {
	public Allegiance Allegiance;
	public LeaderConfig conf;

	// Use this for initialization
	void Start () {
		this.GetComponentInChildren<BannerSelector> ().SetBanner (conf.CrestSprite[Array.IndexOf(conf.Allegiance, this.Allegiance)]);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setAllegiance(Allegiance a){
		this.Allegiance = a;
		this.GetComponentInChildren<BannerSelector> ().SetBanner (conf.CrestSprite[Array.IndexOf(conf.Allegiance, this.Allegiance)]);
	}
}
