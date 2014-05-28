using UnityEngine;
using System.Collections;

public enum Allegiance{
	Communism,
	Anarchism,
	Capitalism,
	Theocracy,
	Facism,
	None
}

public enum VoterState{
	Idle,
	Heading,
	Cheering

}


public class Settings:MonoBehaviour{
	public Allegiance[] playerAllegiances;

	void Awake(){
		DontDestroyOnLoad (this);
	}
	void Start(){
		playerAllegiances = new Allegiance[4];
	}
}
