using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

	public float progress = 0;
	public Vector2 pos = new Vector2(20,40);
	Vector2 size = new Vector2(60,20);
	public Texture2D progressBarEmpty;
	public Texture2D progressBarFull;

	public bool left;
	public bool bottom;
	
	void OnGUI()
	{
		float posX = left ? pos.x + Screen.width-100 : pos.x;
		float posY = bottom ? pos.y + Screen.height-100 : pos.y;

		GUI.DrawTexture(new Rect(posX+4, posY+4, size.x * Mathf.Clamp01(progress)-6, size.y/2), progressBarFull);
		GUI.DrawTexture(new Rect(posX, posY, size.x, size.y), progressBarEmpty);
	} 
	
	void Update()
	{
	}
}
