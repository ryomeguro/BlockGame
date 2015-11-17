using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ManagerScript : MonoBehaviour {

	public static  int blocknum=0;
	public static float ball_Speed = 5;
	public static int HP = 4;
	public static float speed_time = 0;

	public Vector3 startPos = new Vector3 (0, 0, 0);
	public Animator[] Arrows;

	float respawn_during=2.5f;
	float respawn_time=10;
	bool respawn_flg=false;
	GameObject ball;
	Rigidbody ballrigid;
	Animator anim_ball;
	Animator anim_cam;
	Vector3 ball_Scale;


	// Use this for initialization
	void Start () {
		ball = GameObject.Find ("Ball");
		anim_ball=ball.GetComponent<Animator> ();
		ballrigid = ball.GetComponent<Rigidbody> ();
		ball_Scale = ball.transform.localScale;
		anim_cam = GameObject.Find ("Main Camera").GetComponent<Animator> ();
		Restart ();

	}
	
	// Update is called once per frame
	void Update () {

		if (respawn_flg) {
			respawn_time += Time.deltaTime;
		}

		if (respawn_time < respawn_during) {
			ballrigid.velocity = Vector3.zero;
		}

		//Debug.Log (blocknum);
		if (blocknum <= 0) {
			//Debug.Log ("CLear");
		}

		speed_time += Time.deltaTime;
		ball_Speed = 5 + speed_time * 0.05f;//-----6,0.05
		//Debug.Log (ball_Speed);
		//Debug.Log ("time=" + speed_time + " vel=" + ball_Speed);
	}

	void OnTriggerEnter(Collider c){
		if (c.tag == "Ball") {
			Debug.Log ("out");
			Restart ();
		}
	}

	void Restart(){
		HP--;
		ScoreManagerScript.ReText ();
		if (HP > 0) {
			respawn_flg = true;
			respawn_time = 0;
			ball.transform.localScale = Vector3.zero;
			Invoke ("AddVec", respawn_during);
			ballrigid.velocity = Vector3.zero;
			//anim_ball.SetTrigger ("Respawn");
			iTween.ScaleTo (ball, iTween.Hash ("scale", ball_Scale, "easetype", iTween.EaseType.easeOutExpo, "time", respawn_during));
			ball.transform.position = startPos;
			anim_cam.SetTrigger ("Respawn");
			foreach (Animator a in Arrows) {
				a.SetTrigger ("Respawn");
			}
		} else {
			GameOver ();
		}
	}

	void AddVec(){
		speed_time = 0;
		respawn_flg = false;
		respawn_time = 10;
		ballrigid.velocity = Vector3.back * ball_Speed;
	}

	void GameOver(){
		Debug.Log ("GameOver");
	}
		
}
