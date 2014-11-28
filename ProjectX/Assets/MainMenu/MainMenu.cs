using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public Texture backGround;
	public Texture2D buttonTexture;
	//public GUIStyle Style;
	float originalWidth = 720f;  // define here the original resolution
	float originalHeight = 1280f; // you used to create the GUI contents 
	private Vector3 scale;

	void OnGUI(){
		scale.x = Screen.width/originalWidth; // calculate hor scale
		scale.y = Screen.height/originalHeight; // calculate vert scale
		scale.z = 1;
		var svMat = GUI.matrix; // save current matrix
		// substitute matrix - only scale is altered from standard
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
		// draw your GUI controls here:

		if (GUI.Button(new Rect (originalWidth / 2 - buttonTexture.width/2, originalHeight / 2 - buttonTexture.height/2 
		           ,buttonTexture.width, buttonTexture.height), buttonTexture, GUIStyle.none)) 
		   
		{
			Application.LoadLevel(1);
			return;
				}
		GUI.matrix = svMat; // restore matrix
	}
}
