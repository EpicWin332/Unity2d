using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public Texture2D buttonTexture;
	//public GUIStyle Style;
	float originalWidth = 720f;  // define here the original resolution
	float originalHeight = 1280f; // you used to create the GUI contents 
	private Vector3 scale;
	static public int maxScore;
	public Texture2D soundTexture;
	public Texture2D soundonTexture;
	public Texture2D soundoffTexture;
	public Texture2D infoTexture;
	public Texture2D downTexture;
	bool up=false, down=false,main=true;
	float lift=0;


	void Start () {
		if(PlayerPrefs.HasKey("soundVolume")){
			if(PlayerPrefs.GetInt("soundVolume")==0) AudioListener.volume=0;
		}
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
		GUI.Label (new Rect (10, 10+lift, 0, 0), "" + maxScore, myStyle2); 
		if (GUI.Button(new Rect (originalWidth / 2 - buttonTexture.width/2, originalHeight / 2 - buttonTexture.height/2 +lift
		           ,buttonTexture.width, buttonTexture.height), buttonTexture, GUIStyle.none)) 
		   
		{
			Application.LoadLevel(1);
			return;
				}
		if (AudioListener.volume != 0 && GUI.Button 
		    (new Rect 
		 (originalWidth - soundTexture.width, lift, soundTexture.width, soundTexture.height), soundTexture, GUIStyle.none)) {
			soundTexture=soundoffTexture;
			AudioListener.volume = 0;
			PlayerPrefs.SetInt("soundVolume",0);
		}
		if (AudioListener.volume == 0 && GUI.Button 
		    (new Rect 
		 (originalWidth - soundTexture.width, lift, soundTexture.width, soundTexture.height), soundTexture, GUIStyle.none)) {
			soundTexture=soundonTexture;
			AudioListener.volume = 1;
			PlayerPrefs.SetInt("soundVolume",1);
		}

		if (GUI.Button(new Rect (originalWidth / 2 - infoTexture.width/2, 5 +lift
		                         ,infoTexture.width, infoTexture.height), infoTexture, GUIStyle.none)) 
			
		{
			if(!down)up=true;
		}
		if (GUI.Button(new Rect (originalWidth / 2 - downTexture.width/2, -30 - downTexture.height +lift
		                         ,downTexture.width, downTexture.height), downTexture, GUIStyle.none)) 
			
		{
			if(!up)down=true;
		}
		GUIStyle myStyle = new GUIStyle (GUI.skin.label);
		myStyle.fontSize = 45;
		//myStyle.border
		GUI.Box (new Rect (originalWidth / 2-190, 0 - originalHeight / 1.3f + lift, 450 , 550), "Programmers:\n\n"+"Gamzatov Magomed\n" +
		         "Podusenko Albert\n" +
		         "Yaraliev Rashid\n\n" +
		         "Designers:\n\n" +
		         "???\n" +
		         "???",myStyle);
		GUI.matrix = svMat; // restore matrix
	}

	void Update()
	{
		if (up) lift += Time.deltaTime*1200;
		if (lift >= originalHeight) {
						up = false;
						lift = originalHeight;
						main=false;
				}
		
		if (down) lift -= Time.deltaTime*1200;
		if (lift <= 0) {down = false;lift=0;main=true;}
		if (Application.platform == RuntimePlatform.Android && !up  && !down && main) {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				Application.Quit();
				}
			}
		if (Application.platform == RuntimePlatform.Android && !up  && !down && !main) {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				down=true;
			}
		}
		}
}

