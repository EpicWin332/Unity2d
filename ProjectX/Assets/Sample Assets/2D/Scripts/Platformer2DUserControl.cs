using UnityEngine;

[RequireComponent(typeof(PlatformerCharacter2D))]
public class Platformer2DUserControl : MonoBehaviour 
{
	private PlatformerCharacter2D character;
    private bool jump;
	public Texture2D pauseImage;


	void Awake()
	{
		character = GetComponent<PlatformerCharacter2D>();
	}

    void Update ()
    {
        // Read the jump input in Update so button presses aren't missed.
#if CROSS_PLATFORM_INPUT
        if (CrossPlatformInput.GetButtonDown("Jump")) jump = true;
#else
		if (!CameraScript.visible && Input.GetButtonDown("Fire1")&&!((Input.mousePosition.x>Camera.main.pixelWidth-pauseImage.width-2)&&
		                                    (Input.mousePosition.y>Camera.main.pixelHeight-pauseImage.height))) jump = true;
#endif
    }

	void FixedUpdate()
	{
		// Read the inputs.
		//bool crouch = Input.GetKey(KeyCode.LeftControl);
		//#if CROSS_PLATFORM_INPUT
		//float h = CrossPlatformInput.GetAxis("Horizontal");
		//#else
		//float h = Input.GetAxis("Horizontal");
		//#endif

		// Pass all parameters to the character control script.
		character.Move( 0, false , jump );

        // Reset the jump input once it has been used.
	    jump = false;
	}
}
