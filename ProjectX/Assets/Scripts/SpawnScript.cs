using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour
{
		public GameObject[] obj;
		public GameObject startPlatform, clone,clone1;
		public float y0 = -0.4f,sY, firstY = 1f,secondY=-2f, t1, x0 = 0, x, funRecord; //squareEquation
		public int switchcase = 1, next;
		public bool counter = true;
		bool flag = true;

		float SquareEquationBig (float y0, float y)//пока не работает двойной прыжок
		{
				float t2;
				t1 = (-2f * 12f + Mathf.Sqrt (2f * 12f * 12f + 4f * 15f * (y0 - y - 2f * 0.12f))) / (-30f);
				t2 = (-2f * 12f - Mathf.Sqrt (2f * 12f * 12f + 4f * 15f * (y0 - y - 2f * 0.12f))) / (-30f);
				if (t1 > t2)
						return t1;
				else {
						t1 = t2;
						return t1;
				}
		}

		float SquareEquationSmall (float y0, float y)
		{
				float t2;
				t1 = (-12f + Mathf.Sqrt (12f * 12f + 4f * 15f * (y0 - y - 0.12f))) / (-30f);
				t2 = (-12f - Mathf.Sqrt (12f * 12f + 4f * 15f * (y0 - y - 0.12f))) / (-30f);
				if (t1 > t2)
						return t1;
				else {
						t1 = t2;
						return t1;
				}
		}
	
		void Start ()
		{
				sY=y0;
				if (Random.Range (0, 1) == 1) {
						t1 = SquareEquationBig (y0, firstY);
						funRecord = 5F;
				} else {
						t1 = SquareEquationSmall (y0, firstY);
						funRecord = 2.3f;
				}
		}

		void Update ()
		{
				/*if (flag) {
			            clone=Instantiate (obj [2], new Vector2 (5f, 1.5f), Quaternion.identity) as GameObject;
						flag = false;
				}*/
				//rigidbody2D.position = new Vector2 (2, -1);
				if (flag)	
			    
				if (startPlatform.transform.position.x < 3.5f) {
						t1 = SquareEquationSmall (y0, firstY);
						clone = Instantiate (obj [0], new Vector2 (3.478378f * 2f + 5f * t1, firstY - 0.8f), Quaternion.identity) as GameObject;
						clone1 = Instantiate (obj [0], new Vector2 (4 * 2f + 5f * t1, secondY - 0.8f), Quaternion.identity) as GameObject;
						
						y0 = firstY - 0.8f;//character.rigidbody2D.position.y-0.3f;//берет координаты в середине человека поэтому -0.3
						firstY = Random.Range (-1f, 5f); 
						while (firstY-y0>2.3F)//область в которой функция будет иметь вещественные корни
								firstY = Random.Range (0F, 5F);
						flag = false;
				}

					
				if (!flag) {
						if (0 == 1)
								t1 = SquareEquationBig (y0, firstY);
						else
								t1 = SquareEquationSmall (y0, firstY);
						if (float.IsNaN(t1))
							{
								t1=0.3f; //костыль
							}
			//ЗАВИСИМОСТЬ НУЖНО ДЕЛАТЬ ОТ ПРЕДЫДУЩЕЙ ПЛАТФОРМЫ!			
			if (clone.rigidbody2D.position.x < 4f) {			//ГЕНЕРИРУЕМ ДО ТОГО КАК ОН БУДЕТ В УКАЗАННОЙ ТОЧКЕ 
								next =Random.Range (0, obj.Length);
								if (next == 1) {
										clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + Random.Range (1f, 3.3f) + 5f * t1, (firstY - 0.8f)), Quaternion.identity) as GameObject;
										clone1 = Instantiate (obj [next], new Vector2 (clone1.rigidbody2D.position.x + Random.Range (1f, 3.3f) + 5f * t1, (secondY - 0.8f)), Quaternion.identity) as GameObject;
										
								}//ставит платформу относительно её середины
								if (next == 0) {
										clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + Random.Range (0f, 0.8f) + 5f * t1, firstY - 0.8f), Quaternion.identity) as GameObject;
										clone1 = Instantiate (obj [next], new Vector2 (clone1.rigidbody2D.position.x + Random.Range (0f, 0.8f) + 5f * t1, secondY - 0.8f), Quaternion.identity) as GameObject;
										
								}
								if (next == 5) {
										clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x+0.2f + 5f * t1, firstY - 0.8f), Quaternion.identity) as GameObject;
								}
								y0 = firstY - 0.8f;
								sY=secondY-0.8f;
								//ОШИБКА!!!//character.rigidbody2D.position.y-0.3f;//берет координаты в середине человека поэтому -0.3
								firstY = Random.Range (0.8f, 4.5f); 
								secondY=Random.Range (-4f,0f);
								while (Mathf.Abs(firstY-y0)>funRecord){
					//область в которой функция будет иметь вещественные корни
										firstY = Random.Range (0.8f, 4.5F);
										secondY=Random.Range (-4f,0f);
								}
						}
						//y = Random.Range (y0-2.2f, y0+2f); 
				}
				
		}

}
