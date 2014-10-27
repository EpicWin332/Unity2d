using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour
{
	public int gravity; 
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

	public int getGravity()
	{
		return gravity;
	}

	public void setGravity(int gravity)
	{
		this.gravity = gravity;
	}
}

