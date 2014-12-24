using UnityEngine;
using System.Collections;

public class SetPoints : MonoBehaviour {

	public int point;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int getPoint()
	{
		return point;
	}
	
	public void setPoint(int point)
	{
		this.point = point;
	}

}
