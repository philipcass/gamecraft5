using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour {

	private float intensity;
	private float previousIntensity;
	private Allegiance allegance;
	private Material mat;

	// Use this for initialization
	void Start () {
		mat = renderer.material;
	}
	
	// Update is called once per frame
	void Update () {

		if (previousIntensity != intensity) // on trigger on change
		{
			particleSystem.emissionRate = intensity;
			switch (allegance)
			{
				case Allegiance.Communism:
					
					particleSystem.renderer.material.color = Color.red;
				break;
				case Allegiance.Capitalism:
					particleSystem.renderer.material.color = Color.yellow;
				break;
			}
			previousIntensity = intensity;
		}
	}

	public void trigger(Allegiance allIn)
	{
		if (allIn == allegance)
		{
			intensity+=5f;
		}
		else
		{
			intensity-=5f;
			if (intensity < 0)
			{
				allegance = allIn;
				intensity = 5;
			}
		}
	}
}
