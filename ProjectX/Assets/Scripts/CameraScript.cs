using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public GameObject targetObject;
	public Texture2D buttonTexture;
	public Texture2D playTexture;
	public Texture2D homeTexture;
	static public bool visible=false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float targetObjectX = targetObject.transform.position.x;
		
		Vector3 newCameraPosition = transform.position;
		newCameraPosition.x = targetObjectX+2;
		transform.position = newCameraPosition;

		if (Application.platform == RuntimePlatform.Android) {
						if (Input.GetKey (KeyCode.Escape)) {
				             if (Time.timeScale == 1f)
				                {
					            Time.timeScale = 0f;
					            visible=true;	}
				             else {
					            Time.timeScale = 1f;
					            visible=false;
				                  }

				//Application.LoadLevel (0);
								//return;
						}
				}
	}

	void OnGUI(){

		GUIStyle myStyle = new GUIStyle(GUI.skin.box);
		myStyle.fontSize = 24;
		// Make a background box
		if(visible)
		GUI.Box(new Rect(camera.pixelWidth / 2 - playTexture.width-25-30,camera.pixelHeight / 2 - playTexture.height / 2-30
		                 ,playTexture.width+homeTexture.width+50+60,playTexture.height+60), "Pause",myStyle);

		if (GUI.Button 
		    (new Rect (camera.pixelWidth - buttonTexture.width-2, 0  
		           ,buttonTexture.width, buttonTexture.height), buttonTexture, GUIStyle.none)) 
			
		{
			//if (Time.timeScale == 1f)
			Time.timeScale = 0f;
			visible=true;
		}
			//else
			//	Time.timeScale = 1f;
		if (visible) {
						if (GUI.Button 
			                          (new Rect (camera.pixelWidth / 2 - playTexture.width-25, camera.pixelHeight / 2 - playTexture.height / 2   
			                              , playTexture.width, playTexture.height), playTexture, GUIStyle.none)) 
			            {
								Time.timeScale = 1f;
								visible = false;
						}
			if (GUI.Button 
			    (new Rect ((camera.pixelWidth / 2) + 25, camera.pixelHeight / 2 - homeTexture.height / 2   
			           , homeTexture.width, homeTexture.height), homeTexture, GUIStyle.none)) 
			{
				Time.timeScale = 1f;
				visible = false;
				Application.LoadLevel(0);
				return;
			}
				}
			//Application.LoadLevel(0);
			//return;
		//}
	
	}
}