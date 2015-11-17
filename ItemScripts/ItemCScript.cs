using UnityEngine;
using System.Collections;

public class ItemCScript : ItemScript {

	Transform ball;
	GameObject cpu;
	MeshCollider cpuC;

	// Use this for initialization
	void Start () {
		ball = GameObject.Find ("Ball").transform;
		cpu = GameObject.Find ("CPU");
		cpuC = cpu.GetComponent<MeshCollider> ();
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();
		Vector3 cpos = cpu.transform.position;
		Vector3 bpos = new Vector3 (ball.position.x, 0, cpos.z);
		cpu.transform.position = Vector3.Lerp(cpos,bpos,0.3f);
	}

	public override void ItemEffect(){
		cpuC.enabled = true;
		iTween.MoveTo (cpu, iTween.Hash ("z", -4.06f, "time", 0.5f));
		transform.position = Vector3.left * 100f;
		Invoke ("InvokepB", 10f);
	}

	void InvokepB(){
		cpuC.enabled = false;
		isapper = false;
		iTween.MoveTo (cpu, iTween.Hash ("z", -5.17f, "time", 0.7f));
	}
}
