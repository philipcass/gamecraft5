using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class VoterController : MonoBehaviour {

	public float minWait = .5f;
	public float maxWait = 3f;
	public VoterState state;
	public float speed = 2f;
	public float proximityDistance=.01f;

	public float allegianceIncValue =1f;
	public float allegianceDecValue =.5f;
	public float allegianceThreshold = 50f;

	public ParticleController pc;

	public Dictionary<Allegiance,float> allegiances;

	private VoterState previousState;
	private Vector3 heading;


	
	// Update is called once per frame
	IEnumerator Start () {
		allegiances = new Dictionary<Allegiance, float>();
		allegiances.Add( Allegiance.Anarchism,0);
		allegiances.Add( Allegiance.Capitalism,0);
		allegiances.Add( Allegiance.Communism,0);
		allegiances.Add( Allegiance.Theocracy,0);
		allegiances.Add( Allegiance.Facism,0);


		while (true)
		{
			switch (state)
			{
				case VoterState.Idle:

                    //random movement
                    heading = pointInsideCircle (
                        new Vector2(transform.position.x,transform.position.y) , 
                        GetComponent<CircleCollider2D>().radius 
                        );

                    //random
                    float waitFor = Random.Range (minWait,maxWait);
					yield return new WaitForSeconds(waitFor);

					state = VoterState.Heading;
				break;
					
				case VoterState.Heading:

					Vector3 offset = heading - transform.position;
					float offsetDistance = offset.magnitude;
		
					if ( offsetDistance < proximityDistance ) // close enough
						state = VoterState.Idle; 
					else // keep going
						transform.position = (offset.normalized * Time.deltaTime * speed) + transform.position;
					
					yield return new WaitForSeconds(0.01f);
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

	Allegiance? handleAllegiance (Allegiance allegianceIn)
	{
		List<Allegiance> allegianceKeys = new List<Allegiance>(allegiances.Keys);
		foreach(Allegiance allegiance in allegianceKeys )
		{
			if (allegiance == allegianceIn)
				allegiances[allegiance] = allegiances[allegiance] + allegianceIncValue;
			else
				allegiances[allegiance] = allegiances[allegiance] - allegianceDecValue ;
			Mathf.Clamp(allegiances[allegiance], 0f, 100f);
		}

        if ( allegiances[allegianceIn] > allegianceThreshold )
			return allegianceIn;
		else 
			return null;

		
     }
            
	void OnTriggerEnter2D(Collider2D other) {

		if( other.gameObject.tag == "Leader" )
		{
			Leader leader = other.gameObject.GetComponent<Leader>();
			BaseController baseController = leader.BaseSpace;

			if ( handleAllegiance(leader.myAllegiance) != null )
			{           
				pc.trigger(leader.myAllegiance);
            	heading = pointInsideBox (
                		new Vector2(baseController.transform.position.x,baseController.transform.position.y), 
                		baseController.GetComponent<Renderer>().bounds.size
                	);
				state = VoterState.Heading;
			}
		}

    }
}
