using UnityEngine;
using System.Collections;

public class Selector : MonoBehaviour {
	public SelectorElement[] Elements;
	public GUIText[] playerPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 1; i<5; i++) {
			if(Input.GetAxis("L_XAxis_" + i) > 0){

			} else {

			}
		}
	}
}
