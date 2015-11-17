using UnityEngine;
using System.Collections;

public class ItemHScript : ItemScript {



	public override void ItemEffect(){
		transform.position = Vector3.left * 100;
		ManagerScript.HP++;
		ScoreManagerScript.ReText ();
		isapper = false;
	}
}
