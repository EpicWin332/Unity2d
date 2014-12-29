using UnityEngine;
using System.Collections;

public class musicScript : MonoBehaviour {

	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}
	
	void Start()
	{
		audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
