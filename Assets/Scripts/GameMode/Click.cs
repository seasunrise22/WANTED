using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour
{	
	public enum UseCheck
	{
		Use,
		No
	}
	
	public PlayerTypes userType; //현재 카드를 소유자가 유저인지 컴퓨터인지 구분
	public CardTypes cardType; //어떤 카드인지 구분하기 위한 변수
	public SlotTypes slotType;
	public UseCheck useCheck = UseCheck.No; //useCheck 변수의 초기값은 No 이다
	
	public void OnMouseDown()
	{
		End_Turn endTurn = GameObject.Find ("ReadyButtonUI").GetComponent ("End_Turn") as End_Turn;
		Debug.Log("Call OnMouseDown");
		InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
		InfoManager.DynamicZGap -= 1;
		if (useCheck == UseCheck.No)
		{
			UserManager userManager = GameObject.Find ("UserManager").GetComponent<UserManager> ();
			ComManager comManager = GameObject.Find ("ComManager").GetComponent<ComManager> ();
			
			if (infoManager.userState == UserState.User) 
			{						
				if (userType == PlayerTypes.User) //InfoManager에서 PlayerType을 user로 부여받았다면 
				{					
					transform.parent = GameObject.Find ("UseCard").transform;
					transform.position = UsePosition (userType); //UserBoard의 포지션 값을 사용한다.
					
					User_onClick (); //각 카드 프리펩에 붙어있는 개별 스크립트의 User_OnClick 함수를 호출한다.
					useCheck = UseCheck.Use; //이 카드는 사용 된 카드라는 표시
				}
			} 
			
			else 
			{
				if (userType == PlayerTypes.Computer_1) //InfoManager에서 PlayerType을 Computer_1로 부여받았다면 
				{				
					transform.parent = GameObject.Find ("UseCard").transform;
					transform.position = UsePosition (userType); //ComBoard의 포지션 값을 사용한다.
					
					Com_onClick (); //각 카드 프리펩에 붙어있는 개별 스크립트의 Com_OnClick 함수를 호출한다.
					useCheck = UseCheck.Use;
					Debug.Log (gameObject.name + " " + userType + " " + transform.position);                    
				}
			}
		}
	}
	
	public void CounterCom() //UserState가 Com일 때, 컴퓨터에 반응할 유저의 행동 제어를 위한 OnMouseDown 함수의 클론형
	{
		InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
		InfoManager.DynamicZGap -= 1;
		if (useCheck == UseCheck.No)
		{
			transform.parent = GameObject.Find ("UseCard").transform;
			transform.position = UsePosition (userType); //UserBoard의 포지션 값을 사용한다.
				
			User_onClick (); //각 카드 프리펩에 붙어있는 개별 스크립트의 User_OnClick 함수를 호출한다.
			useCheck = UseCheck.Use; //이 카드는 사용 된 카드라는 표시
		} 
	}
	
	public void activeComVoid() //UserState가 Com일 때, 컴퓨터에 반응할 유저의 행동 제어를 위한 OnMouseDown 함수의 클론형
	{
		InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
		InfoManager.DynamicZGap -= 1;
		if (useCheck == UseCheck.No)
		{
			UserManager userManager = GameObject.Find ("UserManager").GetComponent<UserManager> ();
			ComManager comManager = GameObject.Find ("ComManager").GetComponent<ComManager> ();
			
			
			transform.parent = GameObject.Find ("UseCard").transform;
			transform.position = UsePosition (userType); //UserBoard의 포지션 값을 사용한다.
			
			Com_onClick (); //각 카드 프리펩에 붙어있는 개별 스크립트의 User_OnClick 함수를 호출한다.
			useCheck = UseCheck.Use; //이 카드는 사용 된 카드라는 표시
		}
	} 
	
	public virtual void User_onClick () {}
	public virtual void Com_onClick () {}
	public virtual void effectStart(){}
	public virtual Vector3 UsePosition(PlayerTypes playerType) {
		return Vector3.zero;
	}
}
