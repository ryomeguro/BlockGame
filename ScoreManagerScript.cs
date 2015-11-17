using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour {

	static int score=0;
	static Text scoreT,hpT;

	// Use this for initialization
	void Start () {
		scoreT = GameObject.Find ("ScoreText").GetComponent<Text>();
		hpT = GameObject.Find ("HUD").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void ReText(){
		scoreT.text = "SCORE\n" + score.ToString("0000000");
		hpT.text="♥✕"+ManagerScript.HP;
	}

	public static void AddScore(){
		score += (int)(ManagerScript.ball_Speed * 10);
		ReText ();
	}
}
