using UnityEngine;
using System.Collections;
//using MovePlatform.cs;
public class GroundSpawn : MonoBehaviour
{
public GameObject[] obj;
public GameObject startPlatform, clone1,oxygen,oxyclone,player;
public float y0, firstY = 1f, x0 = 0, x; //squareEquation
public float standOfNull, halfLengthOfGreat=2.2f,halfLengthOfMiddle=0.8f,halfLengthOfMini=0.3f;
public float gravity =30f, tao=0.02f, t1,t2,force, extremum,platSpeed=-1*MovePlatform.maxSpeed,oxyCloneLen;
public int switchcase = 1, next, prev,prevSize,nextSize, letSlide=0;
public int[] values = new int[15] {0,0,1,1,2,3,3,4,4,5,6,6,7,7,8};//0-great 1-mini 2-mini
//int[] values = new int[5] {2,2,2,2,2};
public int counter;
	bool flag = true;
//-gt^2/2+a*tao*t+(y0-a*tao^2/2-y)=0


protected float SquareEquationSmall (float y0, float y, int force)
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


public float setStandofNull(int value)
{
		if ((value==0)||(value==3)||(value==6))
			return 1f;
		if ((value==1)||(value==4)||(value==7))
			return 1f;
		if ((value==2)||(value==5)||(value==8))
			return 0.7f;
		return 0;
}
int setSize(int value)
{
		if ((value==0)||(value==3)||(value==6))
			return 0;
		if ((value==1)||(value==4)||(value==7))
			return 1;
		if ((value==2)||(value==5)||(value==8))
			return 2;
		return 0;
}
float setExtr(int value)
{
		if ((value==0)||(value==1)||(value==2))
			return 4f;
		if ((value==3)||(value==4)||(value==5))
			return 2.2f;
		if ((value==6)||(value==7)||(value==8))
			return 0.9f;
		return 0;
}
void LetClone (ref GameObject clone, ref float y)
{
		System.Random rnd = new System.Random ();

		//print(t1);

		//if ((y>3f) && (letSlide!=3))
		/*{
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
		*/
		if (clone.rigidbody2D.position.x < 4f) {
			t1 = SquareEquationSmall (y0, y, obj [prev].GetComponent<Gravity> ().getGravity ());
			/*if (float.IsNaN(t1))
			{
				t1=0.5f;
				if ((y0+extremum)>4f)
					y=y0-Random.Range(extremum/2,extremum)-standOfNull;
				else 
					y=y0+Random.Range(extremum/2,extremum)-standOfNull; 
			}//ГЕНЕРИРУЕМ ДО ТОГО КАК ОН БУДЕТ В УКАЗАННОЙ ТОЧКЕ */
			prevSize=setSize(prev);

			switch (prevSize) {
			case 0:
				next = rnd.Next (0, values.Length);
				next = values [next];
				nextSize=setSize(next);
				if (nextSize == 0) {

					clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x+ Random.Range(halfLengthOfGreat,2*halfLengthOfGreat) + platSpeed * t1, y), Quaternion.identity) as GameObject; //5-скорость платформы
					//clone2 = Instantiate (tinies[2], new Vector2 (clone.rigidbody2D.position.x+ Random.Range(halfLengthOfGreat,2*halfLengthOfGreat) + platSpeed * t1+0.5f, y-0.5f), Quaternion.identity) as GameObject;
					
				}
				if (nextSize == 1) {
					clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + Random.Range (halfLengthOfGreat, halfLengthOfGreat+halfLengthOfMiddle) + platSpeed * t1, y), Quaternion.identity) as GameObject;

				}
				if (nextSize == 2) {
					clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + Random.Range (halfLengthOfGreat, halfLengthOfGreat+halfLengthOfMini) + platSpeed * t1, y), Quaternion.identity) as GameObject;

				}


				prev=next;
				extremum=setExtr(prev);
				break;
			case 1:
				next = rnd.Next (0, values.Length);
				next = values [next];
				nextSize=setSize(next);
				if (nextSize == 0) {
					clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + Random.Range (halfLengthOfMiddle, halfLengthOfMiddle+halfLengthOfGreat)  + platSpeed * t1, y), Quaternion.identity) as GameObject;
				}
				if (nextSize == 1) {
					clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + Random.Range (halfLengthOfMiddle, 2*halfLengthOfMiddle) + platSpeed * t1, y ), Quaternion.identity) as GameObject;
				}
				if (nextSize == 2) {
					clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x +Random.Range (halfLengthOfMiddle,halfLengthOfMiddle+halfLengthOfMini) + platSpeed * t1, y ), Quaternion.identity) as GameObject;
				}
				prev = next;
				extremum=setExtr(prev);
				
				break;
			case 2:
				next = rnd.Next (0, values.Length);
				next = values [next];
				nextSize=setSize(next);
				if (nextSize == 0) {
					clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + Random.Range (halfLengthOfMini, halfLengthOfMini+halfLengthOfGreat) + platSpeed * t1, y ), Quaternion.identity) as GameObject;
				}
				if (nextSize == 1) {
					clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x + Random.Range (halfLengthOfMini, halfLengthOfMini+halfLengthOfMiddle) + platSpeed * t1, y ), Quaternion.identity) as GameObject;
				}
				if (nextSize == 2) {
					clone = Instantiate (obj [next], new Vector2 (clone.rigidbody2D.position.x+Random.Range(halfLengthOfMini, 2*halfLengthOfMini) + platSpeed * t1, y ), Quaternion.identity) as GameObject;
				}

				prev=next;
				extremum=setExtr(prev);
				break;
			default:
				break;
			}
			y0 = y;
			y=Random.Range(-2f,y0+extremum)-setStandofNull(next);
			if (y>4f)
				y=y-1f;
			//if (extremum==4f)
				//y = Random.Range (-3f,4f)-setStandofNull(next);// В УРАВНЕНИИ НЕТ ОШИБОК! (-1f,y0+extr) y0 может стать тупо меньше первого аргумента
			counter = rnd.Next(0, 5);
		}



}
void oxygenClone(ref GameObject oxyclone, ref float y)
{
	if (counter == 1)
	{
		if ((next==0)|| (next==3) ||(next==6))
				oxyCloneLen=halfLengthOfGreat;
			else oxyCloneLen=0f;
		oxyclone = Instantiate (oxygen, new Vector2 (clone1.rigidbody2D.position.x+Random.Range(-oxyCloneLen,oxyCloneLen),clone1.rigidbody2D.position.y+Random.Range(1f,2f)), Quaternion.identity) as GameObject;
		
		counter=0;
	}
	if (oxyclone != null) {
						if (Mathf.Pow (player.transform.position.x - oxyclone.transform.position.x, 2f) + Mathf.Pow (player.transform.position.y - oxyclone.transform.position.y, 2f) <= 0.25f) {
								oxyclone.GetComponent<SpriteRenderer> ().enabled = false;
								if (flag) {
					if(CameraScript.barDisplay < 100)
										CameraScript.barDisplay = 0;
					else
						CameraScript.barDisplay -= 100;
										flag = false;
								}
						}
			if (!(Mathf.Pow (player.transform.position.x - oxyclone.transform.position.x, 2f) + Mathf.Pow (player.transform.position.y - oxyclone.transform.position.y, 2f) <= 0.25f)) 
				flag=true;
			}
}
protected void Start ()
{	
	
	platSpeed = -1 * MovePlatform.maxSpeed;
	t1=0;
	System.Random rnd = new System.Random ();
	if (startPlatform.transform.position.x < 3.5f) {
			t1 = SquareEquationSmall (y0, firstY,600);
			next = rnd.Next (0, values.Length);
			next = values [next];
			clone1 = Instantiate (obj [next], new Vector2 (3.478378f * 2f + platSpeed * t1, firstY - setStandofNull(next)), Quaternion.identity) as GameObject;
			//oxyclone = Instantiate (oxygen, new Vector2 (clone1.rigidbody2D.position.x,clone1.rigidbody2D.position.y+1f), Quaternion.identity) as GameObject;
			
			prev = next;
			y0 = firstY - setStandofNull(next);//character.rigidbody2D.position.y-0.3f;//берет координаты в середине человека поэтому -0.3
			firstY = 1f-setStandofNull(next);
	}
		flag = true;
}

 void Update ()
	{

		platSpeed = -1 * MovePlatform.maxSpeed;
		LetClone (ref clone1, ref firstY);
		oxygenClone (ref oxyclone, ref firstY);
		
		//oxyclone = Instantiate (oxygen, new Vector2 (clone1.rigidbody2D.position.x,clone1.rigidbody2D.position.y+1f), Quaternion.identity) as GameObject;
		
	}

}
