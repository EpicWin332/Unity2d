using UnityEngine;
using System.Collections;

public class MovePlatform : MonoBehaviour {

	//переменная для установки макс. скорости платфоормы
	public float maxSpeed = -5f;
	public float endPosition = -12f;
	//public GameObject targetObject;


	// Use this for initialization
	void Start () {
	
	}
	private void FixedUpdate()
	{
		rigidbody2D.velocity = new Vector2(maxSpeed,0);
	}
	// Update is called once per frame
	void Update () {
//		Random rand1 = new Random(-2,2);
		//float targetObjectX = targetObject.transform.position.x;
		//System.Random rnd = new System.Random ();
		//int posY = rnd.Next(-2,2);
		/*if (rigidbody2D.position.x < targetObjectX+endPosition) {
		    		
			rigidbody2D.position = new Vector2(10.5f, posY);
		}*/
	
	}
}