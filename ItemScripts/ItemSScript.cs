using UnityEngine;
using System.Collections;

public class ItemSScript : ItemScript{

	// Use this for initialization
	void Start () {
	
	}

	public override void ItemEffect(){
		if (ManagerScript.speed_time - 40 > 0) {
			ManagerScript.speed_time -= 40f;
		} else {
			ManagerScript.speed_time = 0;
		}
		transform.position = Vector3.left * 100;
		isapper = false;
	}
}
