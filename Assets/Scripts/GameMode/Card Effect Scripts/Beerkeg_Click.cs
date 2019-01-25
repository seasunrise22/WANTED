using UnityEngine;
using System.Collections;

public class Beerkeg_Click : Click
{
	public override void User_onClick ()
	{
		InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
		End_Turn endTurn = GameObject.Find ("Button").GetComponent<End_Turn> ();
		infoManager.UserManagerScript.userSetState = UserSetState.On; //userSetState 변수의 상태를 On으로 변경한다.
		
		//술통카드 클릭했을 경우
		if(cardType == CardTypes.Beerkeg)
		{
			switch(slotType) //슬롯넘버를 탐색해서 UserManager의 nowSettingCard 변수에 넣는다.
			{
			case SlotTypes.SlotA:
                    infoManager.UserManagerScript.nowSettingCard = infoManager.UserManagerScript.DrawCard[0];
                    infoManager.UserManagerScript.DrawCard[0] = null;
				break;
			case SlotTypes.SlotB:
                    infoManager.UserManagerScript.nowSettingCard = infoManager.UserManagerScript.DrawCard[1];
                    infoManager.UserManagerScript.DrawCard[1] = null;
				break;
			case SlotTypes.SlotC:
                    infoManager.UserManagerScript.nowSettingCard = infoManager.UserManagerScript.DrawCard[2];
                    infoManager.UserManagerScript.DrawCard[2] = null;
				break;
			case SlotTypes.SlotD:
                    infoManager.UserManagerScript.nowSettingCard = infoManager.UserManagerScript.DrawCard[3];
                    infoManager.UserManagerScript.DrawCard[3] = null;
				break;
			}
		}
	}
	
	public override void Com_onClick ()
	{
		InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
		End_Turn endTurn = GameObject.Find ("ReadyButtonUI").GetComponent ("End_Turn") as End_Turn;

		infoManager.ComManagerScript.comSetState = ComSetState.On; //comSetState 변수의 상태를 On으로 변경한다.
		
		switch(slotType) //슬롯넘버를 탐색해서 ComManager의 nowSettingCard 변수에 넣는다.
		{
		case SlotTypes.SlotA: 
			infoManager.ComManagerScript.nowSettingCard = infoManager.ComManagerScript.DrawCard[0];
			infoManager.ComManagerScript.DrawCard[0] = null;
			break;
		case SlotTypes.SlotB: 
			infoManager.ComManagerScript.nowSettingCard = infoManager.ComManagerScript.DrawCard[1];
			infoManager.ComManagerScript.DrawCard[1] = null;
			break;
		case SlotTypes.SlotC: 
			infoManager.ComManagerScript.nowSettingCard = infoManager.ComManagerScript.DrawCard[2];
			infoManager.ComManagerScript.DrawCard[2] = null;
			break;
		case SlotTypes.SlotD: 
			infoManager.ComManagerScript.nowSettingCard = infoManager.ComManagerScript.DrawCard[3];
			infoManager.ComManagerScript.DrawCard[3] = null;
			break;
		}
		StartCoroutine(endTurn.comAI());
	}
	
	public override Vector3 UsePosition (PlayerTypes playerType)
	{
		if (playerType == PlayerTypes.User)
			return new Vector3(-2.0f, -1.2f, InfoManager.DynamicZGap);
		else
			return new Vector3(-2.0f, 1.6f, InfoManager.DynamicZGap);
	}
}