using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour {

	public float intensityIncrement = 20f;

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
		particleSystem.renderer.sortingLayerName = "Banner";

		if (previousIntensity != intensity) // on trigger on change
		{
			particleSystem.emissionRate = intensity;
			switch (allegance)
			{
				case Allegiance.Communism:
					particleSystem.startColor = Color.red;
				break;
				case Allegiance.Capitalism:
					particleSystem.startColor = Color.blue;
				break;
				case Allegiance.Facism:
					particleSystem.startColor = Color.black;
				break;
				case Allegiance.Theocracy:
					particleSystem.startColor = Color.white;
				break;
				case Allegiance.Anarchism:
					particleSystem.startColor = Color.yellow;
				break;
			}
			previousIntensity = intensity;
		}
	}

	public void trigger(Allegiance allIn)
	{
		if (allIn == allegance)
		{
			intensity+=intensityIncrement;
		}
		else
		{
			intensity-=intensityIncrement;
			if (intensity < 0)
			{
				allegance = allIn;
				intensity = intensityIncrement;
			}
		}
	}
}
