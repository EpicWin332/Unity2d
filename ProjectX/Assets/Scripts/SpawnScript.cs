using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour
{
		public GameObject[] obj;
		public GameObject startPlatform, clone;
		public float y0 = 0, y = 1, t1; //squareEquation
		public int switchcase = 1;
		public bool counter = true;
		bool flag = true;

		float SquareEquation (float y0, float y)
		{
				float t2;
				t1 = (-12f + Mathf.Sqrt (12f * 12f + 4f * 15f * (y0 - y))) / (-30f);
				t2 = (-12f - Mathf.Sqrt (12f * 12f + 4f * 15f * (y0 - y))) / (-30f);
				if (t1 > t2)
						return t1;
				else {
						t1 = t2;
						return t1;
				}
		}

		void Start ()
		{
		        clone=Instantiate (obj [2], new Vector2 (5f, 1.5f), Quaternion.identity) as GameObject;
				//y0 = 1.5f;

		}

		void Update ()
		{
				/*if (flag) {
			            clone=Instantiate (obj [2], new Vector2 (5f, 1.5f), Quaternion.identity) as GameObject;
						flag = false;
				}*/
				//rigidbody2D.position = new Vector2 (2, -1);
				switch (switchcase) {
				case 1:

				
						{
					
			
								t1 = SquareEquation (y0, y);
								if (clone.rigidbody2D.position.x < 0F)
										Instantiate (obj [2], new Vector2 (5f * t1, y - 0.7f), Quaternion.identity);//ставит платформу относительно её середины
								y0 = y - 0.3f;//character.rigidbody2D.position.y-0.3f;//берет координаты в середине человека поэтому -0.3
								y = Random.Range (-1f, 5f); 
								while (y-y0>2.3F)//область в которой функция будет иметь вещественные корни
										y = Random.Range (-1F, 5F);

								//print(t1);//учесть положение пацана
						}
						switchcase = 1;
						break;
				case 2:
				//Instantiate (obj [1], new Vector2(-100f,-100f), Quaternion.identity);
						switchcase = 1;
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
