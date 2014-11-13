using UnityEngine;

[RequireComponent(typeof(PlatformerCharacter2D))]
public class Platformer2DUserControl : MonoBehaviour 
{
	private PlatformerCharacter2D character;
    private bool jump, swipe;
	public Texture2D pauseImage;

	float MinSwipeDistance = 15f;
	float SwipeAllowedVariance = 0.8f;
	bool trackSwipe = false;
	Vector2 firstPressPos, secondPressPos;
	Vector3 currentSwipe;

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
		                                    (Input.mousePosition.y>Camera.main.pixelHeight-pauseImage.height))){
			jump = true;
			print(Input.mousePosition.x);
			print(Input.mousePosition.y);
		}
#endif
		/*if(Input.touches.Length > 0)
		{
			Touch t = Input.GetTouch(0);
			if(t.phase == TouchPhase.Began)
			{
				//save began touch 2d point
				firstPressPos = new Vector2(t.position.x,t.position.y);
			}
			if(t.phase == TouchPhase.Ended)
			{
				//save ended touch 2d point
				secondPressPos = new Vector2(t.position.x,t.position.y);
				
				//create vector from the two points
				currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
				
				//normalize the 2d vector
				currentSwipe.Normalize();
				
				//swipe upwards
				if(currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
				{
					Debug.Log("up swipe");
				}
				//swipe down
				if(currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
				{
					Debug.Log("down swipe");
					jump = true;
				}
				//swipe left
				if(currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
				{
					Debug.Log("left swipe");
				}
				//swipe right
				if(currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
				{
					Debug.Log("right swipe");
				}
			}
		}*/
		//if (!CameraScript.visible && ((Input.mousePosition.x > Camera.main.pixelWidth - pauseImage.width - 2) &&
		//				(Input.mousePosition.y > Camera.main.pixelHeight - pauseImage.height))) {
						if (Input.GetMouseButtonDown (0)) {
								//save began touch 2d point
								firstPressPos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
						}
						if (Input.GetMouseButtonUp (0)) {
								//save ended touch 2d point
								secondPressPos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
			
								//create vector from the two points
								currentSwipe = new Vector3 (secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

			if (currentSwipe.magnitude < 30f) {
                 return;
			}
								//normalize the 2d vector
								currentSwipe.Normalize ();								
								//swipe down
			            if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
				                    if(!CameraScript.visible)	
				                       swipe = true;
								}
						}
				//}

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
		character.Move( 0, false , jump, swipe);

        // Reset the jump input once it has been used.
	    jump = false;
		swipe = false;
	}
}
