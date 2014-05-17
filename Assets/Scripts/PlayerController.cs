using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{	
	public float speed = 12;
	public int player = 1;

	string XAxis;
	string YAxis;
	string Shout;

	CircleCollider2D influence;

	// START - Use this for initialization
	void Start () {
		XAxis = "L_XAxis_" + player;
		YAxis = "L_YAxis_" + player;
		Shout = "A_" + player;
		influence = this.GetComponentInChildren<CircleCollider2D> ();
		influence.gameObject.SetActive (false);
	}
	
	// UPDATE is called once per frame
	void Update () {
		// Moves player left, right, up, down. No collision.
		float x = Input.GetAxis(XAxis) * Time.smoothDeltaTime * speed;
		float y = -Input.GetAxis(YAxis) * Time.smoothDeltaTime * speed;
		transform.Translate(x,y,0,Space.Self);
		if (Input.GetButtonDown (Shout) && !isInfluencing) {
			StartCoroutine (Influence ());
		}


	}

	bool isInfluencing = false;
	IEnumerator Influence(){
		isInfluencing = true;
		influence.gameObject.SetActive (true);
		yield return new WaitForSeconds(0.1f);
		isInfluencing = false;
		influence.gameObject.SetActive (false);
	}
}
