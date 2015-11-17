using UnityEngine;
using System.Collections;

public class ItemFScript : ItemScript{

	// Use this for initialization
	void Start () {
	
	}

	public override void ItemEffect(){
		ManagerScript.speed_time += 40f;
		transform.position = Vector3.left * 100;
		isapper = false;
	}
}
