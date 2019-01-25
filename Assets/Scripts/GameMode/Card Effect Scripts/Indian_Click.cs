using UnityEngine;
using System.Collections;

public class Indian_Click : Click
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
		
		bool find = false;
		foreach (GameObject card in infoManager.ComManagerScript.DrawCard) //컴퓨터의 핸드를 탐색한다.
		{
			if (card != null)
			{
				if (card.GetComponent<Click>().cardType == CardTypes.Bang) //컴퓨터의 핸드에 'Bang카드'가 존재한다면
				{
					find = true;
					Debug.Log("Find Bang in computer hands");
					card.transform.parent = GameObject.Find ("UseCard").transform; //찾은 'Bang카드'는 UseCard의 자식으로
					card.transform.position = UsePosition (PlayerTypes.Computer_1); //위치는 'ComBoard'로 올린다.
					card.GetComponent<Click>().useCheck = UseCheck.Use; //컴퓨터가 낸 'Bang 카드'는 사용 된 카드라고 갱신
					switch (card.GetComponent<Click>().slotType) //컴퓨터가 낸 후 가지고 있던 DrawCard 인덱스는 null로 초기화
					{
					case SlotTypes.SlotA: infoManager.ComManagerScript.DrawCard[0] = null; break;
					case SlotTypes.SlotB: infoManager.ComManagerScript.DrawCard[1] = null; break;
					case SlotTypes.SlotC: infoManager.ComManagerScript.DrawCard[2] = null; break;
					case SlotTypes.SlotD: infoManager.ComManagerScript.DrawCard[3] = null; break;
					}
					break;
				}
			}
		}
		
		if(find == false)
			infoManager.ComManagerScript.Hurt(1); //컴퓨터의 핸드에 'Bang카드'가 없을 경우, 컴퓨터의 HP를 1 깎는다.
		/*
		if(infoManager.ComManagerScript.DrawCard[0].GetComponent<Click>().cardType != CardTypes.Bang &&
		   infoManager.ComManagerScript.DrawCard[1].GetComponent<Click>().cardType != CardTypes.Bang &&
		   infoManager.ComManagerScript.DrawCard[2].GetComponent<Click>().cardType != CardTypes.Bang &&
		   infoManager.ComManagerScript.DrawCard[3].GetComponent<Click>().cardType != CardTypes.Bang)
		{
			infoManager.ComManagerScript.Hurt(1); //컴퓨터의 핸드에 'Bang카드'가 없을 경우, 컴퓨터의 HP를 1 깎는다.
		}
		*/
	}
	
	public override void Com_onClick ()
	{
		InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
		EffectUI effectUIManager = GameObject.Find ("EffectUIManager").GetComponent ("EffectUI") as EffectUI;
		End_Turn endTurn = GameObject.Find ("ReadyButtonUI").GetComponent ("End_Turn") as End_Turn;
		
		switch (slotType)
		{
		case SlotTypes.SlotA: infoManager.ComManagerScript.DrawCard[0] = null; break;
		case SlotTypes.SlotB: infoManager.ComManagerScript.DrawCard[1] = null; break;
		case SlotTypes.SlotC: infoManager.ComManagerScript.DrawCard[2] = null; break;
		case SlotTypes.SlotD: infoManager.ComManagerScript.DrawCard[3] = null; break;
		}
		
		bool find = false;
		foreach (GameObject card in infoManager.UserManagerScript.DrawCard) //컴퓨터의 핸드를 탐색한다.
		{
			if(card != null)
			{
				if (card.GetComponent<Click>().cardType == CardTypes.Bang) //컴퓨터의 핸드에 'Bang카드'가 존재한다면
				{
					find = true;
					effectUIManager.haveBangIndian.SetActive(true);
					StopCoroutine(endTurn.comAI());
					break;
				}
			}				
		}

		if(find == false)
		{
			effectUIManager.notHaveBangIndian.SetActive(true);
			StopCoroutine(endTurn.comAI());
		}
	}
		
		public override Vector3 UsePosition (PlayerTypes playerType) //카드 놓는 위치 잡을 때 호출되는 함수
		{
			if (playerType == PlayerTypes.User)
				return new Vector3(-4f, -1.2f, InfoManager.DynamicZGap);
			else
				return new Vector3(-4f, 1.6f, InfoManager.DynamicZGap);
		}
	}