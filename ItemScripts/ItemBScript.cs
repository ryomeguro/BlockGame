using UnityEngine;
using System.Collections;

public class ItemBScript : ItemScript{

	GameObject ball;

	// Use this for initialization
	void Start () {
		ball = GameObject.Find ("Ball");
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();
	}

	public override void ItemEffect(){
		BlockScript.istrigger = true;
		transform.position = Vector3.left * 100f;
		Invoke ("InvokeA", 7f);
	}

	void InvokeA(){
		BlockScript.istrigger = false;
		isapper = false;
	}


}
