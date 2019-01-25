using UnityEngine;
using System.Collections;

public class cSingletone : MonoBehaviour {


	private static cSingletone _instance = null;
	
	public static cSingletone Instance
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
	
	public int State0 = 0;

	// 멤버 함수
	
	public int SetcSingletone(int state)
	{		
		State0 = state;
		return State0;
	}
}