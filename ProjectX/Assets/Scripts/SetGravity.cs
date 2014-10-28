using UnityEngine;
using System.Collections;

public class SetGravity : MonoBehaviour {
	private PlatformerCharacter2D character;
	private static float gravity=0;
	// Use this for initialization
	void Awake()
	{
		character = GetComponent<PlatformerCharacter2D>();
	}

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
			character.setJumpForce(gravity);
	}

	public static float getGravity(){
		return gravity;
	}

	public static void setGravity(float newGravity)
	{
		gravity = newGravity;
	}


}
