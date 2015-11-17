using UnityEngine;
using System.Collections;

public class BGMScript : MonoBehaviour {

	public float duration;

	bool playflg=true;
	AudioSource bgm;

	// Use this for initialization
	void Start () {
		bgm = GetComponent<AudioSource> ();
		bgmPlay ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void bgmPlay(){
		bgm.Play ();
		if (playflg) {
			Invoke ("bgmPlay", duration);
		}
	}

	public void Play(){

	}

	public void Stop(){

	}

}
