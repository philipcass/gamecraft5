using UnityEngine;
using System.Collections;

public class BannerSelector : MonoBehaviour {
	public void SetBanner(Sprite s){
		this.GetComponent<SpriteRenderer> ().sprite = s;
	}
}
