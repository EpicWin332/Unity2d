using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour {

	float playerScore = 0;
	float originalWidth = 720f;  // define here the original resolution
	float originalHeight = 1280f; // you used to create the GUI contents 
	private Vector3 scale;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		playerScore += Time.deltaTime;
	
	}

	public void IncreaseScore(int amount)
	{
		playerScore += amount;
	}

	void onGUI()
	{
		/*scale.x = Screen.width / originalWidth; // calculate hor scale
		scale.y = Screen.height / originalHeight; // calculate vert scale
		scale.z = 1;
		var svMat = GUI.matrix; // save current matrix
		// substitute matrix - only scale is altered from standard
		GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, scale);
		// draw your GUI controls here:
		GUIStyle myStyle = new GUIStyle (GUI.skin.box);
		//myStyle.fontSize = 50;
		myStyle.normal.textColor = Color.black;*/
		GUI.Label (new Rect (10, 10, 100, 30), "sad" + (int)playerScore); 
		//GUI.matrix = svMat; // restore matrix
	}
}
