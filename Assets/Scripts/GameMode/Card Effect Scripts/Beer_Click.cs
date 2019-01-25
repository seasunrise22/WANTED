using UnityEngine;
using System.Collections;

public class Beer_Click : Click
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

		infoManager.UserManagerScript.Beer (1);
    }
    
    public override void Com_onClick ()
	{
		InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
		End_Turn endTurn = GameObject.Find ("ReadyButtonUI").GetComponent ("End_Turn") as End_Turn;

		switch (slotType)
		{
		case SlotTypes.SlotA: infoManager.ComManagerScript.DrawCard[0] = null; break;
		case SlotTypes.SlotB: infoManager.ComManagerScript.DrawCard[1] = null; break;
		case SlotTypes.SlotC: infoManager.ComManagerScript.DrawCard[2] = null; break;
		case SlotTypes.SlotD: infoManager.ComManagerScript.DrawCard[3] = null; break;
		}

		infoManager.ComManagerScript.Beer (1);
		endTurn.StartCoroutine("comAI");
	}

	public override Vector3 UsePosition (PlayerTypes playerType)
	{
		if (playerType == PlayerTypes.User)
			return new Vector3(-4f, -1.2f, InfoManager.DynamicZGap);
		else
			return new Vector3(-4f, 1.6f, InfoManager.DynamicZGap);
	}
}


