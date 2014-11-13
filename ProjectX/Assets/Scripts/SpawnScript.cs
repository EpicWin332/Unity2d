using UnityEngine;
using System.Collections;
//using MovePlatform.cs;
public class SpawnScript : MonoBehaviour
{
public GameObject[] obj;
public GameObject startPlatform, clone1,clone2,player;
public float y0, firstY = 1f, x0 = 0, x; //squareEquation
public float standOfNull=0.3f, halfLengthOfGreat=2f,halfLengthOfMiddle=0.8f,halfLengthOfMini=0.4f;
public float gravity =30f, tao=0.02f, t1,t2,force, extremum,platSpeed=-1*MovePlatform.maxSpeed;
public int switchcase = 1, next, prev, letSlide=0;
int[] values = new int[5] {0,0,1,1,2}; //0-middle 1-greate 2-mini
public bool counter = true;
//-gt^2/2+a*tao*t+(y0-a*tao^2/2-y)=0


float SquareEquationSmall (float y0, float y, int force)
{
	float t2;
	t1 = (-force*tao + Mathf.Sqrt (Mathf.Pow(force*tao,2f) + 4f * 0.5f*gravity * (y0 - y - 0.5f*force*tao*tao))) / (-gravity);
	t2 = (-force*tao - Mathf.Sqrt (Mathf.Pow(force*tao,2f) + 4f * 0.5f*gravity * (y0 - y - 0.5f*force*tao*tao))) / (-gravity);
	if (t1 > t2)
			return t1;
	else {
			t1 = t2;
			return t1;
	}
}

void Start ()
{
	platSpeed = -1 * MovePlatform.maxSpeed;
	t1=0;
	//задаем гравитацию
	//obj [1].GetComponent<Gravity> ().getGravity ();
	System.Random rnd = new System.Random ();
	if (startPlatform.transform.position.x < 3.5f) {
			t1 = SquareEquationSmall (y0, firstY,600);
			next = rnd.Next (0, values.Length);
			next = values [next];
			clone1 = Instantiate (obj [next], new Vector2 (3.478378f * 2f + platSpeed * t1, firstY - standOfNull), Quaternion.identity) as GameObject;

			prev = next;
			y0 = firstY - standOfNull;//character.rigidbody2D.position.y-0.3f;//берет координаты в середине человека поэтому -0.3
			firstY = 1f-standOfNull;
	}

}
void LetClone (ref GameObject clone, ref float y)
{
		System.Random rnd = new System.Random ();
		t1 = SquareEquationSmall (y0, y, obj [prev].GetComponent<Gravity> ().getGravity ());
		//print(t1);
		if (float.IsNaN(t1))
		{
			t1=0.1f;
			if ((y0+extremum)>4f)
				y=y0-Random.Range(extremum/2,extremum)-standOfNull;
			else 
				y=y0+Random.Range(extremum/2,extremum)-standOfNull; 
		}
		if ((y>3f) && (letSlide!=3))
		{
			letSlide++;
			if (letSlide==3)
			{
				letSlide=0;
				y=-3f;
				t1=0.1f;
			}
			else
				letSlide++;
		}

		if (clone.rigidbody2D.position.x < 4f) {			//ГЕНЕРИРУЕМ ДО ТОГО КАК ОН БУДЕТ В УКАЗАННОЙ ТОЧКЕ 


			switch (prev) {
			case 1:
				next = rnd.Next (0, values.Length);
				next = values [next];
				if (next == 1) {
					clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x+ Random.Range(halfLengthOfGreat,2*halfLengthOfGreat) + platSpeed * t1, y), Quaternion.identity) as GameObject; //5-скорость платформы
				}
				if (next == 0) {
					clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + Random.Range (halfLengthOfGreat, halfLengthOfGreat+halfLengthOfMiddle) + platSpeed * t1, y), Quaternion.identity) as GameObject;

				}
				if (next == 2) {
					clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + Random.Range (halfLengthOfGreat, halfLengthOfGreat+halfLengthOfMini) + platSpeed * t1, y), Quaternion.identity) as GameObject;

				}


				prev=next;
				extremum=2.2f;
				break;
			case 0:
				next = rnd.Next (0, values.Length);
				next = values [next];
				if (next == 1) {
					clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + Random.Range (halfLengthOfMiddle, halfLengthOfMiddle+halfLengthOfGreat)  + platSpeed * t1, y), Quaternion.identity) as GameObject;
				}
				if (next == 0) {
					clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + Random.Range (halfLengthOfMiddle, 2*halfLengthOfMiddle) + platSpeed * t1, y ), Quaternion.identity) as GameObject;
				}
				if (next == 2) {
					clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x +Random.Range (halfLengthOfMiddle,halfLengthOfMiddle+halfLengthOfMini) + platSpeed * t1, y ), Quaternion.identity) as GameObject;
				}
				prev = next;
				extremum=3f;
				
				break;
			case 2:
				next = rnd.Next (0, values.Length);
				next = values [next];
				if (next == 1) {
					clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + Random.Range (halfLengthOfMini, halfLengthOfMini+halfLengthOfGreat) + platSpeed * t1, y ), Quaternion.identity) as GameObject;
					prev = next;
				}
				if (next == 0) {
					clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + Random.Range (halfLengthOfMini, halfLengthOfMini+halfLengthOfMiddle) + platSpeed * t1, y ), Quaternion.identity) as GameObject;
				}
				if (next == 2) {
					clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x+Random.Range(halfLengthOfMini, 2*halfLengthOfMini) + platSpeed * t1, y ), Quaternion.identity) as GameObject;
				}

				prev=next;
				extremum=4f;
				break;
			default:
				break;
			}
			y0 = y;

			y = Random.Range (-3f,4f)-standOfNull;// В УРАВНЕНИИ НЕТ ОШИБОК! (-1f,y0+extr) y0 может стать тупо меньше первого аргумента
		}
		

}
void Update ()
{
		platSpeed = -1 * MovePlatform.maxSpeed;
		LetClone (ref clone1, ref firstY);
}

}
