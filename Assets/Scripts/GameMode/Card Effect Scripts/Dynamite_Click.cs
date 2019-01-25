using UnityEngine;
using System.Collections;

public class Dynamite_Click : Click
{
	public override void User_onClick ()
	{
		InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
        End_Turn endTurn = GameObject.Find ("ReadyButtonUI").GetComponent ("End_Turn") as End_Turn;

		if(infoManager.dynamiteState != DynamiteStates.On) //dynamiteState가 On이 아닐 경우
		{
			infoManager.dynamiteState = DynamiteStates.On; //dynamiteState를 On상태로 변경한다.
		}   
		
		//유저가 다이너마이트 카드 클릭했을 경우		
		switch(slotType) //슬롯넘버를 탐색해서 infoManager의 dynamiteSet변수에 넣는다.
		{
		case SlotTypes.SlotA: 
			infoManager.userDynamiteSet = infoManager.UserManagerScript.DrawCard[0];
			infoManager.UserManagerScript.DrawCard[0] = null;
			break;
		case SlotTypes.SlotB: 
			infoManager.userDynamiteSet = infoManager.UserManagerScript.DrawCard[1];
			infoManager.UserManagerScript.DrawCard[1] = null;
			break;
		case SlotTypes.SlotC: 
			infoManager.userDynamiteSet = infoManager.UserManagerScript.DrawCard[2];
			infoManager.UserManagerScript.DrawCard[2] = null;
			break;
		case SlotTypes.SlotD: 
			infoManager.userDynamiteSet = infoManager.UserManagerScript.DrawCard[3];
			infoManager.UserManagerScript.DrawCard[3] = null;
			break;
		}	

        StartCoroutine(endTurn.comAI());
	}
	
	public override void Com_onClick ()
	{
		InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
        End_Turn endTurn = GameObject.Find ("ReadyButtonUI").GetComponent ("End_Turn") as End_Turn;

		if(infoManager.dynamiteState != DynamiteStates.On) //dynamiteState가 On이 아닐 경우
		{
			infoManager.dynamiteState = DynamiteStates.On; //dynamiteState를 On상태로 변경한다.
		} 

		switch(slotType) 
		{
		case SlotTypes.SlotA: 
			infoManager.comDynamiteSet = infoManager.ComManagerScript.DrawCard[0];
			infoManager.ComManagerScript.DrawCard[0] = null;
			break;
		case SlotTypes.SlotB: 
			infoManager.comDynamiteSet = infoManager.ComManagerScript.DrawCard[1];
			infoManager.ComManagerScript.DrawCard[1] = null;
			break;
		case SlotTypes.SlotC: 
			infoManager.comDynamiteSet = infoManager.ComManagerScript.DrawCard[2];
			infoManager.ComManagerScript.DrawCard[2] = null;
			break;
		case SlotTypes.SlotD: 
			infoManager.comDynamiteSet = infoManager.ComManagerScript.DrawCard[3];
			infoManager.ComManagerScript.DrawCard[3] = null;
			break;
		}

        StartCoroutine(endTurn.comAI());
	}
	
	public override Vector3 UsePosition (PlayerTypes playerType)
	{
		if (playerType == PlayerTypes.User)
			return new Vector3 (2.0f, -1.2f, InfoManager.DynamicZGap);
		else
			return new Vector3(2.0f, 1.6f, InfoManager.DynamicZGap);
	}
}