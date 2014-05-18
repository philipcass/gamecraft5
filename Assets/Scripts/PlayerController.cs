using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{	
	public float speed = 12;
	public int player;

	string XAxis;
	string YAxis;
	string Shout;

	CircleCollider2D influence;

	Leader leaderController;

	// START - Use this for initialization
	void Start () {
		this.leaderController = this.GetComponent<Leader> ();
		XAxis = "L_XAxis_" + player;
		YAxis = "L_YAxis_" + player;
		Shout = "A_" + player;
		influence = this.GetComponent<CircleCollider2D> ();
	}
	
	// UPDATE is called once per frame
	void Update () {
		// Moves player left, right, up, down. No collision.
		float x = Input.GetAxis(XAxis) * Time.smoothDeltaTime * speed;
		float y = -Input.GetAxis(YAxis) * Time.smoothDeltaTime * speed;
		transform.Translate(x,y,0,Space.Self);
		if (Input.GetButtonDown (Shout) && !isInfluencing && leaderController.power > leaderController.powerUse) {
			StartCoroutine (Influence ());
		}
	}

	bool isInfluencing = false;
	IEnumerator Influence(){
		leaderController.power -= leaderController.powerUse;
		isInfluencing = true;
		influence.enabled = true;
		yield return new WaitForSeconds(0.001f);
		isInfluencing = false;
		influence.enabled = false;

	}

}
