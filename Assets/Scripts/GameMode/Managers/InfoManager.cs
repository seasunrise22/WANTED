using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum PlayerTypes
{
	User,
	Computer_1,
	Max,
}

public enum SlotTypes
{
	SlotA,
	SlotB,
	SlotC,
	SlotD,
	Max,
}

public enum CardTypes
{
	Bang,
	Beer,
	Beerkeg,
	Dynamite,
	Indian,
	Prison,
	Stagecoach,
	Void,
	WellsFargoBank,
	Max,
}

public enum DynamiteStates
{
	On,
	Off
}

public class InfoManager : MonoBehaviour 
{
	public static float DynamicZGap = -2f;
	
	private UserState _userState = UserState.User; //User 턴으로 게임이 시작된다.
	public UserState userState
	{
		get { return _userState; }
		set { _userState = value; }
	}
	public CardTypes tempCardType;
	public GameObject userDynamiteSet; //유저 Board에 다이너마이트 카드가 놓여져 있으면 여기로 넣는다.
	public GameObject comDynamiteSet; //컴퓨터 Board에 다이너마이트 카드가 놓여져 있으면 여기로 넣는다.
	public GameObject fightSet; //결투카드를 내면 여기로 넣는다.
	public DynamiteStates dynamiteState = DynamiteStates.Off; //다이너마이트 상태의 초기값은 Off, 다이너마이트 보류
	public int addRandCnt = 0; //초기 드로우를 4회로 제한하기 위한 변수
	
	public int charNum = 0; //싱글톤 캐릭터 값
	public int campNum = 0; //싱글톤 진영 값
	
	/* 슬롯 포지션 잡는 함수 */
	public static Vector3 UserCardPosition(SlotTypes slotType)
	{
		switch (slotType)
		{
		case SlotTypes.SlotA:
			return new Vector3 (-4.486496f, -3.733363f, -1f);
		case SlotTypes.SlotB:
			return new Vector3 (-2.072048f, -3.733363f, -1f);
		case SlotTypes.SlotC:
			return new Vector3 (0.2765034f, -3.733363f, -1f);
		case SlotTypes.SlotD:
			return new Vector3 (2.519447f, -3.733363f, -1f);
		}
		return Vector3.zero;
	}
	
	/* 컴퓨터 카드 포지션 잡는 함수 */
	public static Vector3 ComCardPosition(SlotTypes slotType)
	{
		switch (slotType) {
		case SlotTypes.SlotA:
			return new Vector3 (-4.486496f, 4.233363f, -1f);
		case SlotTypes.SlotB:
			return new Vector3 (-2.072048f, 4.233363f, -1f);
		case SlotTypes.SlotC:
			return new Vector3 (0.2765034f, 4.233363f, -1f);
		case SlotTypes.SlotD:
			return new Vector3 (2.519447f, 4.233363f, -1f);
		}
		return Vector3.zero;
	}
	
	/* 각 매니저에 접근 */
	public UserManager UserManagerScript;
	public ComManager ComManagerScript;
	
	GameObject[] Cards; //카드 프리펩 넣는 배열
	
	/* 카드덱 */
	public int TotalCard {
		get { return RestoreCard.Count; }
	}
	
	public List<CardTypes> RestoreCard = new List<CardTypes>();
	
	/*
     * 
           ComManagerScript.DrawCard[0] == null &&
           ComManagerScript.DrawCard[1] == null &&
           ComManagerScript.DrawCard[2] == null &&
           ComManagerScript.DrawCard[3] == null
           */
	
	void Update()
	{		
	}
	
	void Awake () //Start 보다 먼저 발동되는 함수. 가장 먼저 발동됨. 
	{   
		GameObject UserManagerObject = Instantiate (Resources.Load ("Prefabs/UserManager")) as GameObject;
		UserManagerObject.name = "UserManager";
		
		GameObject ComManagerObject = Instantiate (Resources.Load ("Prefabs/ComManager")) as GameObject;
		ComManagerObject.name = "ComManager";
		
		/* inforManager 오브젝트에 각 매니저 스크립트를 부착한다. */
		this.UserManagerScript = UserManagerObject.AddComponent<UserManager> ();
		this.ComManagerScript = ComManagerObject.AddComponent<ComManager> ();
		
		GameObject CardObject = new GameObject ("Cards");
		
		/* 배열에 프리펩 폴더에서 프리펩을 불러와 카드별로 오브젝트를 만든다. */
		/* Cards 라는 배열은 오브젝트 형태로 생성되는 듯 */
		Cards = new GameObject[(int)CardTypes.Max];
		Cards [(int)CardTypes.Bang]             = Instantiate (Resources.Load ("Prefabs/Cards/Bang"))as GameObject;
		Cards [(int)CardTypes.Beer]             = Instantiate (Resources.Load ("Prefabs/Cards/Beer"))as GameObject;
		Cards [(int)CardTypes.Beerkeg]          = Instantiate (Resources.Load ("Prefabs/Cards/Beerkeg"))as GameObject;
		Cards [(int)CardTypes.Dynamite]         = Instantiate (Resources.Load ("Prefabs/Cards/Dynamite"))as GameObject;
		Cards [(int)CardTypes.Indian]           = Instantiate (Resources.Load ("Prefabs/Cards/Indian"))as GameObject;
		Cards [(int)CardTypes.Prison]           = Instantiate (Resources.Load ("Prefabs/Cards/Prison"))as GameObject;
		Cards [(int)CardTypes.Stagecoach]       = Instantiate (Resources.Load ("Prefabs/Cards/Stagecoach"))as GameObject;
		Cards [(int)CardTypes.Void]             = Instantiate (Resources.Load ("Prefabs/Cards/Void"))as GameObject;
		Cards [(int)CardTypes.WellsFargoBank]   = Instantiate (Resources.Load ("Prefabs/Cards/WellsFargoBank"))as GameObject;
		
		CardObject.SetActive (false);
		foreach (GameObject card in Cards) {  //Cards 안에 있는 카드들을 탐색
			card.transform.parent = CardObject.transform;
		}
		
		/* 카드 수량을 변경할 수 있다. */
		for (int n = 0; n < 25; n++)
			RestoreCard.Add (CardTypes.Bang);
		for (int n = 0; n < 5; n++)
			RestoreCard.Add (CardTypes.Beer);
		for (int n = 0; n < 3; n++)
			RestoreCard.Add (CardTypes.Beerkeg);
		for (int n = 0; n < 3; n++)
			RestoreCard.Add (CardTypes.Dynamite);
		for (int n = 0; n < 5; n++)
			RestoreCard.Add (CardTypes.Indian);
		for (int n = 0; n < 3; n++)
			RestoreCard.Add (CardTypes.Prison);
		for (int n = 0; n < 4; n++)
			RestoreCard.Add (CardTypes.Stagecoach);
		for (int n = 0; n < 10; n++)
			RestoreCard.Add (CardTypes.Void);
		for (int n = 0; n < 3; n++)
			RestoreCard.Add (CardTypes.WellsFargoBank);
	}
	
	/* 핸드에 카드를 만든다 */
	void Start() 
	{
		StartCoroutine(AddRandomCard (PlayerTypes.User, SlotTypes.SlotA));
		
		/*
        AddRandomCard (PlayerTypes.User, SlotTypes.SlotA);
        AddRandomCard (PlayerTypes.User, SlotTypes.SlotB);
        AddRandomCard (PlayerTypes.User, SlotTypes.SlotC);
        AddRandomCard (PlayerTypes.User, SlotTypes.SlotD);
        
        AddRandomCard (PlayerTypes.Computer_1, SlotTypes.SlotA);
        AddRandomCard (PlayerTypes.Computer_1, SlotTypes.SlotB);
        AddRandomCard (PlayerTypes.Computer_1, SlotTypes.SlotC);
        AddRandomCard (PlayerTypes.Computer_1, SlotTypes.SlotD);
        */
		
		/* 싱글톤 */
		if (cSingletone.Instance.State0 == 10) { // 시드케첨이면 10,
			charNum = 10;
		} else if (cSingletone.Instance.State0 == 20) { //주르도네이면 20,
			charNum = 20;
		} else if (cSingletone.Instance.State0 == 30) { //윌리더키드이면 30,
			charNum = 30;
		} else if (cSingletone.Instance.State0 == 40) { //슬랩더길러이면 40을 받음
			charNum = 40;
		}else
			charNum = 99; // 값을 못 받아올 경우 99
		
		if (cSingletone2.Instance.State1 == 50) { //보안관 진영이면 50,
			campNum = 50;
		} else if (cSingletone2.Instance.State1 == 60) // 무법자 진영이면 60을 받음
			campNum = 60;
		else
			campNum = 99; // 값을 못 받아올 경우 99
	}
	
	IEnumerator AddRandomCard(PlayerTypes playerType, SlotTypes slotType)
	{
		yield return new WaitForSeconds(0.5f); //호출한 함수에게 1초후에 깨워서 아래 기능을 수행하라는 정보를 넘겨준다.
		addRandCnt += 1;
		
		int index = (int)Random.Range (0, (int)RestoreCard.Count); //0부터 카드덱수량 사이의 값 중 하나가 랜덤으로 나옴
		CardTypes cardType = RestoreCard[index];
		RestoreCard.RemoveAt (index); //덱에서 나온 카드를 지워준다.
		
		Vector3 position = Vector3.zero;
		Quaternion rotation = Quaternion.identity;
		
		if (playerType == PlayerTypes.User)
		{
			Debug.Log("AddRandomCard by User");
			position = UserCardPosition(slotType);
			rotation = UserManagerScript.gameObject.transform.rotation;
			
			UserManagerScript.DrawCard[(int)slotType] 
			= Instantiate (Cards [(int)cardType], position, rotation) as GameObject;
			UserManagerScript.DrawCard[(int)slotType].GetComponent<Click> ().userType = playerType;
			UserManagerScript.DrawCard[(int)slotType].GetComponent<Click> ().cardType = cardType;
			UserManagerScript.DrawCard[(int)slotType].GetComponent<Click> ().slotType = slotType;
			UserManagerScript.DrawCard[(int)slotType].AddComponent<Make_In_Parent> ();
			
			switch(addRandCnt)
			{
			case 1: StartCoroutine(AddRandomCard (PlayerTypes.User, SlotTypes.SlotB)); break;
			case 2: StartCoroutine(AddRandomCard (PlayerTypes.User, SlotTypes.SlotC)); break;
			case 3: StartCoroutine(AddRandomCard (PlayerTypes.User, SlotTypes.SlotD)); break;
			}
			
			if(addRandCnt == 4)
				StartCoroutine(AddRandomCard (PlayerTypes.Computer_1, SlotTypes.SlotA));
		} 
		
		else
		{
			Debug.Log("AddRandomCard by Com");
			position = ComCardPosition(slotType);
			rotation = ComManagerScript.gameObject.transform.rotation;
			ComManagerScript.DrawCard[(int)slotType] 
			= Instantiate (Cards [(int)cardType], position, rotation) as GameObject;
			ComManagerScript.DrawCard[(int)slotType].GetComponent<Click> ().userType = playerType;
			ComManagerScript.DrawCard[(int)slotType].GetComponent<Click> ().cardType = cardType;
			ComManagerScript.DrawCard[(int)slotType].GetComponent<Click> ().slotType = slotType;
			ComManagerScript.DrawCard[(int)slotType].AddComponent<Make_In_Parent_Com> ();
			
			switch(addRandCnt)
			{
			case 5: StartCoroutine(AddRandomCard (PlayerTypes.Computer_1, SlotTypes.SlotB)); break;
			case 6: StartCoroutine(AddRandomCard (PlayerTypes.Computer_1, SlotTypes.SlotC)); break;
			case 7: StartCoroutine(AddRandomCard (PlayerTypes.Computer_1, SlotTypes.SlotD)); break;
			}
		}
		
		/*
        if (playerType == PlayerTypes.User)
        {
            UserManagerScript.DrawCard[(int)slotType].AddComponent<Make_In_Parent> ();
        } 
        else 
        {
            ComManagerScript.DrawCard[(int)slotType].AddComponent<Make_In_Parent_Com> ();
        }
        */
	}
	
	public GameObject CreateRandomCard()
	{
		int index = (int)Random.Range (0, (int)RestoreCard.Count);
		CardTypes cardType = RestoreCard[index];
		tempCardType = RestoreCard[index];
		
		RestoreCard.RemoveAt (index);
		
		return Instantiate (Cards [(int)cardType]) as GameObject;
	}
	
	//유저가 뱅에 맞았을 때, 빗나감 카드를 쓰겠다고 했을 때 호출되는 함수
	public void SelectVoidCard()
	{
		End_Turn endTurn = GameObject.Find ("ReadyButtonUI").GetComponent ("End_Turn") as End_Turn;
		EffectUI effectUIManager = GameObject.Find ("EffectUIManager").GetComponent ("EffectUI") as EffectUI;
		effectUIManager.hitBang.SetActive(false);
		Debug.Log("Select VoidCard");
		
		foreach (GameObject card in UserManagerScript.DrawCard) //유저 핸드에 Void 카드가 있는지 탐색
			if(card != null)
		{
			if (card.GetComponent<Click>().cardType == CardTypes.Void) //유저의 핸드에 Void 카드가 존재한다면
			{
				Debug.Log("Find VoidCard");
				card.GetComponent<Click>().CounterCom(); //빗나감 카드를 낸다.
				break;
			}
		}
		StartCoroutine(endTurn.comAI());
	}
	
	//유저가 뱅에 맞았을 때, 빗나감 카드를 쓰지 않겠다고 했을 때 호출되는 함수
	public void NoneSelectVoidCard()
	{
		End_Turn endTurn = GameObject.Find ("ReadyButtonUI").GetComponent ("End_Turn") as End_Turn;
		EffectUI effectUIManager = GameObject.Find ("EffectUIManager").GetComponent ("EffectUI") as EffectUI;
		Debug.Log("No Select VoidCard");
		effectUIManager.hitBang.SetActive(false);
		StartCoroutine(endTurn.comAI());
	}
	
	//술통 관련 주사위 던지기 UI 함수
	public void beerkegThrowDice()
	{
		EffectUI effectUIManager = GameObject.Find ("EffectUIManager").GetComponent ("EffectUI") as EffectUI;
		ClickDice clickDice = GameObject.Find ("Dice").GetComponent ("ClickDice") as ClickDice;
		End_Turn endTurn = GameObject.Find ("ReadyButtonUI").GetComponent ("End_Turn") as End_Turn;
		Debug.Log("Press beerkegThrowDice Button");
		effectUIManager.beerkeg.SetActive(false);
		clickDice.OnMouseDown(); //버튼을 누르면 주사위를 던짐
		
		if(clickDice.value > 4) //나온 주사위 값이 5이상이면
			Debug.Log("Void by Beerkeg"); //피 1 안 줄어듬
		else //주사위 값이 4이하면
			UserManagerScript.Hurt (1); //유저 1 깎아라
		
		StartCoroutine(endTurn.comAI());
	}
	
	//컴퓨터 술통 관련 주사위 던지기 UI 함수
	public void com_beerkegThrowDice()
	{
		EffectUI effectUIManager = GameObject.Find ("EffectUIManager").GetComponent ("EffectUI") as EffectUI;
		ClickDice clickDice = GameObject.Find ("Dice").GetComponent ("ClickDice") as ClickDice;
		End_Turn endTurn = GameObject.Find ("ReadyButtonUI").GetComponent ("End_Turn") as End_Turn;
		Debug.Log("Press beerkegThrowDice Button");
		
		clickDice.OnMouseDown(); //버튼을 누르면 주사위를 던짐
		
		if(clickDice.value > 4) //나온 주사위 값이 5이상이면
		{
			Debug.Log("Void by Beerkeg"); //피 1 안 줄어듬
			effectUIManager.beerkegUseCom.SetActive(true);
		}
		
		else
		{
			ComManagerScript.Hurt (1); //컴퓨터의 피 1 깎아라
			effectUIManager.beerkegFailCom.SetActive(true);
		}			
	}
	
	//감옥 관련 주사위 던지기 UI 함수
	public void prisonThrowDice()
	{
		EffectUI effectUIManager = GameObject.Find ("EffectUIManager").GetComponent ("EffectUI") as EffectUI;
		ClickDice clickDice = GameObject.Find ("Dice").GetComponent ("ClickDice") as ClickDice;
		End_Turn endTurn = GameObject.Find ("ReadyButtonUI").GetComponent ("End_Turn") as End_Turn;
		
		Debug.Log("Press prisonThrowDice Button");
		effectUIManager.prison.SetActive(false);
		clickDice.OnMouseDown(); //버튼을 누르면 주사위를 던짐
		Destroy(UserManagerScript.Prison_User);
		
		if(clickDice.value > 3) //나온 주사위 값이 4이상이면
		{
			UserManagerScript.Prison_User = null;
		}
		else //주사위 값이 3이하면
		{
			UserManagerScript.Prison_User = null;
			StartCoroutine(endTurn.changeToComTurn());
		}
	}
	
	//감옥 관련 컴퓨터 주사위 던지기 UI 함수
	public void Com_prisonThrowDice()
	{
		EffectUI effectUIManager = GameObject.Find ("EffectUIManager").GetComponent ("EffectUI") as EffectUI;
		ClickDice clickDice = GameObject.Find ("Dice").GetComponent ("ClickDice") as ClickDice;
		End_Turn endTurn = GameObject.Find ("Button").GetComponent ("End_Turn") as End_Turn;
		Debug.Log("Com-PrisonThrowDice");
		
		clickDice.OnMouseDown(); //버튼을 누르면 주사위를 던짐
		
		if(clickDice.value > 3) //나온 주사위 값이 4이상이면
		{
			Destroy(ComManagerScript.Prison_Com);
			ComManagerScript.Prison_Com = null;
			effectUIManager.prison_com_escape.SetActive(true);
		}
		else //주사위 값이 3이하면
		{
			Destroy(ComManagerScript.Prison_Com);
			ComManagerScript.Prison_Com = null;
			effectUIManager.in_prison_com.SetActive(true);
			endTurn.OnClickStart ();
		}
	}
	
	public void comEscape()
	{
		EffectUI effectUIManager = GameObject.Find ("EffectUIManager").GetComponent ("EffectUI") as EffectUI;
		End_Turn endTurn = GameObject.Find ("ReadyButtonUI").GetComponent ("End_Turn") as End_Turn;
		effectUIManager.prison_com_escape.SetActive(false);
		StartCoroutine(endTurn.comAI());
	}
	
	public void comInPrison()
	{
		EffectUI effectUIManager = GameObject.Find ("EffectUIManager").GetComponent ("EffectUI") as EffectUI;
		End_Turn endTurn = GameObject.Find ("ReadyButtonUI").GetComponent ("End_Turn") as End_Turn;
		effectUIManager.in_prison_com.SetActive(false);
		endTurn.OnClickStart ();
	}
	
	//다이너마이트 관련 주사위 던지기 UI 함수
	public void dynamiteThrowDice()
	{
		EffectUI effectUIManager = GameObject.Find ("EffectUIManager").GetComponent ("EffectUI") as EffectUI;
		ClickDice clickDice = GameObject.Find ("Dice").GetComponent ("ClickDice") as ClickDice;
		End_Turn endTurn = GameObject.Find ("ReadyButtonUI").GetComponent ("End_Turn") as End_Turn;
		
		Debug.Log("Press dynamiteThrowDice Button");
		effectUIManager.userDynamite.SetActive(false);
		effectUIManager.comDynamite.SetActive(false);
		
		clickDice.OnMouseDown(); //버튼을 누르면 주사위를 던짐
		
		//userDynamiteSet 변수가 비어있지 않고, 주사위를 던져서 나온 값이 5, 6이면
		if(userState == UserState.User && userDynamiteSet != null && clickDice.value > 4) 
		{
			UserManagerScript.Hurt(3); //유저에게 3데미지 입힘
			Destroy(userDynamiteSet);

			/*
			if(UserManagerScript.hp < 1)
			{
				effectUIManager.gameOver.SetActive(true);
				StopCoroutine(endTurn.comAI());

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
                effectUIManager.beerkegUseCom.SetActive(false);
			}
			*/
			if(UserManagerScript.Prison_User != null)
				effectUIManager.prison.SetActive(true);
			
			dynamiteState = DynamiteStates.Off;
			userDynamiteSet = null;			
		}
		
		else if(userState == UserState.User && userDynamiteSet != null && clickDice.value < 5)
		{
			userDynamiteSet.transform.position = userDynamiteSet.GetComponent<Click>().UsePosition (PlayerTypes.Computer_1);
			comDynamiteSet = userDynamiteSet; //컴퓨터로 다이너마이트 카드를 넘김
			userDynamiteSet = null;
			
			if(UserManagerScript.hp < 1)
			{
				effectUIManager.gameOver.SetActive(true);
				StopCoroutine(endTurn.comAI());
			}
			else if(ComManagerScript.hp < 1)
				effectUIManager.userWin.SetActive(true);
			else if(UserManagerScript.Prison_User != null)
				effectUIManager.prison.SetActive(true);
		}
		
		else if(userState == UserState.Com && comDynamiteSet != null && clickDice.value > 4)
		{
			ComManagerScript.Hurt(3);
			Destroy(comDynamiteSet);

			/*
			if(ComManagerScript.hp < 1)
			{
				effectUIManager.userWin.SetActive(true);
				StopCoroutine(endTurn.comAI());

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
                effectUIManager.beerkegUseCom.SetActive(false);
			}
			*/
			if(ComManagerScript.Prison_Com != null)
			{
				Debug.Log("Prison_Com is not null");
				Com_prisonThrowDice();
			}
			
			dynamiteState = DynamiteStates.Off;
			comDynamiteSet = null;			
			
			StartCoroutine(endTurn.comAI());
		}
		
		else if(userState == UserState.Com && comDynamiteSet != null && clickDice.value < 5)
		{
			comDynamiteSet.transform.position = comDynamiteSet.GetComponent<Click>().UsePosition (PlayerTypes.User);
			userDynamiteSet = comDynamiteSet; //유저로 다이너마이트 카드를 넘김
			comDynamiteSet = null;
			
			if(UserManagerScript.hp < 1)
			{
				effectUIManager.userWin.SetActive(true);
				StopCoroutine(endTurn.comAI());
			}
			else if(ComManagerScript.hp < 1)
                effectUIManager.userWin.SetActive(true);
            else if(ComManagerScript.Prison_Com != null)
            {
                Debug.Log("Prison_Com is not null");
                Com_prisonThrowDice();
            }
            
            StartCoroutine(endTurn.comAI());
        }
    }
    
    public void haveBangIndian()
    {
        EffectUI effectUIManager = GameObject.Find ("EffectUIManager").GetComponent ("EffectUI") as EffectUI;
        End_Turn endTurn = GameObject.Find ("ReadyButtonUI").GetComponent ("End_Turn") as End_Turn;
        effectUIManager.haveBangIndian.SetActive(false);
        
        foreach (GameObject card in UserManagerScript.DrawCard) //컴퓨터의 핸드를 탐색한다.
			if(card != null)
		{
			if (card.GetComponent<Click>().cardType == CardTypes.Bang) //컴퓨터의 핸드에 'Bang카드'가 존재한다면
			{
				card.transform.parent = GameObject.Find ("UseCard").transform; //찾은 'Bang카드'는 UseCard의 자식으로
				card.transform.position = card.GetComponent<Click>().UsePosition (PlayerTypes.User);
				card.GetComponent<Click>().useCheck = Click.UseCheck.Use; //컴퓨터가 낸 'Bang 카드'는 사용 된 카드라고 갱신
				switch (card.GetComponent<Click>().slotType)
				{
				case SlotTypes.SlotA: UserManagerScript.DrawCard[0] = null; break;
				case SlotTypes.SlotB: UserManagerScript.DrawCard[1] = null; break;
				case SlotTypes.SlotC: UserManagerScript.DrawCard[2] = null; break;
				case SlotTypes.SlotD: UserManagerScript.DrawCard[3] = null; break;
                } 
                break;
            }
		}            
        StartCoroutine(endTurn.comAI());
    }
    
    public void NotHaveBangIndian()
    {
        EffectUI effectUIManager = GameObject.Find ("EffectUIManager").GetComponent ("EffectUI") as EffectUI;
        End_Turn endTurn = GameObject.Find ("ReadyButtonUI").GetComponent ("End_Turn") as End_Turn;
        effectUIManager.notHaveBangIndian.SetActive(false);
        
        UserManagerScript.Hurt(1);
        StartCoroutine(endTurn.comAI());
    }
    
    public void ReTry()
    {
        EffectUI effectUIManager = GameObject.Find ("EffectUIManager").GetComponent ("EffectUI") as EffectUI;
        End_Turn endTurn = GameObject.Find ("ReadyButtonUI").GetComponent ("End_Turn") as End_Turn;
        effectUIManager.gameOver.SetActive(false);
        effectUIManager.userWin.SetActive(false);
        
        Application.LoadLevel(24);
    }
    
    public void ReturnToMain()
    {
        EffectUI effectUIManager = GameObject.Find ("EffectUIManager").GetComponent ("EffectUI") as EffectUI;
        End_Turn endTurn = GameObject.Find ("ReadyButtonUI").GetComponent ("End_Turn") as End_Turn;
        effectUIManager.gameOver.SetActive(false);
        effectUIManager.userWin.SetActive(false);
        
		Application.LoadLevel(0);
    }
    
    public void BeerkegButton()
    {
        EffectUI effectUIManager = GameObject.Find ("EffectUIManager").GetComponent ("EffectUI") as EffectUI;
        End_Turn endTurn = GameObject.Find ("ReadyButtonUI").GetComponent ("End_Turn") as End_Turn;
        effectUIManager.beerkegUseCom.SetActive(false);
        effectUIManager.beerkegFailCom.SetActive(false);
    }
}
