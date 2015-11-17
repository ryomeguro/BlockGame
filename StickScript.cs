using UnityEngine;
using System.Collections;

public class StickScript : MonoBehaviour {

	public float MaxX;
	Transform s_tra;
	Transform b_tra;
	// Use this for initialization
	void Start () {
		s_tra = GetComponent<Transform> ();
		b_tra = GameObject.Find ("Ball").transform;
	}
	
	// Update is called once per frame
	void Update () {
		float posy = Camera.main.ScreenToWorldPoint (Input.mousePosition).x;
		transform.position=new Vector3(Mathf.Clamp (posy, -MaxX, MaxX),0,s_tra.position.z);
	}

	void OnTriggerEnter(Collider c){
		if (c.tag == "Item") {
			c.GetComponent<ItemScript> ().ItemEffect();
		}
	}
}
