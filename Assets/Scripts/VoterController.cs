using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class VoterController : MonoBehaviour {

	public float minWait = .5f;
	public float maxWait = 3f;
	public VoterState state;
	public float speed = 2f;
	public float proximityDistance=.01f;

	public Dictionary<VoterState,float> alligence;

	private VoterState previousState;
	private Vector3 heading;


	
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
					float offsetDistance = offset.magnitude;
		
					if (offsetDistance < proximityDistance ) // close enough
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

	Vector2 pointInsideBox(Vector2 boxPos, Vector2 size)
	{
		Vector2 newPoint;
		float x = Random.Range (0.0F, size.x);
		float y = Random.Range (0.0F, size.y);
		newPoint.x = boxPos.x-(size.x/2) + x;
		newPoint.y = boxPos.y-(size.y/2) + y;
		return (newPoint);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if( other.gameObject.tag == "Leader" )
		{
			BaseController baseController = other.gameObject.GetComponent<Leader>().BaseSpace;

			heading = pointInsideBox (
                	new Vector2(baseController.transform.position.x,baseController.transform.position.y), 
                	baseController.GetComponent<BoxCollider2D>().size
                );
			state = VoterState.Heading;

		}
		
    }
}
