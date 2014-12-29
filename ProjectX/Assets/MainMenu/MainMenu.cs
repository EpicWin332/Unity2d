using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public Texture backGround;
	public Texture2D buttonTexture;
	//public GUIStyle Style;
	float originalWidth = 720f;  // define here the original resolution
	float originalHeight = 1280f; // you used to create the GUI contents 
	private Vector3 scale;
	static public int maxScore;
	public Texture2D soundTexture;
	public Texture2D soundonTexture;
	public Texture2D soundoffTexture;


	void Start () {
		if(AudioListener.volume==0) soundTexture=soundoffTexture;
		if(PlayerPrefs.HasKey("maxScore")){
			// there is a score, load that one
			maxScore=PlayerPrefs.GetInt("maxScore");
		}else{
			// no score
			maxScore=0;
		}	
	}

	void OnGUI(){
		scale.x = Screen.width/originalWidth; // calculate hor scale
		scale.y = Screen.height/originalHeight; // calculate vert scale
		scale.z = 1;
		var svMat = GUI.matrix; // save current matrix
		// substitute matrix - only scale is altered from standard
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
		// draw your GUI controls here:
		GUIStyle myStyle2 = new GUIStyle ();
		myStyle2.fontSize = 70;
		myStyle2.normal.textColor = Color.white;
		GUI.Label (new Rect (10, 10, 0, 0), "" + maxScore, myStyle2); 
		if (GUI.Button(new Rect (originalWidth / 2 - buttonTexture.width/2, originalHeight / 2 - buttonTexture.height/2 
		           ,buttonTexture.width, buttonTexture.height), buttonTexture, GUIStyle.none)) 
		   
		{
			Application.LoadLevel(1);
			return;
				}
		if (AudioListener.volume != 0 && GUI.Button 
		    (new Rect 
		 (originalWidth - soundTexture.width + 4, -6, soundTexture.width, soundTexture.height), soundTexture, GUIStyle.none)) {
			soundTexture=soundoffTexture;
			AudioListener.volume = 0;
		}
		if (AudioListener.volume == 0 && GUI.Button 
		    (new Rect 
		 (originalWidth - soundTexture.width + 4, -6, soundTexture.width, soundTexture.height), soundTexture, GUIStyle.none)) {
			soundTexture=soundonTexture;
			AudioListener.volume = 1;
		}

		GUI.matrix = svMat; // restore matrix
	}
}
