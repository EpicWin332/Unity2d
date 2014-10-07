using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public GameObject targetObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float targetObjectX = targetObject.transform.position.x;
		
		Vector3 newCameraPosition = transform.position;
		newCameraPosition.x = targetObjectX+2;
		transform.position = newCameraPosition;
	}
}
