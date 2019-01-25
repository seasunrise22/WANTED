using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour {

	private static GameData s_Instance = null;
	
	public static GameData Instance
	{
		get
		{
			if (s_Instance == null)
			{
				s_Instance = new GameData();
			}
			return s_Instance;
		}
	}
	
	// 멤버 변수
	
	private int State;
	private int State1;
	private int State2;
	private int State3;
	private int State4;
	private int State5;
	
	
	// 멤버 함수

	public int SetGameData0( ){
		
		State = 0;
		return State;
		
	}

	public int SetGameData1( ){
		
		State = 1;
		return State;
		
	}

	public int SetGameData2( ){
		
		State = 2;
		return State;
		
	}

	public int SetGameData3( ){
		
		State = 3;
		return State;
		
	}

}
