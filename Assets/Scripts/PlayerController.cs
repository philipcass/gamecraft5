using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{	
	public float speed = 12;
	public int player;

	string XAxis;
	string YAxis;
	string Shout;

	string _walkani;
	string _idleani;

	CircleCollider2D influence;

	Leader leaderController;

	Animator _animator;

	// START - Use this for initialization
	void Start () {
		_animator = GetComponent<Animator>();
		this.leaderController = this.GetComponent<Leader> ();
		XAxis = "L_XAxis_" + player;
		YAxis = "L_YAxis_" + player;
		Shout = "A_" + player;
		influence = this.GetComponent<CircleCollider2D> ();
		selectanimations ();
		_animator.Play (Animator.StringToHash(_idleani));
	}
	
	// UPDATE is called once per frame
	void Update () {
		// Moves player left, right, up, down. No collision.
		float x = Input.GetAxis(XAxis) * Time.smoothDeltaTime * speed;
		float y = -Input.GetAxis(YAxis) * Time.smoothDeltaTime * speed;
		transform.Translate(x,y,0,Space.Self);
		if(x+y!=0){
			_animator.Play (Animator.StringToHash(_walkani));
		} 
		else{
			_animator.Play (Animator.StringToHash(_idleani));
		}

		if (x > 0 && this.transform.localScale.x < 0){
			this.transform.localScale = new Vector3(-this.transform.localScale.x, this.transform.localScale.y,this.transform.localScale.z);
		}
		else if (x<0 && this.transform.localScale.x > 0) {
			this.transform.localScale = new Vector3(-this.transform.localScale.x, this.transform.localScale.y,this.transform.localScale.z);
		}

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

	void selectanimations(){
		switch (leaderController.myAllegiance) {
		case(Allegiance.Anarchism):
			_idleani = "Anarchist_Idle";
			_walkani = "Anarchist_Walk";
			break;
		case(Allegiance.Capitalism):
			_idleani = "Capitalist_Idle";
			_walkani = "Capitalist_Walk";
			break;
		case(Allegiance.Communism):
			_idleani = "Communist_Idle";
			_walkani = "Communist_Walk";
			break;
		case(Allegiance.Facism):
			_idleani = "Facist_Idle";
			_walkani = "Facist_Walk";
			break;
		case(Allegiance.Theocracy):
			_idleani = "Theocrat_Idle";
			_walkani = "Theocrat_Walk";
			break;
		}
	}
}
