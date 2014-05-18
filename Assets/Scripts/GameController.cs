using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GUIText timerText;
	public int LevelTimer = 90;

	// Use this for initialization
	IEnumerator Start () {

		while (true)
		{
			yield return new WaitForSeconds(1f); 
			timerText.text = ""+LevelTimer--;
			if (LevelTimer == 0)
			{	
				Application.LoadLevel ("GameOver");
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
