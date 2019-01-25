using UnityEngine;
using System.Collections;

public class Prison_Click : Click
{
	public override void User_onClick ()
	{
		End_Turn endTurn = GameObject.Find ("ReadyButtonUI").GetComponent ("End_Turn") as End_Turn;
		InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
		
		if(infoManager.ComManagerScript.Prison_Com == null)
		{
			switch(slotType)
			{
			case SlotTypes.SlotA: 
				infoManager.ComManagerScript.Prison_Com = infoManager.UserManagerScript.DrawCard[0];
				infoManager.UserManagerScript.DrawCard[0] = null;
				break;
			case SlotTypes.SlotB: 
				infoManager.ComManagerScript.Prison_Com = infoManager.UserManagerScript.DrawCard[1];
				infoManager.UserManagerScript.DrawCard[1] = null;
				break;
			case SlotTypes.SlotC: 
				infoManager.ComManagerScript.Prison_Com = infoManager.UserManagerScript.DrawCard[2];
				infoManager.UserManagerScript.DrawCard[2] = null;
				break;
			case SlotTypes.SlotD: 
				infoManager.ComManagerScript.Prison_Com = infoManager.UserManagerScript.DrawCard[3];
				infoManager.UserManagerScript.DrawCard[3] = null;
				break;
			}
		}
		
		else
		{
			switch (slotType)
			{
			case SlotTypes.SlotA: infoManager.UserManagerScript.DrawCard[0] = null; break;
			case SlotTypes.SlotB: infoManager.UserManagerScript.DrawCard[1] = null; break;
			case SlotTypes.SlotC: infoManager.UserManagerScript.DrawCard[2] = null; break;
			case SlotTypes.SlotD: infoManager.UserManagerScript.DrawCard[3] = null; break;
			}
		}
	}
	
	public override void Com_onClick ()
	{
		End_Turn endTurn = GameObject.Find ("ReadyButtonUI").GetComponent ("End_Turn") as End_Turn;
		InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
		
		//컴퓨터가 감옥카드를 나한테 쓴 경우
		Debug.Log("Use Prison Card");
		if(infoManager.UserManagerScript.Prison_User == null)
		{
			switch(slotType) //슬롯넘버를 탐색해서 UserManager의 Prison_User 변수에 넣는다.
			{
			case SlotTypes.SlotA: 
				infoManager.UserManagerScript.Prison_User = infoManager.ComManagerScript.DrawCard[0];
				infoManager.ComManagerScript.DrawCard[0] = null;
				break;
			case SlotTypes.SlotB: 
				infoManager.UserManagerScript.Prison_User = infoManager.ComManagerScript.DrawCard[1];
				infoManager.ComManagerScript.DrawCard[1] = null;
				break;
			case SlotTypes.SlotC: 
				infoManager.UserManagerScript.Prison_User = infoManager.ComManagerScript.DrawCard[2];
				infoManager.ComManagerScript.DrawCard[2] = null;
				break;
			case SlotTypes.SlotD: 
				infoManager.UserManagerScript.Prison_User = infoManager.ComManagerScript.DrawCard[3];
				infoManager.ComManagerScript.DrawCard[3] = null;
				break;
			}
		}
		
		else
		{
			switch (slotType)
			{
			case SlotTypes.SlotA: infoManager.ComManagerScript.DrawCard[0] = null; break;
			case SlotTypes.SlotB: infoManager.ComManagerScript.DrawCard[1] = null; break;
			case SlotTypes.SlotC: infoManager.ComManagerScript.DrawCard[2] = null; break;
			case SlotTypes.SlotD: infoManager.ComManagerScript.DrawCard[3] = null; break;
			}
		}
		
		endTurn.StartCoroutine("comAI");
	}
	
	public override Vector3 UsePosition (PlayerTypes playerType)
	{
		if (playerType == PlayerTypes.User)
			return new Vector3(0f, 1.6f, InfoManager.DynamicZGap);
		else
			return new Vector3(0f, -1.2f, InfoManager.DynamicZGap);
	}
}