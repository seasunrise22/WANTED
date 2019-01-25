using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
			if (audio.mute)
				audio.mute = false;
		else
			audio.mute = true;
	}

	void Awake () {
		DontDestroyOnLoad ( this.gameObject );
	}

}
