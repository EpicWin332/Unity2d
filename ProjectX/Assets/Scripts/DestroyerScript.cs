﻿using UnityEngine;
using System.Collections;

public class DestroyerScript : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			audio.Play();
			CameraScript.dead=true;
		}
		if ((other.gameObject.transform.parent) && (other.tag != "Player"))
		{

			Destroy (other.gameObject.transform.parent.gameObject);
		}
		else
		{
		if (other.tag != "Player")
			Destroy (other.gameObject);
		}
	}

}
