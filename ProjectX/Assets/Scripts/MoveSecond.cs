﻿using UnityEngine;
using System.Collections;

public class MoveSecond : MonoBehaviour {
	
	//переменная для установки макс. скорости платфоормы
	public float maxSpeed = -5f; 
	public float endPosition = -13f;
	
	// Use this for initialization
	void Start () {
		
	}
	private void FixedUpdate()
	{
		rigidbody2D.velocity = new Vector2(maxSpeed,0);
	}
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs(rigidbody2D.velocity.x) < Mathf.Abs(maxSpeed)) {
			endPosition -= Mathf.Abs(maxSpeed - rigidbody2D.velocity.x);
		}
		if (rigidbody2D.position.x < endPosition) {
			
			rigidbody2D.position = new Vector2(10.5f, -2f);
			
		}
		
	}
}