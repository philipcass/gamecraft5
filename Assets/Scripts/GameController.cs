using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameController : MonoBehaviour {

	public GUIText timerText;
	public int LevelTimer = 90;

	public Dictionary<Allegiance,float> allegiances;

	void OnAwake()
	{
		print (Application.loadedLevelName);
	}

	// Use this for initialization
	IEnumerator Start () {

        	DontDestroyOnLoad(this);
			while (true)
			{
				yield return new WaitForSeconds(1f); 
				timerText.text = ""+LevelTimer--;
				if (LevelTimer == 0)
				{	
					SaveScores();
					Application.LoadLevel ("Score");
				}
			}

    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.R))
			Application.LoadLevel("char_select");
	}

	void SaveScores() {
        VoterManager vm = FindObjectOfType<VoterManager>();
        float totalVoters = vm.transform.childCount;

		Dictionary<Allegiance,int> allegiancesToCarry = new Dictionary<Allegiance,int>();
		foreach(Transform voter in vm.transform)
		{
			Allegiance a =  voter.GetComponent<VoterController>().getMyalli();
			if(!allegiancesToCarry.ContainsKey(a)){
				allegiancesToCarry[a] = 0;
			}
			allegiancesToCarry[a]++;
        }

		int total = allegiancesToCarry.Values.Sum();
		Dictionary<Allegiance,float> allegiancesToCarry2 = new Dictionary<Allegiance,float>();
		foreach(KeyValuePair<Allegiance,int> kv in allegiancesToCarry){
			allegiancesToCarry2[kv.Key] = kv.Value/(float)total;
        }
		allegiances = allegiancesToCarry2;
    }
}
