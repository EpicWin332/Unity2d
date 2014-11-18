using UnityEngine;

[RequireComponent(typeof(PlatformerCharacter2D))]
public class Platformer2DUserControl : MonoBehaviour 
{
	private PlatformerCharacter2D character;
    private bool jump, swipe;
	public Texture2D pauseImage;
	public GameObject smoke;
	public float timeOut = 0.2f;

	float MinSwipeDistance = 15f;
	float SwipeAllowedVariance = 0.8f;
	bool trackSwipe = false;
	Vector2 firstPressPos, secondPressPos;
	Vector3 currentSwipe;

	void Awake()
	{
		character = GetComponent<PlatformerCharacter2D>();
		smoke.particleEmitter.emit=false;
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
			//clone=Instantiate (smoke, pos.transform.position, Quaternion.identity) as GameObject;
		//	smoke.particleEmitter.emit=true;
			//Invoke ("DestroyNow", timeOut);
			//print(Input.mousePosition.x);
			//print(Input.mousePosition.y);
		}
#endif
		//print (PlatformerCharacter2D.flag);
		if (PlatformerCharacter2D.flag == 1) {
						if (rigidbody2D.velocity.y > 0.5f)
								smoke.particleEmitter.emit = true;
						else{
								smoke.particleEmitter.emit = false;
				                PlatformerCharacter2D.flag=0;
			                }
				}
		if (PlatformerCharacter2D.flag == 2) {
			if (rigidbody2D.velocity.y < -0.5f)
				smoke.particleEmitter.emit = true;
			else{
				smoke.particleEmitter.emit = false;

				PlatformerCharacter2D.flag=0;
			    }
		}
		//if(clone)
		//clone.transform.position = pos.transform.position;
	   
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

	void DestroyNow ()
	{
		//DestroyObject (gameObject);
		smoke.particleEmitter.emit=false;
		//print(gameObject.particleEmitter.enabled);
	}
}
