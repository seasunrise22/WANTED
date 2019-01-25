using UnityEngine;
using System.Collections;

public enum UserState
{
	None,
	User,
	Com
}

public enum UserSetState
{
	None,
	On,
	Off
}

public class UserManager : MonoBehaviour
{
	//변수
	public GameObject[] DrawCard = new GameObject[(int)SlotTypes.Max]; //핸드에 들고있는 카드를 담을 배열
	public GameObject nowSettingCard; //유저가 현재 세트 한 카드를 여기다가 집어넣는다. 
	public GameObject Prison_User; //감옥 쳐맞으면 여기로 넣을거임 
	public CardTypes cardType;
	
	public UISlider LifeBar; //라이프바를 관리하는 컴포넌트인 UISlider 타입의 변수 LifeBar
	public float Max_hp = 5; //최대체력
	public float hp = 5; //현재체력
	
	public UserSetState userSetState = UserSetState.None; //세트카드를 썼는가 안 썼는가 나타낼 함수
	public int addCnt; //드로우, 역마차 카드 효과 함수를 호출할 때 두 번 반복시키기 위한 조건변수
	
	//참조용
	InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
	
	//함수
	void Start()
	{
		LifeBar = transform.GetComponentInChildren<UISlider> (); //체력생성
	}
	
	void Update()
	{
		InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
		EffectUI effectUIManager = GameObject.Find ("EffectUIManager").GetComponent ("EffectUI") as EffectUI;
		End_Turn endTurn = GameObject.Find ("ReadyButtonUI").GetComponent ("End_Turn") as End_Turn;

		if(hp < 1)
		{
			effectUIManager.gameOver.SetActive(true);
			StopCoroutine(endTurn.comAI());
			/*
			effectUIManager.hitBang.SetActive(false);
			effectUIManager.beerkeg.SetActive(false);
			effectUIManager.prison.SetActive(false);
			effectUIManager.userDynamite.SetActive(false);
			effectUIManager.comDynamite.SetActive(false);
			effectUIManager.gameOver.SetActive(false);
			effectUIManager.userWin.SetActive(false);
			effectUIManager.prison_com_escape.SetActive(false);
			effectUIManager.in_prison_com.SetActive(false);
			effectUIManager.haveBangIndian.SetActive(false);
			effectUIManager.notHaveBangIndian.SetActive(false);
			effectUIManager.beerkegFailCom.SetActive(false);
			effectUIManager.beerkegUseCom.SetActive(false);*/
		}
	}
	
	IEnumerator AddCard()
	{
		yield return new WaitForSeconds(0.5f);
		//End_Turn endTurn = GameObject.Find ("Button").GetComponent<End_Turn> ();
		Debug.Log("User AddCard Func");
		InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
		//addCnt += 1;
		if (GameObject.Find ("SlotA").transform.GetChildCount () == 0)
		{
			DrawCard[(int)SlotTypes.SlotA] = infoManager.CreateRandomCard();
			DrawCard[(int)SlotTypes.SlotA].transform.position = InfoManager.UserCardPosition(SlotTypes.SlotA);
			DrawCard[(int)SlotTypes.SlotA].transform.rotation = transform.rotation;
			DrawCard[(int)SlotTypes.SlotA].transform.parent = GameObject.Find ("SlotA").transform;
			DrawCard[(int)SlotTypes.SlotA].GetComponent<Click>().userType = PlayerTypes.User;
			DrawCard[(int)SlotTypes.SlotA].GetComponent<Click>().cardType = infoManager.tempCardType;
			DrawCard[(int)SlotTypes.SlotA].GetComponent<Click>().slotType = SlotTypes.SlotA;
		} 
		
		else if (GameObject.Find ("SlotB").transform.GetChildCount () == 0) 
		{
			DrawCard[(int)SlotTypes.SlotB] = infoManager.CreateRandomCard();
			DrawCard[(int)SlotTypes.SlotB].transform.position = InfoManager.UserCardPosition(SlotTypes.SlotB);
			DrawCard[(int)SlotTypes.SlotB].transform.rotation = transform.rotation;
			DrawCard[(int)SlotTypes.SlotB].transform.parent = GameObject.Find ("SlotB").transform;
			DrawCard[(int)SlotTypes.SlotB].GetComponent<Click>().userType = PlayerTypes.User;
			DrawCard[(int)SlotTypes.SlotB].GetComponent<Click>().cardType = infoManager.tempCardType;
			DrawCard[(int)SlotTypes.SlotB].GetComponent<Click>().slotType = SlotTypes.SlotB;
		} 
		
		else if (GameObject.Find ("SlotC").transform.GetChildCount () == 0) 
		{
			DrawCard[(int)SlotTypes.SlotC] = infoManager.CreateRandomCard();
			DrawCard[(int)SlotTypes.SlotC].transform.position = InfoManager.UserCardPosition(SlotTypes.SlotC);
			DrawCard[(int)SlotTypes.SlotC].transform.rotation = transform.rotation;
			DrawCard[(int)SlotTypes.SlotC].transform.parent = GameObject.Find ("SlotC").transform;
			DrawCard[(int)SlotTypes.SlotC].GetComponent<Click>().userType = PlayerTypes.User;
			DrawCard[(int)SlotTypes.SlotC].GetComponent<Click>().cardType = infoManager.tempCardType;
			DrawCard[(int)SlotTypes.SlotC].GetComponent<Click>().slotType = SlotTypes.SlotC;
		} 
		
		else if (GameObject.Find ("SlotD").transform.GetChildCount () == 0) 
		{
			DrawCard[(int)SlotTypes.SlotD] = infoManager.CreateRandomCard();
			DrawCard[(int)SlotTypes.SlotD].transform.position = InfoManager.UserCardPosition(SlotTypes.SlotD);
			DrawCard[(int)SlotTypes.SlotD].transform.rotation = transform.rotation;
			DrawCard[(int)SlotTypes.SlotD].transform.parent = GameObject.Find ("SlotD").transform;
			DrawCard[(int)SlotTypes.SlotD].GetComponent<Click>().userType = PlayerTypes.User;
			DrawCard[(int)SlotTypes.SlotD].GetComponent<Click>().cardType = infoManager.tempCardType;
			DrawCard[(int)SlotTypes.SlotD].GetComponent<Click>().slotType = SlotTypes.SlotD;
		}
		StartCoroutine("AddCard_2");
	}
	
	IEnumerator AddCard_2()
	{
		yield return new WaitForSeconds(0.5f);
		//End_Turn endTurn = GameObject.Find ("Button").GetComponent<End_Turn> ();
		Debug.Log("User AddCard_2 Func");
		InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
		//addCnt += 1;
		if (GameObject.Find ("SlotA").transform.GetChildCount () == 0)
		{
			DrawCard[(int)SlotTypes.SlotA] = infoManager.CreateRandomCard();
			DrawCard[(int)SlotTypes.SlotA].transform.position = InfoManager.UserCardPosition(SlotTypes.SlotA);
			DrawCard[(int)SlotTypes.SlotA].transform.rotation = transform.rotation;
			DrawCard[(int)SlotTypes.SlotA].transform.parent = GameObject.Find ("SlotA").transform;
			DrawCard[(int)SlotTypes.SlotA].GetComponent<Click>().userType = PlayerTypes.User;
			DrawCard[(int)SlotTypes.SlotA].GetComponent<Click>().cardType = infoManager.tempCardType;
			DrawCard[(int)SlotTypes.SlotA].GetComponent<Click>().slotType = SlotTypes.SlotA;
		} 
		
		else if (GameObject.Find ("SlotB").transform.GetChildCount () == 0) 
		{
			DrawCard[(int)SlotTypes.SlotB] = infoManager.CreateRandomCard();
			DrawCard[(int)SlotTypes.SlotB].transform.position = InfoManager.UserCardPosition(SlotTypes.SlotB);
			DrawCard[(int)SlotTypes.SlotB].transform.rotation = transform.rotation;
			DrawCard[(int)SlotTypes.SlotB].transform.parent = GameObject.Find ("SlotB").transform;
			DrawCard[(int)SlotTypes.SlotB].GetComponent<Click>().userType = PlayerTypes.User;
			DrawCard[(int)SlotTypes.SlotB].GetComponent<Click>().cardType = infoManager.tempCardType;
			DrawCard[(int)SlotTypes.SlotB].GetComponent<Click>().slotType = SlotTypes.SlotB;
		} 
		
		else if (GameObject.Find ("SlotC").transform.GetChildCount () == 0) 
		{
			DrawCard[(int)SlotTypes.SlotC] = infoManager.CreateRandomCard();
			DrawCard[(int)SlotTypes.SlotC].transform.position = InfoManager.UserCardPosition(SlotTypes.SlotC);
			DrawCard[(int)SlotTypes.SlotC].transform.rotation = transform.rotation;
			DrawCard[(int)SlotTypes.SlotC].transform.parent = GameObject.Find ("SlotC").transform;
			DrawCard[(int)SlotTypes.SlotC].GetComponent<Click>().userType = PlayerTypes.User;
			DrawCard[(int)SlotTypes.SlotC].GetComponent<Click>().cardType = infoManager.tempCardType;
			DrawCard[(int)SlotTypes.SlotC].GetComponent<Click>().slotType = SlotTypes.SlotC;
		} 
		
		else if (GameObject.Find ("SlotD").transform.GetChildCount () == 0) 
		{
			DrawCard[(int)SlotTypes.SlotD] = infoManager.CreateRandomCard();
			DrawCard[(int)SlotTypes.SlotD].transform.position = InfoManager.UserCardPosition(SlotTypes.SlotD);
			DrawCard[(int)SlotTypes.SlotD].transform.rotation = transform.rotation;
			DrawCard[(int)SlotTypes.SlotD].transform.parent = GameObject.Find ("SlotD").transform;
			DrawCard[(int)SlotTypes.SlotD].GetComponent<Click>().userType = PlayerTypes.User;
			DrawCard[(int)SlotTypes.SlotD].GetComponent<Click>().cardType = infoManager.tempCardType;
			DrawCard[(int)SlotTypes.SlotD].GetComponent<Click>().slotType = SlotTypes.SlotD;
		}
	}
	
	//뱅에 맞으면 피 깎이는 함수
	public void Hurt(float damage)
	{
		EffectUI effectUIManager = GameObject.Find ("EffectUIManager").GetComponent ("EffectUI") as EffectUI;
		End_Turn endTurn = GameObject.Find ("ReadyButtonUI").GetComponent ("End_Turn") as End_Turn;
		
		hp -= damage;
		LifeBar.sliderValue = hp / Max_hp; //slider.Value는 0과 1로 LifeBar의 GUI를 컨트롤 해줌
	}
	
	//맥주카드 효과
	public void Beer(float heal)
	{
		if (hp < 6 && hp > 0){
			hp += heal;
			LifeBar.sliderValue = hp / Max_hp; //slider.Value는 0과 1로 LifeBar의 GUI를 컨트롤 해줌.
		}
		
		if (hp <= 0){
		}
	}
	
	/*
	//Prison_User변수 즉, 유저가 지금 감옥에 걸려있을 경우 호출되는 함수
	public void hitPrison()
	{
		InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
		EffectUI effectUIManager = GameObject.Find ("EffectUIManager").GetComponent ("EffectUI") as EffectUI;
		ClickDice clickDice = GameObject.Find ("Button").GetComponent ("End_Turn") as ClickDice;
		
		if(Prison_User != null) //Prison_User변수가 null이 아니라면
		{
			effectUIManager.prison.SetActive(true); //감옥 UI를 Active 시킨다.
		}
	}
	*/
}


