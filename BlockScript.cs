using UnityEngine;
using System.Collections;

public class BlockScript : MonoBehaviour {

	public static bool istrigger=false;

	public int hp;

	GameObject block;
	ParticleSystem ps;
	Collider col;
	AudioSource SE;

	// Use this for initialization
	void Start () {
		SE = GetComponent<AudioSource> ();
		block=transform.FindChild ("Block").gameObject;
		ManagerScript.blocknum++;
		col = GetComponent<Collider> ();
		ps = GetComponent<ParticleSystem> ();
	}

	void Update(){
		col.isTrigger = istrigger;
	}
	
	void OnCollisionEnter(Collision c){
		if(c.gameObject.tag=="Ball")
		BBreak (c.gameObject);
	}

	void OnTriggerEnter(Collider c){
		if(c.tag=="Ball")
		BBreak (c.gameObject);
	}

	void BBreak(GameObject c){
		hp--;
		SE.Play ();
		ManagerScript.blocknum--;
		if (hp <= 0) {
			ScoreManagerScript.AddScore ();
			block.SetActive (false);
			col.enabled = false;
		}
		ps.Play ();
	}
}
