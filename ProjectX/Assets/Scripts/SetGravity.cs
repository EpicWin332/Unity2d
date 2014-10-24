using UnityEngine;
using System.Collections;

public class SetGravity : MonoBehaviour {
	private PlatformerCharacter2D character;
	System.Random rnd;
	// Use this for initialization
	void Awake()
	{
		character = GetComponent<PlatformerCharacter2D>();
	}

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	 rnd = new System.Random ();
		if (character.getGrounded()) {
			character.setJumpForce(rnd.Next(300,1300));	
		}
	}
}
