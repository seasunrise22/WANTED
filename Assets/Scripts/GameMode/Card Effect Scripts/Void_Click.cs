using UnityEngine;
using System.Collections;

public class Void_Click : Click
{
    public override void User_onClick ()
	{
		InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
		switch (slotType)
		{
		case SlotTypes.SlotA: infoManager.UserManagerScript.DrawCard[0] = null; break;
		case SlotTypes.SlotB: infoManager.UserManagerScript.DrawCard[1] = null; break;
		case SlotTypes.SlotC: infoManager.UserManagerScript.DrawCard[2] = null; break;
		case SlotTypes.SlotD: infoManager.UserManagerScript.DrawCard[3] = null; break;
		}

		//
    }
    
    public override void Com_onClick ()
	{
		InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
		End_Turn endTurn = GameObject.Find ("ReadyButtonUI").GetComponent ("End_Turn") as End_Turn;

		if(infoManager.userState == UserState.Com)
		{
			endTurn.StartCoroutine("comAI");
		}

		switch (slotType)
		{
		case SlotTypes.SlotA: infoManager.ComManagerScript.DrawCard[0] = null; break;
		case SlotTypes.SlotB: infoManager.ComManagerScript.DrawCard[1] = null; break;
		case SlotTypes.SlotC: infoManager.ComManagerScript.DrawCard[2] = null; break;
		case SlotTypes.SlotD: infoManager.ComManagerScript.DrawCard[3] = null; break;
		}

		//
	}

	/*
	public override void Against_onClick ()
	{
		InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
		ComManager comManager = GameObject.Find ("ComManager").GetComponent<ComManager> ();

		transform.parent = GameObject.Find ("UseCard").transform;
		transform.position = new Vector3(-3.0f, 1.6f, InfoManager.DynamicZGap);
			
		//카드를 사용했을 때 DrawCard 배열을 비우는 부분
		if(slotType == SlotTypes.SlotA)
		{
			comManager.DrawCard[0] = null;
		}
				
		else if(slotType == SlotTypes.SlotB)
		{
			comManager.DrawCard[1] = null;
		}
				
		else if(slotType == SlotTypes.SlotC)
		{
			comManager.DrawCard[2] = null;
		}

		else
			comManager.DrawCard[3] = null;
	}
	*/

	public override Vector3 UsePosition (PlayerTypes playerType)
	{
		if (playerType == PlayerTypes.User)
			return new Vector3(-4f, -1.2f, InfoManager.DynamicZGap);
		else
			return new Vector3(-4f, 1.6f, InfoManager.DynamicZGap);
	}

}