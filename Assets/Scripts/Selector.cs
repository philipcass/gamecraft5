using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Selector : MonoBehaviour {
	public SelectorElement[] Elements;
	public TextMesh[] playerText;

	public int[] playerPos;
	HashSet<int> ready = new HashSet<int>();

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		for (int player = 0; player<4; player++) {
			int currentPosition = playerPos[player];
			if(Input.GetAxis("L_XAxis_" + (player+1)) > 0){
				while(Array.IndexOf(playerPos, currentPosition) != -1){
					currentPosition++;
					currentPosition = currentPosition==Elements.Length?0:currentPosition;
				}
			} else if(Input.GetAxis("L_XAxis_" + (player+1)) < 0){
				while(Array.IndexOf(playerPos, currentPosition) != -1){
					currentPosition--;
					currentPosition = currentPosition==-1?Elements.Length-1 : currentPosition;

				}
			}
			playerPos[player] = currentPosition;
			
			if(Input.GetButtonUp("A_" + (player+1)) ){
				ready.Add(playerPos[player]);
			}

		}

		for(int player = 0; player < 4; player++) {
			int pp = playerPos[player];
			playerText[player].transform.position = Elements[pp].transform.position + new Vector3(0,2,0);
		}

		if (ready.Count == 1) {
			Settings s = GameObject.Find("Settings").GetComponent<Settings>();
			for(int player = 0; player < 4; player++) {
				int pp = playerPos[player];
				s.playerAllegiances[player] = Elements[pp].Allegiance;
			}
			Application.LoadLevel("main");
		}
	}
}
