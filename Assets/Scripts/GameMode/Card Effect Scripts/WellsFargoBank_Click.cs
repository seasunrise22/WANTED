using UnityEngine;
using System.Collections;

public class WellsFargoBank_Click : Click
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
		StartCoroutine("WellsFargo");
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
		StartCoroutine("com_WellsFargo");
	}

	/* 유저턴 웰스파고은행 카드 효과 코루틴 정의 */
	IEnumerator WellsFargo()
	{
		InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
		yield return new WaitForSeconds(0.5f);
		if (GameObject.Find ("SlotA").transform.GetChildCount () == 0) 
		{
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotA] = infoManager.CreateRandomCard();
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotA].transform.position = InfoManager.UserCardPosition(SlotTypes.SlotA);
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotA].transform.rotation = transform.rotation;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotA].transform.parent = GameObject.Find ("SlotA").transform;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotA].GetComponent<Click>().userType = PlayerTypes.User;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotA].GetComponent<Click>().cardType = infoManager.tempCardType;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotA].GetComponent<Click>().slotType = SlotTypes.SlotA;
		} 
		
		else if (GameObject.Find ("SlotB").transform.GetChildCount () == 0) 
		{
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotB] = infoManager.CreateRandomCard();
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotB].transform.position = InfoManager.UserCardPosition(SlotTypes.SlotB);
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotB].transform.rotation = transform.rotation;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotB].transform.parent = GameObject.Find ("SlotB").transform;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotB].GetComponent<Click>().userType = PlayerTypes.User;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotB].GetComponent<Click>().cardType = infoManager.tempCardType;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotB].GetComponent<Click>().slotType = SlotTypes.SlotB;
		} 
		
		else if (GameObject.Find ("SlotC").transform.GetChildCount () == 0) 
		{
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotC] = infoManager.CreateRandomCard();
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotC].transform.position = InfoManager.UserCardPosition(SlotTypes.SlotC);
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotC].transform.rotation = transform.rotation;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotC].transform.parent = GameObject.Find ("SlotC").transform;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotC].GetComponent<Click>().userType = PlayerTypes.User;	
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotC].GetComponent<Click>().cardType = infoManager.tempCardType;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotC].GetComponent<Click>().slotType = SlotTypes.SlotC;
		} 
		
		else if (GameObject.Find ("SlotD").transform.GetChildCount () == 0) 
		{
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotD] = infoManager.CreateRandomCard();
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotD].transform.position = InfoManager.UserCardPosition(SlotTypes.SlotD);
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotD].transform.rotation = transform.rotation;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotD].transform.parent = GameObject.Find ("SlotD").transform;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotD].GetComponent<Click>().userType = PlayerTypes.User;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotD].GetComponent<Click>().cardType = infoManager.tempCardType;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotD].GetComponent<Click>().slotType = SlotTypes.SlotD;
		}	
		StartCoroutine("WellsFargo_2");
	}
	
	IEnumerator WellsFargo_2()
	{
		InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
		yield return new WaitForSeconds(0.5f);
		if (GameObject.Find ("SlotA").transform.GetChildCount () == 0) 
		{
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotA] = infoManager.CreateRandomCard();
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotA].transform.position = InfoManager.UserCardPosition(SlotTypes.SlotA);
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotA].transform.rotation = transform.rotation;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotA].transform.parent = GameObject.Find ("SlotA").transform;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotA].GetComponent<Click>().userType = PlayerTypes.User;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotA].GetComponent<Click>().cardType = infoManager.tempCardType;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotA].GetComponent<Click>().slotType = SlotTypes.SlotA;
		} 
		
		else if (GameObject.Find ("SlotB").transform.GetChildCount () == 0) 
		{
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotB] = infoManager.CreateRandomCard();
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotB].transform.position = InfoManager.UserCardPosition(SlotTypes.SlotB);
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotB].transform.rotation = transform.rotation;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotB].transform.parent = GameObject.Find ("SlotB").transform;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotB].GetComponent<Click>().userType = PlayerTypes.User;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotB].GetComponent<Click>().cardType = infoManager.tempCardType;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotB].GetComponent<Click>().slotType = SlotTypes.SlotB;
		} 
		
		else if (GameObject.Find ("SlotC").transform.GetChildCount () == 0) 
		{
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotC] = infoManager.CreateRandomCard();
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotC].transform.position = InfoManager.UserCardPosition(SlotTypes.SlotC);
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotC].transform.rotation = transform.rotation;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotC].transform.parent = GameObject.Find ("SlotC").transform;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotC].GetComponent<Click>().userType = PlayerTypes.User;	
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotC].GetComponent<Click>().cardType = infoManager.tempCardType;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotC].GetComponent<Click>().slotType = SlotTypes.SlotC;
		} 
		
		else if (GameObject.Find ("SlotD").transform.GetChildCount () == 0) 
		{
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotD] = infoManager.CreateRandomCard();
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotD].transform.position = InfoManager.UserCardPosition(SlotTypes.SlotD);
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotD].transform.rotation = transform.rotation;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotD].transform.parent = GameObject.Find ("SlotD").transform;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotD].GetComponent<Click>().userType = PlayerTypes.User;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotD].GetComponent<Click>().cardType = infoManager.tempCardType;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotD].GetComponent<Click>().slotType = SlotTypes.SlotD;
		}	
		StartCoroutine("WellsFargo_3");
	}
	
	IEnumerator WellsFargo_3()
	{
		InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
		yield return new WaitForSeconds(0.5f);
		if (GameObject.Find ("SlotA").transform.GetChildCount () == 0) 
		{
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotA] = infoManager.CreateRandomCard();
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotA].transform.position = InfoManager.UserCardPosition(SlotTypes.SlotA);
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotA].transform.rotation = transform.rotation;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotA].transform.parent = GameObject.Find ("SlotA").transform;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotA].GetComponent<Click>().userType = PlayerTypes.User;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotA].GetComponent<Click>().cardType = infoManager.tempCardType;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotA].GetComponent<Click>().slotType = SlotTypes.SlotA;
		} 
		
		else if (GameObject.Find ("SlotB").transform.GetChildCount () == 0) 
		{
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotB] = infoManager.CreateRandomCard();
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotB].transform.position = InfoManager.UserCardPosition(SlotTypes.SlotB);
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotB].transform.rotation = transform.rotation;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotB].transform.parent = GameObject.Find ("SlotB").transform;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotB].GetComponent<Click>().userType = PlayerTypes.User;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotB].GetComponent<Click>().cardType = infoManager.tempCardType;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotB].GetComponent<Click>().slotType = SlotTypes.SlotB;
		} 
		
		else if (GameObject.Find ("SlotC").transform.GetChildCount () == 0) 
		{
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotC] = infoManager.CreateRandomCard();
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotC].transform.position = InfoManager.UserCardPosition(SlotTypes.SlotC);
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotC].transform.rotation = transform.rotation;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotC].transform.parent = GameObject.Find ("SlotC").transform;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotC].GetComponent<Click>().userType = PlayerTypes.User;	
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotC].GetComponent<Click>().cardType = infoManager.tempCardType;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotC].GetComponent<Click>().slotType = SlotTypes.SlotC;
		} 
		
		else if (GameObject.Find ("SlotD").transform.GetChildCount () == 0) 
		{
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotD] = infoManager.CreateRandomCard();
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotD].transform.position = InfoManager.UserCardPosition(SlotTypes.SlotD);
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotD].transform.rotation = transform.rotation;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotD].transform.parent = GameObject.Find ("SlotD").transform;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotD].GetComponent<Click>().userType = PlayerTypes.User;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotD].GetComponent<Click>().cardType = infoManager.tempCardType;
			infoManager.UserManagerScript.DrawCard[(int)SlotTypes.SlotD].GetComponent<Click>().slotType = SlotTypes.SlotD;
		}	
	}

	/* 컴퓨터턴 웰스파고은행 카드 효과 코루틴 정의 */
	IEnumerator com_WellsFargo()
	{
		InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
		yield return new WaitForSeconds(0.5f);
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
		StartCoroutine("com_WellsFargo_2");
	}
	
	IEnumerator com_WellsFargo_2()
	{
		InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
		yield return new WaitForSeconds(0.5f);
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
		StartCoroutine("com_WellsFargo_3");
	}
	
	IEnumerator com_WellsFargo_3()
	{
		InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
		End_Turn endTurn = GameObject.Find ("ReadyButtonUI").GetComponent ("End_Turn") as End_Turn;
		yield return new WaitForSeconds(0.5f);
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
		StartCoroutine(endTurn.comAI());
	}

	public override Vector3 UsePosition (PlayerTypes playerType)
	{
		if (playerType == PlayerTypes.User)
			return new Vector3(-4f, -1.2f, InfoManager.DynamicZGap);
		else
			return new Vector3(-4f, 1.6f, InfoManager.DynamicZGap);
	}
}