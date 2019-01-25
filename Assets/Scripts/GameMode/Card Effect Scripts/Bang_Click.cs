using UnityEngine;
using System.Collections;

public class Bang_Click : Click 
{
	public override void User_onClick () //유저가 클릭했을 경우
	{
		InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
		EffectUI effectUIManager = GameObject.Find ("EffectUIManager").GetComponent ("EffectUI") as EffectUI;
		//ClickDice clickDice = GameObject.Find ("Button").GetComponent ("End_Turn") as ClickDice;
		
		switch (slotType)
		{
		case SlotTypes.SlotA: infoManager.UserManagerScript.DrawCard[0] = null; break;
		case SlotTypes.SlotB: infoManager.UserManagerScript.DrawCard[1] = null; break;
		case SlotTypes.SlotC: infoManager.UserManagerScript.DrawCard[2] = null; break;
		case SlotTypes.SlotD: infoManager.UserManagerScript.DrawCard[3] = null; break;
		}

		bool find = false;
		foreach (GameObject card in infoManager.ComManagerScript.DrawCard) //DrawCard 를 탐색 
		{
			if (card != null)
			{
				//컴퓨터의 핸드에 술통이 세트되어 있을 경우
				if(infoManager.ComManagerScript.comSetState == ComSetState.On) //컴퓨터가 뱅을 썼을 때, 유저 세트카드 상태가 On이고
				{
					if(infoManager.ComManagerScript.nowSettingCard.GetComponent<Click>().cardType == CardTypes.Beerkeg) //세트 된 카드가 술통이면, 사실 세트카드 술통밖에 없음
					{
						find = true;
						infoManager.com_beerkegThrowDice(); //술통효과 함수를 발동시킨다.
						break;
					}
				}
				
				else if (card.GetComponent<Click>().cardType == CardTypes.Void) //컴퓨터의 핸드에 Void 카드가 존재한다면
				{
					find = true;
					card.GetComponent<Click>().activeComVoid();
					//infoManager.ComManagerScript.Hurt(1);
					//infoManager.ComManagerScript.Hurt(-2);
					break; //찾았으면 foreach를 빠져나간다.
				}
			}
		}
		if(find == false)
			infoManager.ComManagerScript.Hurt (1); //ComManager에 접근해 Hurt 함수를 호출하라
	}
	
	public override void Com_onClick () //컴퓨터가 클릭했을 경우
	{
		InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
		EffectUI effectUIManager = GameObject.Find ("EffectUIManager").GetComponent ("EffectUI") as EffectUI;
		End_Turn endTurn = GameObject.Find ("ReadyButtonUI").GetComponent ("End_Turn") as End_Turn;
		ClickDice clickDice = GameObject.Find ("Button").GetComponent ("End_Turn") as ClickDice;
		
		switch (slotType)
		{
		case SlotTypes.SlotA: infoManager.ComManagerScript.DrawCard[0] = null; break;
		case SlotTypes.SlotB: infoManager.ComManagerScript.DrawCard[1] = null; break;
		case SlotTypes.SlotC: infoManager.ComManagerScript.DrawCard[2] = null; break;
		case SlotTypes.SlotD: infoManager.ComManagerScript.DrawCard[3] = null; break;
		}
		
		if(infoManager.UserManagerScript.userSetState == UserSetState.On) //컴퓨터가 뱅을 썼을 때, 유저 세트카드 상태가 On이고
		{
			if(infoManager.UserManagerScript.nowSettingCard.GetComponent<Click>().cardType == CardTypes.Beerkeg) //세트 된 카드가 술통이면, 사실 세트카드 술통밖에 없음
			{
				effectUIManager.beerkeg.SetActive(true); //술통효과 쓰라는 UI를 Active 시킨다.
				StopCoroutine(endTurn.comAI());
			}
		}
		

		else  //유저의 세트카드가 없으면 
		{
			bool find = false;
			foreach (GameObject card in infoManager.UserManagerScript.DrawCard)
			{
				if(card != null)
				{
					if(card.GetComponent<Click>().cardType == CardTypes.Void) //유저의 핸드에 Void 카드가 존재한다면
					{
						find = true;
						effectUIManager.hitBang.SetActive(true); //빗나감 카드를 쓸 것인지 묻는 UI를 Active 시킨다.
						break;
					}
				}
			}

			if(find == false)
			{
				infoManager.UserManagerScript.Hurt (1); //아무것도 없으면 그냥 유저의 HP를 1 깎아라
				StartCoroutine(endTurn.comAI());
			}
		}
	}
	
	//Click 스크립트에서 상속받은 UsePosition 함수
	//카드의 위치를 결정한다.
	public override Vector3 UsePosition (PlayerTypes playerType) 
	{
		if (playerType == PlayerTypes.User)
			return new Vector3 (-4f, -1.2f, InfoManager.DynamicZGap);
		else
			return new Vector3(-4f, 1.6f, InfoManager.DynamicZGap);
	}
}