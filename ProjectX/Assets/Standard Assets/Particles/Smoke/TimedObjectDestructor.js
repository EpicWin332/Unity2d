var timeOut = 1f;
var detachChildren = false;

function Awake ()
{
	Invoke ("DestroyNow", timeOut);
}

function DestroyNow ()
{
	if (detachChildren) {
		transform.DetachChildren ();
	}
	//DestroyObject (gameObject);
	gameObject.particleEmitter.enabled=false;
	print(gameObject.particleEmitter.enabled);
}