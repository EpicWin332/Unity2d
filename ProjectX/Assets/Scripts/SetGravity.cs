using UnityEngine;
using System.Collections;

public class SetGravity : MonoBehaviour {
	private PlatformerCharacter2D character;
	private static float gravity=600;
	// Use this for initialization
	void Awake()
	{
		character = GetComponent<PlatformerCharacter2D>();
	}

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (gravity != character.getJumpForce ()) {
						character.setJumpForce (gravity);
				}

	}

	public static float getGravity(){
		return gravity;
	}

	public static void setGravity(float newGravity)
	{
		gravity = newGravity;
	}


}
