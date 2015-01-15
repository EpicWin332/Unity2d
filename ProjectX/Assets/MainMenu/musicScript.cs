using UnityEngine;
using System.Collections;

public class musicScript : MonoBehaviour {
	public GoogleAnalyticsV3 googleAnalytics;

	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}
	
	void Start()
	{
		audio.Play();
		googleAnalytics.LogScreen("Main Menu");
	}
	
	// Update is called once per frame
	void Update () {
		// Reports that the user is viewing the Main Menu
		if (GoogleAnalyticsV3.instance)
			GoogleAnalyticsV3.instance.LogScreen("Start App");

	}
}
