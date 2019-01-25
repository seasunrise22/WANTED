using UnityEngine;
using System.Collections;

public enum ComSetState
{
	None,
	On,
	Off
}

public class ComManager : MonoBehaviour
{
	/**** 변수 선언 및 정의 ****/
	public GameObject[] DrawCard = new GameObject[(int)SlotTypes.Max];
	public CardTypes cardType;
	
	public UISlider LifeBar; //라이프바를 관리하는 컴포넌트인 UISlider 타입의 변수 LifeBar
	public float Max_hp = 5; //최대체력
	public float hp = 5; //현재체력
	public bool useBang = false;
	
	public ComSetState comSetState = ComSetState.None; //세트카드를 썼는가 안 썼는가 나타낼 함수
	public GameObject nowSettingCard;
	public GameObject Prison_Com; //감옥 쳐맞으면 여기로 넣을거임 
	
	public GameObject BackCardA;
	public GameObject BackCardB;
	public GameObject BackCardC;
	public GameObject BackCardD;
	
	/**** 함수 선언 및 정의 ****/
	void Start()
	{
		LifeBar = transform.GetComponentInChildren<UISlider> ();
		Card_Back_Make ();
	}
	
	void Update()
	{
		EffectUI effectUIManager = GameObject.Find ("EffectUIManager").GetComponent ("EffectUI") as EffectUI;
		End_Turn endTurn = GameObject.Find ("ReadyButtonUI").GetComponent ("End_Turn") as End_Turn;

		Card_Back_True ();
		Card_Back_False ();

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
			effectUIManager.beerkegUseCom.SetActive(false);
			*/
		}
	}
	
	public void Card_Back_Make(){
		InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
		//float BackDynamicZgap = -3f;
		Quaternion rotation = Quaternion.identity;
		
		BackCardA = Instantiate (Resources.Load ("Prefabs/Cards/Card_Back"), new Vector3 (-4.486496f, 4.233363f, -2f), rotation)as GameObject;
		BackCardB = Instantiate (Resources.Load ("Prefabs/Cards/Card_Back"), new Vector3 (-2.072048f, 4.233363f, -2f), rotation)as GameObject;
		BackCardC = Instantiate (Resources.Load ("Prefabs/Cards/Card_Back"), new Vector3 (0.2765034f, 4.233363f, -2f), rotation)as GameObject;
		BackCardD = Instantiate (Resources.Load ("Prefabs/Cards/Card_Back"), new Vector3 (2.519447f, 4.233363f, -2f), rotation)as GameObject;
	}
	
	public void Card_Back_True(){
		if (GameObject.Find ("Com_SlotA").transform.GetChildCount () == 1)
			BackCardA.SetActive (true);
		if (GameObject.Find ("Com_SlotB").transform.GetChildCount () == 1) 
			BackCardB.SetActive (true);
		if (GameObject.Find ("Com_SlotC").transform.GetChildCount () == 1) 
			BackCardC.SetActive (true);
		if (GameObject.Find ("Com_SlotD").transform.GetChildCount () == 1) 
			BackCardD.SetActive (true);
		
	}
	
	public void Card_Back_False(){
		if (GameObject.Find ("Com_SlotA").transform.GetChildCount () == 0)
			BackCardA.SetActive (false);
		if (GameObject.Find ("Com_SlotB").transform.GetChildCount () == 0) 
			BackCardB.SetActive (false);
		if (GameObject.Find ("Com_SlotC").transform.GetChildCount () == 0) 
			BackCardC.SetActive (false);
		if (GameObject.Find ("Com_SlotD").transform.GetChildCount () == 0) 
			BackCardD.SetActive (false);
	}
	
	public IEnumerator Com_addCard()
	{
		Debug.Log("Com_addCard");
		yield return new WaitForSeconds(1f);
		InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
		if (GameObject.Find ("Com_SlotA").transform.GetChildCount () == 0) 
		{
			DrawCard[(int)SlotTypes.SlotA] = infoManager.CreateRandomCard();
			DrawCard[(int)SlotTypes.SlotA].transform.position = InfoManager.ComCardPosition(SlotTypes.SlotA);
			DrawCard[(int)SlotTypes.SlotA].transform.rotation = transform.rotation;
			DrawCard[(int)SlotTypes.SlotA].transform.parent = GameObject.Find ("Com_SlotA").transform;
			DrawCard[(int)SlotTypes.SlotA].GetComponent<Click>().userType = PlayerTypes.Computer_1;	
			DrawCard[(int)SlotTypes.SlotA].GetComponent<Click>().cardType = infoManager.tempCardType;
			DrawCard[(int)SlotTypes.SlotA].GetComponent<Click>().slotType = SlotTypes.SlotA;
		} 
		
		else if (GameObject.Find ("Com_SlotB").transform.GetChildCount () == 0) 
		{
			DrawCard[(int)SlotTypes.SlotB] = infoManager.CreateRandomCard();
			DrawCard[(int)SlotTypes.SlotB].transform.position = InfoManager.ComCardPosition(SlotTypes.SlotB);
			DrawCard[(int)SlotTypes.SlotB].transform.rotation = transform.rotation;
			DrawCard[(int)SlotTypes.SlotB].transform.parent = GameObject.Find ("Com_SlotB").transform;
			DrawCard[(int)SlotTypes.SlotB].GetComponent<Click>().userType = PlayerTypes.Computer_1;	
			DrawCard[(int)SlotTypes.SlotB].GetComponent<Click>().cardType = infoManager.tempCardType;	
			DrawCard[(int)SlotTypes.SlotB].GetComponent<Click>().slotType = SlotTypes.SlotB;
		} 
		
		else if (GameObject.Find ("Com_SlotC").transform.GetChildCount () == 0) 
		{
			DrawCard[(int)SlotTypes.SlotC] = infoManager.CreateRandomCard();
			DrawCard[(int)SlotTypes.SlotC].transform.position = InfoManager.ComCardPosition(SlotTypes.SlotC);
			DrawCard[(int)SlotTypes.SlotC].transform.rotation = transform.rotation;
			DrawCard[(int)SlotTypes.SlotC].transform.parent = GameObject.Find ("Com_SlotC").transform;
			DrawCard[(int)SlotTypes.SlotC].GetComponent<Click>().userType = PlayerTypes.Computer_1;	
			DrawCard[(int)SlotTypes.SlotC].GetComponent<Click>().cardType = infoManager.tempCardType;
			DrawCard[(int)SlotTypes.SlotC].GetComponent<Click>().slotType = SlotTypes.SlotC;
		} 
		
		else if (GameObject.Find ("Com_SlotD").transform.GetChildCount () == 0) 
		{
			DrawCard[(int)SlotTypes.SlotD] = infoManager.CreateRandomCard();
			DrawCard[(int)SlotTypes.SlotD].transform.position = InfoManager.ComCardPosition(SlotTypes.SlotD);
			DrawCard[(int)SlotTypes.SlotD].transform.rotation = transform.rotation;
			DrawCard[(int)SlotTypes.SlotD].transform.parent = GameObject.Find ("Com_SlotD").transform;
			DrawCard[(int)SlotTypes.SlotD].GetComponent<Click>().userType = PlayerTypes.Computer_1;	
			DrawCard[(int)SlotTypes.SlotD].GetComponent<Click>().cardType = infoManager.tempCardType;
			DrawCard[(int)SlotTypes.SlotD].GetComponent<Click>().slotType = SlotTypes.SlotD;
		}	
		StartCoroutine("Com_addCard_2");
	}
	
	public IEnumerator Com_addCard_2()
	{
		Debug.Log("Com_addCard_2");
		yield return new WaitForSeconds(1f);
		End_Turn endTurn = GameObject.Find ("ReadyButtonUI").GetComponent ("End_Turn") as End_Turn;
		InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
		if (GameObject.Find ("Com_SlotA").transform.GetChildCount () == 0) 
		{
			DrawCard[(int)SlotTypes.SlotA] = infoManager.CreateRandomCard();
			DrawCard[(int)SlotTypes.SlotA].transform.position = InfoManager.ComCardPosition(SlotTypes.SlotA);
			DrawCard[(int)SlotTypes.SlotA].transform.rotation = transform.rotation;
			DrawCard[(int)SlotTypes.SlotA].transform.parent = GameObject.Find ("Com_SlotA").transform;
			DrawCard[(int)SlotTypes.SlotA].GetComponent<Click>().userType = PlayerTypes.Computer_1;	
			DrawCard[(int)SlotTypes.SlotA].GetComponent<Click>().cardType = infoManager.tempCardType;
			DrawCard[(int)SlotTypes.SlotA].GetComponent<Click>().slotType = SlotTypes.SlotA;
		} 
		
		else if (GameObject.Find ("Com_SlotB").transform.GetChildCount () == 0) 
		{
			DrawCard[(int)SlotTypes.SlotB] = infoManager.CreateRandomCard();
			DrawCard[(int)SlotTypes.SlotB].transform.position = InfoManager.ComCardPosition(SlotTypes.SlotB);
			DrawCard[(int)SlotTypes.SlotB].transform.rotation = transform.rotation;
			DrawCard[(int)SlotTypes.SlotB].transform.parent = GameObject.Find ("Com_SlotB").transform;
			DrawCard[(int)SlotTypes.SlotB].GetComponent<Click>().userType = PlayerTypes.Computer_1;	
			DrawCard[(int)SlotTypes.SlotB].GetComponent<Click>().cardType = infoManager.tempCardType;	
			DrawCard[(int)SlotTypes.SlotB].GetComponent<Click>().slotType = SlotTypes.SlotB;
		} 
		
		else if (GameObject.Find ("Com_SlotC").transform.GetChildCount () == 0) 
		{
			DrawCard[(int)SlotTypes.SlotC] = infoManager.CreateRandomCard();
			DrawCard[(int)SlotTypes.SlotC].transform.position = InfoManager.ComCardPosition(SlotTypes.SlotC);
			DrawCard[(int)SlotTypes.SlotC].transform.rotation = transform.rotation;
			DrawCard[(int)SlotTypes.SlotC].transform.parent = GameObject.Find ("Com_SlotC").transform;
			DrawCard[(int)SlotTypes.SlotC].GetComponent<Click>().userType = PlayerTypes.Computer_1;	
			DrawCard[(int)SlotTypes.SlotC].GetComponent<Click>().cardType = infoManager.tempCardType;
			DrawCard[(int)SlotTypes.SlotC].GetComponent<Click>().slotType = SlotTypes.SlotC;
		} 
		
		else if (GameObject.Find ("Com_SlotD").transform.GetChildCount () == 0) 
		{
			DrawCard[(int)SlotTypes.SlotD] = infoManager.CreateRandomCard();
			DrawCard[(int)SlotTypes.SlotD].transform.position = InfoManager.ComCardPosition(SlotTypes.SlotD);
			DrawCard[(int)SlotTypes.SlotD].transform.rotation = transform.rotation;
			DrawCard[(int)SlotTypes.SlotD].transform.parent = GameObject.Find ("Com_SlotD").transform;
			DrawCard[(int)SlotTypes.SlotD].GetComponent<Click>().userType = PlayerTypes.Computer_1;	
			DrawCard[(int)SlotTypes.SlotD].GetComponent<Click>().cardType = infoManager.tempCardType;
			DrawCard[(int)SlotTypes.SlotD].GetComponent<Click>().slotType = SlotTypes.SlotD;
		}
		StopCoroutine("Com_addCard_2");
	}
	
	public void Hurt(float damage) //컴퓨터가 유저에게 뱅을 맞았을 경우
	{
		EffectUI effectUIManager = GameObject.Find ("EffectUIManager").GetComponent ("EffectUI") as EffectUI;
		End_Turn endTurn = GameObject.Find ("ReadyButtonUI").GetComponent ("End_Turn") as End_Turn;
		Debug.Log("Hurt in ComManager");
		
		hp -= damage;
        LifeBar.sliderValue = hp / Max_hp; //slider.Value는 0과 1로 LifeBar의 GUI를 컨트롤 해줌        
    }

//맥주카드 효과
public void Beer(float heal){
    if (hp < 6 && hp > 0){
        hp += heal;
        LifeBar.sliderValue = hp / Max_hp; //slider.Value는 0과 1로 LifeBar의 GUI를 컨트롤 해줌.
    }
    
    if (hp <= 0){
    }
}
}