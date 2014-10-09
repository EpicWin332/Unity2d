using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour {

	public Texture2D buttonTexture;

	void OnGUI(){

		if (GUI.Button 
		    (new Rect (camera.pixelWidth / 2 - buttonTexture.width/2, camera.pixelHeight / 2 - buttonTexture.height/2 
		           ,buttonTexture.width, buttonTexture.height), buttonTexture, GUIStyle.none)) 
		   
		{
			Application.LoadLevel(1);
			return;
				}

	}
}
