using UnityEngine;
using System.Collections;

public class PlayManager : MonoBehaviour {

	public void start() {

		Application.LoadLevel ("Camp");
}
	public void GameRule1() {
		
		Application.LoadLevel ("GameRule1");
	}
	
	public void Setting() {
	
		Application.LoadLevel ("Setting");
	}

	public void Quit() {
	
		Application.Quit();
	}
}