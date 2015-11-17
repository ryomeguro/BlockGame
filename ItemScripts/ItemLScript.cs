using UnityEngine;
using System.Collections;

public class ItemLScript : ItemScript {

	GameObject stick;

	// Use this for initialization
	void Start () {
		stick = GameObject.Find ("Stick");
	}
	
	public override void ItemEffect(){
		transform.position = Vector3.left * 100;
		iTween.ScaleTo (stick, iTween.Hash ("x", 2, "time", 0.5f));
		Invoke ("InvokeA", 10);
	}

	void InvokeA(){
		iTween.ScaleTo (stick, iTween.Hash ("x", 1, "time", 0.5f));
		isapper = false;
	}
}
