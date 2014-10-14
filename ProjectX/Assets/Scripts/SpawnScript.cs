using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour 
{
	public GameObject[] obj;
	public float SpawnMin =1f;
	public float SpawnMax = 1.5f;
	public float x,y;
	public float a=600f;
	public float tao=0.0223f;
	public float g1,g2;
	public int switchcase=2;
	public bool counter=true;
	// Use this for initialization
	void Start () 
	{
		//начальное положение генерируемой платформы
		x = 2.5f;
		y = -1f;
		g1 = a * a * tao * tao / (-60);
		g2 = 2 * 5*(600+30)*tao/30;
		//Spawn ();
	}
	void Update()
	{
		//rigidbody2D.position = new Vector2 (2, -1);
		System.Random rnd = new System.Random ();
		switch(switchcase)
		{
			case 1:
				if(Input.GetButtonDown("Fire1"))
					Instantiate (obj [0], new Vector2(3.08f-3.3f+5f*0.61f,1f), Quaternion.identity);//учесть положение пацана
				switchcase=1;
				break;
			case 2:
				//Instantiate (obj [1], new Vector2(-100f,-100f), Quaternion.identity);
				switchcase=1;
				break;
			default:
			break;
		}
			
			//Invoke ("Spawn", Random.Range (SpawnMin,SpawnMax));
		//если количество spawn элементов становится большим, то нужно прекратить генерацию
		//нужно генерировать такие платформы, дельта, которых по x и y была бы от [
		/*if (rnd.Next (0, 2) == 1)
						x = x + 1f;
				else
						x = x + 2f;
		if ((y<=-4) || counter)
		{
			y =y+2;
			counter=false;
		}
		else
		{
			y =y-rnd.Next (2,4);
			counter=true;
		}*/
	}

}
