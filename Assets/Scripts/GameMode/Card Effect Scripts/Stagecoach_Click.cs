using UnityEngine;
using System.Collections;

public class Stagecoach_Click : Click
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

		//transform.position = new Vector3(-3.0f, -1.2f, InfoManager.DynamicZGap);
		infoManager.UserManagerScript.StartCoroutine("AddCard");
    }
    
    public override void Com_onClick ()
	{
		InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();

		switch (slotType)
		{
		case SlotTypes.SlotA: infoManager.ComManagerScript.DrawCard[0] = null; break;
		case SlotTypes.SlotB: infoManager.ComManagerScript.DrawCard[1] = null; break;
		case SlotTypes.SlotC: infoManager.ComManagerScript.DrawCard[2] = null; break;
		case SlotTypes.SlotD: infoManager.ComManagerScript.DrawCard[3] = null; break;
		}

        //transform.position = new Vector3(-3.0f, 1.6f, InfoManager.DynamicZGap);
		StartCoroutine("StageCoach");
	}

	public IEnumerator StageCoach()
	{
		yield return new WaitForSeconds(1f);
		InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
		if (GameObject.Find ("Com_SlotA").transform.GetChildCount () == 0) 
		{
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotA] = infoManager.CreateRandomCard();
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotA].transform.position = InfoManager.ComCardPosition(SlotTypes.SlotA);
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotA].transform.rotation = transform.rotation;
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotA].transform.parent = GameObject.Find ("Com_SlotA").transform;
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotA].GetComponent<Click>().userType = PlayerTypes.Computer_1;	
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotA].GetComponent<Click>().cardType = infoManager.tempCardType;
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotA].GetComponent<Click>().slotType = SlotTypes.SlotA;
		} 
		
		else if (GameObject.Find ("Com_SlotB").transform.GetChildCount () == 0) 
		{
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotB] = infoManager.CreateRandomCard();
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotB].transform.position = InfoManager.ComCardPosition(SlotTypes.SlotB);
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotB].transform.rotation = transform.rotation;
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotB].transform.parent = GameObject.Find ("Com_SlotB").transform;
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotB].GetComponent<Click>().userType = PlayerTypes.Computer_1;	
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotB].GetComponent<Click>().cardType = infoManager.tempCardType;	
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotB].GetComponent<Click>().slotType = SlotTypes.SlotB;
		} 
		
		else if (GameObject.Find ("Com_SlotC").transform.GetChildCount () == 0) 
		{
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotC] = infoManager.CreateRandomCard();
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotC].transform.position = InfoManager.ComCardPosition(SlotTypes.SlotC);
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotC].transform.rotation = transform.rotation;
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotC].transform.parent = GameObject.Find ("Com_SlotC").transform;
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotC].GetComponent<Click>().userType = PlayerTypes.Computer_1;	
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotC].GetComponent<Click>().cardType = infoManager.tempCardType;
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotC].GetComponent<Click>().slotType = SlotTypes.SlotC;
		} 
		
		else if (GameObject.Find ("Com_SlotD").transform.GetChildCount () == 0) 
		{
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotD] = infoManager.CreateRandomCard();
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotD].transform.position = InfoManager.ComCardPosition(SlotTypes.SlotD);
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotD].transform.rotation = transform.rotation;
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotD].transform.parent = GameObject.Find ("Com_SlotD").transform;
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotD].GetComponent<Click>().userType = PlayerTypes.Computer_1;	
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotD].GetComponent<Click>().cardType = infoManager.tempCardType;
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotD].GetComponent<Click>().slotType = SlotTypes.SlotD;
		}	
		StartCoroutine("StageCoach_2");
	}
	
	public IEnumerator StageCoach_2()
	{
		yield return new WaitForSeconds(1f);
		End_Turn endTurn = GameObject.Find ("ReadyButtonUI").GetComponent ("End_Turn") as End_Turn;
		InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
		if (GameObject.Find ("Com_SlotA").transform.GetChildCount () == 0) 
		{
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotA] = infoManager.CreateRandomCard();
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotA].transform.position = InfoManager.ComCardPosition(SlotTypes.SlotA);
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotA].transform.rotation = transform.rotation;
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotA].transform.parent = GameObject.Find ("Com_SlotA").transform;
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotA].GetComponent<Click>().userType = PlayerTypes.Computer_1;	
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotA].GetComponent<Click>().cardType = infoManager.tempCardType;
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotA].GetComponent<Click>().slotType = SlotTypes.SlotA;
		} 
		
		else if (GameObject.Find ("Com_SlotB").transform.GetChildCount () == 0) 
		{
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotB] = infoManager.CreateRandomCard();
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotB].transform.position = InfoManager.ComCardPosition(SlotTypes.SlotB);
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotB].transform.rotation = transform.rotation;
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotB].transform.parent = GameObject.Find ("Com_SlotB").transform;
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotB].GetComponent<Click>().userType = PlayerTypes.Computer_1;	
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotB].GetComponent<Click>().cardType = infoManager.tempCardType;	
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotB].GetComponent<Click>().slotType = SlotTypes.SlotB;
		} 
		
		else if (GameObject.Find ("Com_SlotC").transform.GetChildCount () == 0) 
		{
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotC] = infoManager.CreateRandomCard();
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotC].transform.position = InfoManager.ComCardPosition(SlotTypes.SlotC);
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotC].transform.rotation = transform.rotation;
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotC].transform.parent = GameObject.Find ("Com_SlotC").transform;
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotC].GetComponent<Click>().userType = PlayerTypes.Computer_1;	
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotC].GetComponent<Click>().cardType = infoManager.tempCardType;
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotC].GetComponent<Click>().slotType = SlotTypes.SlotC;
		} 
		
		else if (GameObject.Find ("Com_SlotD").transform.GetChildCount () == 0) 
		{
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotD] = infoManager.CreateRandomCard();
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotD].transform.position = InfoManager.ComCardPosition(SlotTypes.SlotD);
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotD].transform.rotation = transform.rotation;
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotD].transform.parent = GameObject.Find ("Com_SlotD").transform;
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotD].GetComponent<Click>().userType = PlayerTypes.Computer_1;	
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotD].GetComponent<Click>().cardType = infoManager.tempCardType;
			infoManager.ComManagerScript.DrawCard[(int)SlotTypes.SlotD].GetComponent<Click>().slotType = SlotTypes.SlotD;
		}
		yield return new WaitForSeconds(1f);
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