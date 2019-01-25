using UnityEngine;
using System.Collections;

public class End_Turn : MonoBehaviour
{
	public void OnClickStart ()
	{
		EffectUI effectUIManager = GameObject.Find ("EffectUIManager").GetComponent ("EffectUI") as EffectUI;
		InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
		
		Debug.Log ("OnClickStart");
		if (infoManager.userState == UserState.User) 
		{
			Debug.Log("State : User");
			infoManager.userState = UserState.None;
			StartCoroutine("changeToComTurn");			
		}
		
		else if (infoManager.userState == UserState.Com)
		{
			Debug.Log("State : Com");
			infoManager.userState = UserState.None;
			StartCoroutine("changeToUserTurn");
		}
	}
	
	public IEnumerator changeToComTurn()
	{
		Debug.Log("call changeToComTurn");
		yield return new WaitForSeconds (1);
		Debug.Log ("1");
		yield return new WaitForSeconds (1);
		Debug.Log ("Turn Change");
		
		UILabel buttonText = GameObject.Find("Button/Label").GetComponent<UILabel>();
		InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
		EffectUI effectUIManager = GameObject.Find ("EffectUIManager").GetComponent ("EffectUI") as EffectUI;
		infoManager.userState = UserState.Com;
		buttonText.text = "Com Turn";
		infoManager.UserManagerScript.StartCoroutine("AddCard");
		
		if(infoManager.comDynamiteSet != null) 
		{
			Debug.Log("Com have Dynamite");
			effectUIManager.comDynamite.SetActive(true); //주사위 던지라는 UI 호출함
		}
		
		else if(infoManager.ComManagerScript.Prison_Com != null)
		{
			Debug.Log("Prison_Com is not null");
			infoManager.Com_prisonThrowDice();
		}
		
		else
			StartCoroutine("comAI");		
	}
	
	public IEnumerator changeToUserTurn()
	{
		UILabel buttonText = GameObject.Find("Button/Label").GetComponent<UILabel>();
		InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();     
		ClickDice clickDice = GameObject.Find ("Dice").GetComponent ("ClickDice") as ClickDice;
		EffectUI effectUIManager = GameObject.Find ("EffectUIManager").GetComponent ("EffectUI") as EffectUI;
		
		Debug.Log("call changeToUserTurn");
		yield return new WaitForSeconds (1);
		Debug.Log ("1");
		yield return new WaitForSeconds (1);
		Debug.Log ("Turn Change");
		
		infoManager.userState = UserState.User;
		buttonText.text = "Your Turn";
		StartCoroutine(infoManager.ComManagerScript.Com_addCard());  
		
		//userDynamiteSet변수에 뭔가가 들어있다면. 즉, 유저에게 다이너마이트 카드가 있는 상태라면 상태라면.
		if(infoManager.userDynamiteSet != null) 
		{
			Debug.Log("User have Dynamite");
			effectUIManager.userDynamite.SetActive(true); //주사위 던지라는 UI 호출함
		}
		
		else if(infoManager.UserManagerScript.Prison_User != null)
			effectUIManager.prison.SetActive(true);
	}
	
	//컴퓨터의 핸드에 존재하는 빈 공간의 갯수를 반환하는 함수
	int handCnt()
	{
		int count = 0;
		InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
		foreach(GameObject card in infoManager.ComManagerScript.DrawCard)
			if(card == null)
				count += 1;
		return count;
	}
	
	//컴퓨터가 핸드에 있는 카드를 우선순위대로 내도록 하는 일종의 인공지능 함수
	//함수가 호출 될 때 마다 상황에 맞는 적절한 행동을 1회 수행한다.
	public IEnumerator comAI()
	{
		yield return null;
		InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
		yield return new WaitForSeconds(1f); //호출한 함수에게 0.5초후에 깨워서 아래 기능을 수행하라는 정보를 넘겨준다. 
		Debug.Log("Call comAI");
		int nullCnt = handCnt(); 
		
		
		foreach(GameObject card in infoManager.ComManagerScript.DrawCard) //컴퓨터 핸드에 있는 카드를 탐색한다.
		{
			Debug.Log("foreach card in DrawCard");
			if(card != null) //이 부분이 빠지면 탐색 중 null을 만났을 때 아래 제어문이 작동하지 않는다.
			{
				//핸드의 빈공간 상황에 따라 적절한 드로우 카드를 쓰게하는 알고리즘
				if(nullCnt > 0 && card.GetComponent<Click>().cardType == CardTypes.Stagecoach)
				{
					Debug.Log("nullCnt > 1 and com has Stagecoach card");
					card.GetComponent<Click>().OnMouseDown(); //탐색한 카드의 OnMouseDown 함수를 호출한다.
					break;
				}
				
				/*
                    else if(nullCnt > 2 && card.GetComponent<Click>().cardType == CardTypes.Stagecoach)
                    {
                        Debug.Log("nullCnt > 2 and com has Stagecoach card");
                        card.GetComponent<Click>().OnMouseDown(); //탐색한 카드의 OnMouseDown 함수를 호출한다.
                        break;
                    }
                    */
				
				else if(nullCnt > 2 && card.GetComponent<Click>().cardType == CardTypes.WellsFargoBank)
				{
					Debug.Log("nullCnt > 2 and com has WellsFargoBank card");
					card.GetComponent<Click>().OnMouseDown(); //탐색한 카드의 OnMouseDown 함수를 호출한다.
					break;
				}
				
				//현재 풀피가 아니면서 핸드에 맥주카드가 있을 경우
				else if(infoManager.ComManagerScript.hp != 5 && card.GetComponent<Click>().cardType == CardTypes.Beer) 
				{
					Debug.Log("Not Full hp and Find Beer");
					card.GetComponent<Click>().OnMouseDown(); //탐색한 카드의 OnMouseDown 함수를 호출한다.
					break;
				}
				
				//뱅을 들고 있을 경우
				else if(card.GetComponent<Click>().cardType == CardTypes.Bang) //핸드에 'Bang카드'가 존재할 경우
				{
					Debug.Log("Find Bang");
					card.GetComponent<Click>().OnMouseDown(); //탐색한 카드의 OnMouseDown 함수를 호출한다.
					break;
				}
				
				//술통을 들고 있을 경우
				else if(card.GetComponent<Click>().cardType == CardTypes.Beerkeg)
				{
					Debug.Log("Find Beerkeg");
					card.GetComponent<Click>().OnMouseDown(); //탐색한 카드의 OnMouseDown 함수를 호출한다.
					break;
				}
				
				//감옥을 들고 있을 경우
				else if(card.GetComponent<Click>().cardType == CardTypes.Prison)
				{
					Debug.Log("Find Prison");
					card.GetComponent<Click>().OnMouseDown(); //탐색한 카드의 OnMouseDown 함수를 호출한다.
					break;
				}
				
				//인디언을 들고 있을 경우
				else if(card.GetComponent<Click>().cardType == CardTypes.Indian)
				{
					Debug.Log("Find Indian");
					card.GetComponent<Click>().OnMouseDown(); //탐색한 카드의 OnMouseDown 함수를 호출한다.
					break;
				}
				
				//다이너마이트를 들고 있을 경우
				else if(infoManager.dynamiteState == DynamiteStates.Off && 
				        card.GetComponent<Click>().cardType == CardTypes.Dynamite)
				{
					Debug.Log("Find Dynamite");
					card.GetComponent<Click>().OnMouseDown(); //탐색한 카드의 OnMouseDown 함수를 호출한다.
					break;
				}
				
				//딱히 쓸 카드는 없는데 컴퓨터 핸드가 꽉 차 있을 경우
				else if(infoManager.ComManagerScript.DrawCard[0] != null &&
				        infoManager.ComManagerScript.DrawCard[1] != null &&
				        infoManager.ComManagerScript.DrawCard[2] != null &&
				        infoManager.ComManagerScript.DrawCard[3] != null)
				{
					Debug.Log("full hand");
					card.GetComponent<Click>().OnMouseDown();
				}
				
				else
				{
					Debug.Log("Turn off");
					OnClickStart();
				}
			}
			if(infoManager.ComManagerScript.DrawCard[0] == null &&
			   infoManager.ComManagerScript.DrawCard[1] == null &&
			   infoManager.ComManagerScript.DrawCard[2] == null &&
			   infoManager.ComManagerScript.DrawCard[3] == null)
				OnClickStart();
		}
	}       
}
