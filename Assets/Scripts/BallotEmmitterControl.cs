using UnityEngine;
using System.Collections;

public class BallotEmmitterControl : MonoBehaviour {

	public GameObject ballotPrefab;
	public Vector2 ballotSpawnTimeRange;
	public float forceMultiplier=100f;

	// Use this for initialization
	IEnumerator Start () {
		while (true)
		{

			GameObject ballot = Instantiate(ballotPrefab, transform.position, Quaternion.identity) as GameObject;
			ballot.rigidbody2D.AddForceAtPosition (Random.insideUnitSphere * forceMultiplier, ballot.transform.position);
			ballot.transform.parent = transform;
			ballot.transform.position = pointInsideCircle (
											new Vector2(transform.position.x,transform.position.y) , 
											GetComponent<CircleCollider2D>().radius 
										);

			float sleepFor = Random.Range(ballotSpawnTimeRange[0], ballotSpawnTimeRange[1]);
			yield return new WaitForSeconds(sleepFor); 
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	Vector2 pointInsideCircle(Vector2 circlePos, float radiusIn){
		Vector2 newPoint;
		float angle = Random.Range(0.0F, 1.0F) * (Mathf.PI * 2);
		float radius = Random.Range(0.2F, 1.0F) * radiusIn;
		newPoint.x = circlePos.x + radius * Mathf.Cos(angle);
		newPoint.y = circlePos.y + radius * Mathf.Sin(angle);
		return (newPoint);
	}
}
