# WANTED
- 개발인원 : 3명
- 역할
  - 카드 생성 및 드로우
  - 컴퓨터 인공지능(패턴)
  - 카드 효과 등 게임 전반적인 기능 구현
  - 팀장
## Introduction
오프라인 보드게임 ‘뱅’을 모티브로 제작한 카드게임입니다. 

여러 사람이 모여야 할 수 있는 보드게임을 혼자서도 컴퓨터를 상대로 즐길 수 있었으면 좋겠다는 생각에서 개발했습니다. 

게임의 주된 흐름은 다음과 같습니다.

1. 인트로 화면, 메인 화면, 진영선택, 캐릭터 선택 이후 게임 화면으로 넘어갑니다.
2. 진영과 캐릭터에 따라 서로 다른 효과가 부여됩니다.
3. 게임이 시작되면 유저와 컴퓨터에게 랜덤으로 카드를 부여합니다.
4. 유저와 컴퓨터는 서로 번갈아 적절한 카드를 사용해야 하며, 상대방의 라이프(생명력)를 0으로 만들기 위해 싸웁니다.

## Development Environment
- IDE : Unity 4.55
- Language : C#
## Screenshots
![work_wanted01](https://user-images.githubusercontent.com/45503931/56092752-d92dc080-5efa-11e9-82bb-308334246d0c.png)
![work_wanted02](https://user-images.githubusercontent.com/45503931/56092753-d92dc080-5efa-11e9-8d49-a7172a94f854.png)
![work_wanted03](https://user-images.githubusercontent.com/45503931/56092754-d9c65700-5efa-11e9-81f5-2f173b36807d.png)
![work_wanted04](https://user-images.githubusercontent.com/45503931/56092755-d9c65700-5efa-11e9-94e9-8d933874127c.png)
![work_wanted05](https://user-images.githubusercontent.com/45503931/56092756-d9c65700-5efa-11e9-8a91-6428820fff22.png)
![work_wanted06](https://user-images.githubusercontent.com/45503931/56092757-d9c65700-5efa-11e9-8044-c4a0f612dfb3.png)
![work_wanted07](https://user-images.githubusercontent.com/45503931/56092758-da5eed80-5efa-11e9-99f5-a7dbd82ccaf6.png)

## Code Preview
***턴의 관리***
```C#
public enum UserState
{
	None,
	User,
	Com
}
...

//userDynamiteSet 변수가 비어있지 않고, 주사위를 던져서 나온 값이 5, 6이면
if(userState == UserState.User && userDynamiteSet != null && clickDice.value > 4) 
{
	UserManagerScript.Hurt(3); //유저에게 3데미지 입힘
	Destroy(userDynamiteSet);
	...
}
```
enum의 값과 조건문으로 턴과 턴에 해당하는 행동들을 관리합니다.

***카드 드로우***
```C#
IEnumerator AddRandomCard(PlayerTypes playerType, SlotTypes slotType)
{
	yield return new WaitForSeconds(0.5f); //호출한 함수에게 1초후에 깨워서 아래 기능을 수행하라는 정보를 넘겨준다.
	addRandCnt += 1;
	...
	
	if (playerType == PlayerTypes.User) // 유저턴이라면
	{
	position = UserCardPosition(slotType);
	rotation = UserManagerScript.gameObject.transform.rotation;
	UserManagerScript.DrawCard[(int)slotType]
	= Instantiate (Cards [(int)cardType], position, rotation) as GameObject;
	...
	switch(addRandCnt) // 재귀 걸리게 하는 조건
	{
	case 1: StartCoroutine(AddRandomCard (PlayerTypes.User, SlotTypes.SlotB)); break;
	case 2: StartCoroutine(AddRandomCard (PlayerTypes.User, SlotTypes.SlotC)); break;
	case 3: StartCoroutine(AddRandomCard (PlayerTypes.User, SlotTypes.SlotD)); break;
	}
	if(addRandCnt == 4)
	// 컴퓨터턴으로 넘기고 컴퓨터 카드 드로우
	StartCoroutine(AddRandomCard (PlayerTypes.Computer_1, SlotTypes.SlotA)); 
} 
```
빈 슬롯에 카드 프리팹을 생성하는 AddRandomCard함수를 coroutine으로 딜레이시켜 재귀 돌리는 방식으로 유저와 컴퓨터에게 각각 카드를 줍니다. 

***컴퓨터 인공지능***
```C#
public IEnumerator comAI()
{
yield return null;
InfoManager infoManager = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
yield return new WaitForSeconds(1f); //호출한 함수에게 0.5초후에 깨워서 아래 기능을 수행하라는 정보를 넘겨준다. 
int nullCnt = handCnt(); 
foreach(GameObject card in infoManager.ComManagerScript.DrawCard) //컴퓨터 핸드에 있는 카드를 탐색한다.
{
	if(card != null)
	{
	//핸드의 빈공간 상황에 따라 적절한 드로우 카드를 쓰게하는 알고리즘
	if(nullCnt > 0 && card.GetComponent<Click>().cardType == CardTypes.Stagecoach)
	{
	card.GetComponent<Click>().OnMouseDown();
	break;
	}
	else if(nullCnt > 2 && card.GetComponent<Click>().cardType == CardTypes.WellsFargoBank)
	{
	card.GetComponent<Click>().OnMouseDown();
	break;
	}
	//현재 풀피가 아니면서 핸드에 맥주카드가 있을 경우
	else if(infoManager.ComManagerScript.hp != 5 && card.GetComponent<Click>().cardType == CardTypes.Beer) 
	{
	card.GetComponent<Click>().OnMouseDown();
	break;
	}
	... 조건문 계속
}
```
유저가 턴을 넘기면 컴퓨터가 미리 정해놓은 우선순위에 따라 알아서 행동하도록 만드는 comAI 함수를 Coroutine으로 순차적 호출하게 됩니다.
comAI 함수에서는 컴퓨터가 가지고 있는 카드를 탐색한 뒤, 컴퓨터의 핸드 빈공간 상황에 따라 미리 우선순위를 매겨둔 카드를 순서대로 사용하도록 조건문을 활용해 구현하였습니다.

## Android 빌드시 오류날 때 해봄직한 대처들
유니티 버전 4.55.

UNITY 빌드시 Player Settings > Minimum API Level 4.4 KitKat 설정.

SDK 4.4 이상 전부 설치(안드로이드 스튜디오 버전 4.2.1).

JDK 버전 8.

SDK 설치된 폴더로 간 후 기존 tools 폴더 이름 변경 후 tools_r25.2.5-windows 압축파일을 풀어서 이름 tools로 바꾼 후 SDK폴더에 넣어줌.

Player Settings의 Bundle Identifier 양식에 맞게 변경 (com.project.wanted로 변경함).
