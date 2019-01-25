using UnityEngine;
using System.Collections;

public class ClickDice : MonoBehaviour {
	public int random;
	public int value = 0;
	
	public void OnMouseDown()
	{
		Debug.Log("clickDice");
		random = Random.Range(1, 7); //클릭했을 시 1 ~ 6 사이 중 하나의 값이 랜덤으로 random 변수에 저장된다.
		
		switch(random)
		{
		case 1:
			transform.rotation = Quaternion.Euler(0F, 180F, 0F);
			value = 1;
			break;
		case 2:
			transform.rotation = Quaternion.Euler(0F, -90F, -90F);
			value = 2;
			break;
		case 3:
			transform.rotation = Quaternion.Euler(-90F, -90F, -360F);
			value = 3;
			break;
		case 4:
			transform.rotation = Quaternion.Euler(90F, 90F, 0F);
			value = 4;
			break;
		case 5:
			transform.rotation = Quaternion.Euler(-90F, 360F, -360F);
			value = 5;
			break;
		case 6:
			transform.rotation = Quaternion.Euler(0F, 0F, -90F);
			value = 6;
			break;
		}
	}
}
