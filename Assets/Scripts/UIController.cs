using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

	public GUIStyle empty;
	public GUIStyle full;

	public Texture2D emptyTex;
	public Texture2D fullTex;

	public float displayAmount;

	public Vector2 pos;
	private Vector2 size = new Vector2(250,50);



	void OnGUI()
	{
		//draw the background:
		GUI.BeginGroup(new Rect(pos.x, pos.y , size.x, size.y), emptyTex, empty);
		GUI.Box(new Rect(pos.x, pos.y, size.x, size.y), fullTex, full);
		
		//draw the filled-in part:
		GUI.BeginGroup( new Rect(0, 0, size.x * displayAmount, size.y));
		GUI.Box( new Rect(0, 0, size.x, size.y), fullTex, full );
		
		GUI.EndGroup();
		GUI.EndGroup();
	}
}
