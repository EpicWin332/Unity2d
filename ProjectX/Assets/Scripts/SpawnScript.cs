using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour 
{
	public GameObject[] obj;
	public float SpawnMin =1f;
	public float SpawnMax = 1.5f;
	public float x,y;
	public bool counter=true;
	// Use this for initialization
	void Start () 
	{
		//начальное положение генерируемой платформы
		x = 2.5f;
		y = -1f;
		Spawn ();
	}
	void Spawn()
	{

		Instantiate (obj [1], new Vector2(x,y)/*transform.position*/, Quaternion.identity);
		System.Random rnd = new System.Random ();
		Invoke ("Spawn", Random.Range (SpawnMin,SpawnMax));
		//если количество spawn элементов становится большим, то нужно прекратить генерацию
		//нужно генерировать такие платформы, дельта, которых по x и y была бы от [
		if (rnd.Next (0, 2) == 1)
						x = x + 1f;
				else
						x = x + 2f;
		if ((y<=-5) || counter)
		{
			y =y+2;
			counter=false;
		}
		else
		{
			y =y-rnd.Next (2,4);
			counter=true;
		}
	}

}
