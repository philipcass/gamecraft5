using UnityEngine;
using System.Collections;

public class VoterController : MonoBehaviour {

	public float minWait = .5f;
	public float maxWait = 3f;
	public VoterState state;
	public float speed = 2f;
	public float proximityDistance=.01f;

	private VoterState previousState;
	private Vector3 heading = new Vector3(-17,-1,0);


	
	// Update is called once per frame
	IEnumerator Start () {
		while (true)
		{
			switch (state)
			{
				case VoterState.Idle:
					//random wait
					float waitFor = Random.Range (minWait,maxWait);
					
					yield return new WaitForSeconds(waitFor);

					//random movement
					heading = pointInsideCircle (
														new Vector2(transform.position.x,transform.position.y) , 
														GetComponent<CircleCollider2D>().radius 
					                                    );
					
					state = VoterState.Heading;
				break;
					
				case VoterState.Heading:
					Vector3 offset = heading - transform.position;
					float sqrLen = offset.sqrMagnitude;
					

					if (sqrLen < proximityDistance ) // close enough
						state = VoterState.Idle; 
					else // keep going
						transform.position = Vector3.Lerp(transform.position, heading, Time.deltaTime*speed);	
					
				break;
					
				case VoterState.Cheering:
					
				break;
			}
		}
	}

	Vector2 pointInsideCircle(Vector2 circlePos, float radiusIn){
		Vector2 newPoint;
		float angle = Random.Range(0.0F, 1.0F) * (Mathf.PI * 2);
		float radius = Random.Range(0.0F, 1.0F) * radiusIn;
		newPoint.x = circlePos.x + radius * Mathf.Cos(angle);
		newPoint.y = circlePos.y + radius * Mathf.Sin(angle);
		return (newPoint);
	}

	void OnTriggerEnter(Collider other) {

     	if( other.tag == "Leader" )
		{
			other.gameObject.GetComponent<Leader>().BaseSpace;
		}

	}
}
