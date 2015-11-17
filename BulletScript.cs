using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	bool isAppear=false;
	TrailRenderer tr;
	Rigidbody rigid;

	public bool shot_Enable=true;

	// Use this for initialization
	void Start () {
		tr = GetComponent<TrailRenderer> ();
		rigid = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isAppear) {
			//transform.Translate (Vector3.up*0.3f);
			rigid.velocity = Vector3.forward * 24f;
		}
		if (transform.position.z > 6.3f) {
			SetFalse ();
			Debug.Log("BulletOut");
		}
	}

	void OnTriggerEnter(Collider c){
		if (c.tag == "Block") {
			Debug.Log (c);
			SetFalse ();
			rigid.velocity = Vector3.zero;
		}
	}

	void SetFalse(){
		isAppear = false;
		tr.enabled = false;
		shot_Enable = true;
		transform.position = Vector3.left * 50;
	}

	public void SetTrue(){
		isAppear = true;
		tr.enabled = true;
		shot_Enable = false;
	}
}
