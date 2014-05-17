using UnityEngine;
using System.Collections;

public class VoterManager : MonoBehaviour {

	public float voterCount = 100;
	public VoterController voterPrefab;
	public VoterState state;

	private VoterState previousState;

	// Use this for initialization
	void Start () {
		if (voterPrefab)
		{
			for (int i = 0 ; i < voterCount ; i++)
			{
				VoterController voter = Instantiate(voterPrefab, Vector3.zero, transform.rotation) as VoterController;
				voter.transform.parent = transform;
				voter.transform.localPosition = pointInsideCircle (
																	new Vector2(transform.position.x,transform.position.y) , 
																	GetComponent<CircleCollider2D>().radius 
				                                                   );

			}
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		switch (state)
		{
			case VoterState.Idle:
				
			break;

			case VoterState.Heading:
				
			break;

			case VoterState.Cheering:
				
			break;
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
}
