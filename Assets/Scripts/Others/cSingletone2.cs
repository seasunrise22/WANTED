using UnityEngine;
using System.Collections;

public class cSingletone2 : MonoBehaviour {

	private static cSingletone2 _instance = null;
	
	public static cSingletone2 Instance
	{
		get
		{
			if (_instance == null)
				Debug.LogError("cSingletone == null");
			return _instance;
			
		}
	}
	
	void Awake()
	{
		_instance = this;
		DontDestroyOnLoad ( this );
	}

	public int State1 = 0;	
	
	// 멤버 함수

	public int SetcSingletone2(int state2)
	{		
		State1 = state2;
		return State1;
	}
}
