using UnityEngine;
using System.Collections;

public class DestroyerScript : MonoBehaviour 
{
	public AudioClip death;
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			audio.clip=death;
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
