using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour
{
public GameObject[] obj;
public GameObject startPlatform, clone, clone1;
public float y0 = -0.4f, sY, firstY = 1f, secondY = -2f, t1, x0 = 0, x, funRecord; //squareEquation
public int switchcase = 1, next, prev;
int[] values = new int[5] {0,0,1,1,2};
public bool counter = true;

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
	sY = y0;
	if (Random.Range (0, 1) == 1) {
			t1 = SquareEquationBig (y0, firstY);
			funRecord = 5F;
	} else {
			t1 = SquareEquationSmall (y0, firstY);
			funRecord = 2.3f;
	}
	System.Random rnd = new System.Random ();
	if (startPlatform.transform.position.x < 3.5f) {
			t1 = SquareEquationSmall (y0, firstY);
			next = rnd.Next (0, values.Length);
			next = values [next];
			clone = Instantiate (obj [next], new Vector2 (3.478378f * 2f + 5f * t1, firstY - 0.8f), Quaternion.identity) as GameObject;
			//clone1 = Instantiate (obj [0], new Vector2 (4 * 2f + 5f * t1, secondY - 0.8f), Quaternion.identity) as GameObject;
			prev = next;
			y0 = firstY - 0.8f;//character.rigidbody2D.position.y-0.3f;//берет координаты в середине человека поэтому -0.3
			firstY = Random.Range (0.8f, 4.5f); 
			while (firstY-y0>2.3F)//область в которой функция будет иметь вещественные корни
					firstY = Random.Range (0F, 5F);
	}

}
//void LetClone (GameObject clone);
void Update ()
{
	System.Random rnd = new System.Random ();
	t1 = SquareEquationSmall (y0, firstY);
	if (float.IsNaN(t1))
		    t1=0.4f;
	//ЗАВИСИМОСТЬ НУЖНО ДЕЛАТЬ ОТ ПРЕДЫДУЩЕЙ ПЛАТФОРМЫ!			
	if (clone.rigidbody2D.position.x < 4f) {			//ГЕНЕРИРУЕМ ДО ТОГО КАК ОН БУДЕТ В УКАЗАННОЙ ТОЧКЕ 
			switch (prev) {
			case 1:
					next = rnd.Next (0, values.Length);
					next = values [next];
					if (next == 1) {
							clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + Random.Range (2f, 5f) + 5f * t1, firstY - 0.8f), Quaternion.identity) as GameObject;
							prev = next;
							//clone1 = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + Random.Range (0f, 0.8f) + 5f * t1, secondY - 0.8f), Quaternion.identity) as GameObject;
					}
					if (next == 0) {
							clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + Random.Range (2f, 4f) + 5f * t1, firstY - 0.8f), Quaternion.identity) as GameObject;
							prev = next;
					}
					if (next == 2) {
							clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + Random.Range (1f, 3.3f) + 5f * t1, firstY - 0.8f), Quaternion.identity) as GameObject;
							prev = next;
					}
							//clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + Random.Range (1f, 3.3f) + 5f * t1, (firstY - 0.8f)), Quaternion.identity) as GameObject;
							//clone1 = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + Random.Range (1f, 3.3f) + 5f * t1, (secondY - 0.8f)), Quaternion.identity) as GameObject;
					break;
			//ставит платформу относительно её середины
			case 0:
					next = rnd.Next (0, values.Length);
					next = values [next];
					if (next == 1) {
							clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + Random.Range (0f, 0.8f) + Random.Range (1f, 3.3f) + 5f * t1, firstY - 0.8f), Quaternion.identity) as GameObject;
							prev = next;
							//clone1 = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + Random.Range (0f, 0.8f) + 5f * t1, secondY - 0.8f), Quaternion.identity) as GameObject;
					}
					if (next == 0) {
							clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + Random.Range (0f, 1.6f) + 5f * t1, firstY - 0.8f), Quaternion.identity) as GameObject;
							prev = next;
					}
					if (next == 2) {
							clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + 5f * t1, firstY - 0.8f), Quaternion.identity) as GameObject;
							prev = next;
					}
					break;
			case 2:
					next = rnd.Next (0, values.Length);
					next = values [next];
					if (next == 1) {
							clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + Random.Range (1f, 3.3f) + 5f * t1, firstY - 0.8f), Quaternion.identity) as GameObject;
							prev = next;
							//clone1 = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + Random.Range (0f, 0.8f) + 5f * t1, secondY - 0.8f), Quaternion.identity) as GameObject;
					}
					if (next == 0) {
							clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + Random.Range (0f, 0.8f) + 5f * t1, firstY - 0.8f), Quaternion.identity) as GameObject;
							prev = next;
					}
					if (next == 2) {
							clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + 5f * t1, firstY - 0.8f), Quaternion.identity) as GameObject;
							prev = next;
					}
					break;
			default:
					break;
			}
			y0 = firstY - 0.8f;
			firstY = Random.Range (0.8f, y0 + 2.3f);
			if (firstY > 4.5) {
					firstY = Random.Range (0.8f, y0);
			}

	}
	
}

}
