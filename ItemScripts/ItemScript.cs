using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour {

	public bool isapper=false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void Update () {
		transform.Translate (Vector3.back * 0.03f);
	}

	public virtual void ItemEffect (){

	}

	public void OnTriggerEnter(Collider c){
		if (c.tag == "Manager") {
			isapper = false;
		}
	}
		
}
