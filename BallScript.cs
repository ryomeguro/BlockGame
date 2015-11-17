using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	public GameObject itemB,itemC,itemF,itemG,itemH,itemL,itemM,itemS;

	GameObject[] items;

	Rigidbody rb;
	float z0Time=0;
	// Use this for initialization
	void Start () {
		rb=GetComponent<Rigidbody> ();
		items=new GameObject[] { itemB, itemC, itemF, itemG, itemH, itemL, itemM, itemS };
		//rb.velocity = new Vector3 (0, 0, 6);
	}
	
	// Update is called once per frame
	void Update () {
		if (rb.velocity.z < 0.001f) {
			z0Time += Time.deltaTime;
		}else{
			z0Time=0;
		}

		if(z0Time>=2){
			rb.velocity += new Vector3 (0, 0, -0.01f);
		}

		if (rb.velocity.sqrMagnitude>=0.01f) {
			rb.velocity = Vector3.Normalize (rb.velocity) * ManagerScript.ball_Speed;
		}
	}

	void LateUpdate(){
		/*if (!ManagerScript.BSFlg) {
			rb.velocity = Vector3.Normalize (rb.velocity) * 6;
		}*/
	}

	void OnCollisionEnter(Collision c){
		if (c.gameObject.tag == "Block") {
			float p =Random.value*100;
			//Debug.Log (p);
			float ip = 0;
			if (p < 3) {
				ItemAppear (itemB, c.transform);
			} else if (3<= p && p < 6) {
				ItemAppear (itemC, c.transform);
			} else if (6 <= p && p < 10) {
				ItemAppear (itemF, c.transform);
			} else if (10 <= p && p < 13) {
				ItemAppear (itemG, c.transform);
			} else if (13 <= p && p < 19) {
				ItemAppear (itemL, c.transform);
			} else if (19 <= p && p < 23) {
				ItemAppear (itemM, c.transform);
			} else if (23 <= p && p < 29) {
				ItemAppear (itemS, c.transform);
			} else if (29 <= p && p < 29.5f) {
				ItemAppear (itemH, c.transform);
			} else {
				ItemAppear(itemC,c.transform);
			}
		}
	}

	void OnTriggerEnter(Collider c){
		if (c.tag == "SideWall") {
			Vector3 v = rb.velocity;
			rb.velocity = new Vector3 (-v.x, 0, v.z);
		} else if (c.tag == "TopWall") {
			Vector3 v = rb.velocity;
			rb.velocity = new Vector3 (v.x, 0, -v.z);
		} else if (c.tag == "Manager") {
			foreach (GameObject g in items) {
				g.transform.position = Vector3.left * 100;
				g.GetComponent<ItemScript> ().isapper = false;
				//Debug.Log (g + " falsed");
			}
		}
			
	}

	void ItemAppear(GameObject item,Transform c){
		ItemScript itemSc = item.GetComponent<ItemScript> ();
		bool flg = true;
		if (itemSc != null) {
			flg = itemSc.isapper;
		}
		if (!flg) {
			item.transform.position = c.position;
			itemSc.isapper = true;
		}
	}
}
