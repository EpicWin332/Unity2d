using UnityEngine;
using System.Collections;
//using MovePlatform.cs;
public class SpawnScript : MonoBehaviour
{
public GameObject[] obj;
public GameObject startPlatform, clone1,clone2,player;
public float y0 = -0.4f, sY, firstY = 1f, secondY = -2f, x0 = 0, x; //squareEquation
public float standOfNull=0.7f, halfLengthOfGreat=2f,halfLengthOfMiddle=0.95f,halfLengthOfMini=0.5f;
public float gravity =30f, tao=0.02f, t1,force;
public int switchcase = 1, beforePrev=0, next, prev;
int[] values = new int[5] {0,0,1,1,2}; //0-middle 1-greate 2-mini
public bool counter = true;

float SquareEquationBig (float y0, float y)//пока не работает двойной прыжок
{
	float t2;
	t1 = (-2f *12f + Mathf.Sqrt (2f * 12f * 12f + 4f * 15f * (y0 - y - 2f * 0.12f))) / (-30f);
	t2 = (-2f * 12f - Mathf.Sqrt (2f * 12f * 12f + 4f * 15f * (y0 - y - 2f * 0.12f))) / (-30f);
	if (t1 > t2)
			return t1;
	else {
			t1 = t2;
			return t1;
	}}

	// R: Использовать goto, это плохо
float SquareEquationSmall (float y0, float y, int force)//почему бы не передать y1,y2,y3 и в let clone использовать goto;
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
		// for albert
	//obj [1].GetComponent<Gravity> ().getGravity ();
	System.Random rnd = new System.Random ();
	if (startPlatform.transform.position.x < 3.5f) {
			t1 = SquareEquationSmall (y0, firstY,600);
			next = rnd.Next (0, values.Length);
			next = values [next];
			clone1 = Instantiate (obj [next], new Vector2 (3.478378f * 2f + 5f * t1, firstY - standOfNull), Quaternion.identity) as GameObject;
			//clone2 = Instantiate (obj [next], new Vector2 (3.478378f * 2f + 5f * t1, secondY - standOfNull), Quaternion.identity) as GameObject;
			
			//clone1 = Instantiate (obj [0], new Vector2 (4 * 2f + 5f * t1, secondY - 0.8f), Quaternion.identity) as GameObject;
			prev = next;
			y0 = firstY - standOfNull;//character.rigidbody2D.position.y-0.3f;//берет координаты в середине человека поэтому -0.3
			firstY = 1f;
	}

}
void LetClone (ref GameObject clone, ref float y)
{
		System.Random rnd = new System.Random ();
		t1 = SquareEquationSmall (y0, y, obj [prev].GetComponent<Gravity> ().getGravity ());
		//force = obj [prev].GetComponent<Gravity> ().getGravity ();
		print(t1);
		//SetGravity.setGravity(obj [prev].GetComponent<Gravity> ().getGravity ());
		
		//if (float.IsNaN(t1))
			//t1=0.4f;
		//ЗАВИСИМОСТЬ НУЖНО ДЕЛАТЬ ОТ ПРЕДЫДУЩЕЙ ПЛАТФОРМЫ!			
		if (clone.rigidbody2D.position.x < 4f) {			//ГЕНЕРИРУЕМ ДО ТОГО КАК ОН БУДЕТ В УКАЗАННОЙ ТОЧКЕ 
			// TODO: FOR Albert: почему-то ставится гравитация следующей платформы, а не текущей

			switch (prev) {
			case 1:
				next = rnd.Next (0, values.Length);
				next = values [next];
				if (next == 1) {
					clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x+ Random.Range(halfLengthOfGreat,2*halfLengthOfGreat) + 5f * t1, y - standOfNull), Quaternion.identity) as GameObject; //5-скорость платформы
					//prev = next;
					//clone1 = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + Random.Range (0f, 0.8f) + 5f * t1, secondY - 0.8f), Quaternion.identity) as GameObject;
				}
				if (next == 0) {
					clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + Random.Range (halfLengthOfGreat, halfLengthOfGreat+halfLengthOfMiddle) + 5f * t1, y - standOfNull), Quaternion.identity) as GameObject;
					//prev = next;
				}
				if (next == 2) {
					clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + Random.Range (halfLengthOfGreat, halfLengthOfGreat+halfLengthOfMini) + 5f * t1, y - standOfNull), Quaternion.identity) as GameObject;
					//prev = next;
				}
				// TODO: FOR Albert: почему-то ставится гравитация следующей платформы, а не текущей


				prev=next;
				//clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + Random.Range (1f, 3.3f) + 5f * t1, (firstY - 0.8f)), Quaternion.identity) as GameObject;
				//clone1 = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + Random.Range (1f, 3.3f) + 5f * t1, (secondY - 0.8f)), Quaternion.identity) as GameObject;
				break;
				//ставит платформу относительно её середины
			case 0:
				next = rnd.Next (0, values.Length);
				next = values [next];
				if (next == 1) {
					clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + Random.Range (halfLengthOfMiddle, halfLengthOfMiddle+halfLengthOfGreat)  + 5f * t1, y - standOfNull), Quaternion.identity) as GameObject;
					//prev = next;
					//clone1 = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + Random.Range (0f, 0.8f) + 5f * t1, secondY - 0.8f), Quaternion.identity) as GameObject;
				}
				if (next == 0) {
					clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + Random.Range (halfLengthOfMiddle, 2*halfLengthOfMiddle) + 5f * t1, y - standOfNull), Quaternion.identity) as GameObject;
					//prev = next;
				}
				if (next == 2) {
					clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x +Random.Range (halfLengthOfMiddle,halfLengthOfMiddle+halfLengthOfMini) + 5f * t1, y - standOfNull), Quaternion.identity) as GameObject;
					//prev = next;
				}
				// TODO: FOR Albert: почему-то ставится гравитация следующей платформы, а не текущей
				prev = next;
				break;
			case 2:
				next = rnd.Next (0, values.Length);
				next = values [next];
				if (next == 1) {
					clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + Random.Range (halfLengthOfMini, halfLengthOfMini+halfLengthOfGreat) + 5f * t1, y - standOfNull), Quaternion.identity) as GameObject;
					prev = next;
					//clone1 = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + Random.Range (0f, 0.8f) + 5f * t1, secondY - 0.8f), Quaternion.identity) as GameObject;
				}
				if (next == 0) {
					clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + Random.Range (halfLengthOfMini, halfLengthOfMini+halfLengthOfMiddle) + 5f * t1, y - standOfNull), Quaternion.identity) as GameObject;
					//prev = next;
				}
				if (next == 2) {
					clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x+Random.Range(halfLengthOfMini, 2*halfLengthOfMini) + 5f * t1, y - standOfNull), Quaternion.identity) as GameObject;
					//prev = next;
				}
				// TODO: FOR Albert: почему-то ставится гравитация следующей платформы, а не текущей

				prev=next;
				break;
			default:
				break;
			}
			y0 = y;

			y = Random.Range (y0, y0);
			//y0 = y-standOfNull;
				//if (y> 4.5f) {
					//y = Random.Range (0.8f, y0);

			/*else 
			{
				y = Random.Range (-4f, y0 + 2.3f);
				if (y< -4f) {
					y = Random.Range (-4f, y0);
				}
				if (y>-1) {
					y--;
				}*/
			//}
		}
		

}
void Update ()
{
		LetClone (ref clone1, ref firstY);
		//LetClone (ref clone2, ref secondY);
}

}
