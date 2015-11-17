using UnityEngine;
using System.Collections;

public class ItemGScript : ItemScript {

	GameObject gun;
	GameObject stick;
	GameObject bullet;
	BulletScript bs;
	bool can_Shot=false;

	// Use this for initialization
	void Start () {
		gun = GameObject.Find ("Gun");
		stick = GameObject.Find ("Stick");
		bullet = GameObject.Find ("Bullet");
		bs = bullet.GetComponent<BulletScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();
		float gPosz = gun.transform.position.z;
		gun.transform.position = new Vector3 (stick.transform.position.x, 0, gPosz);

		if (bs.shot_Enable &&can_Shot&& Input.GetMouseButtonDown (0)) {
			Shot ();
		}
	}

	public override void ItemEffect(){
		bs.shot_Enable = true;
		can_Shot = true;
		transform.position = Vector3.left * 100;
		iTween.ValueTo (gameObject, iTween.Hash ("from", -5f,"to",-2.83f,"time",0.6f, "easetype", "easeOutBack","onupdate","GposzSet"));
		Invoke ("InvokeA", 7f);
	}

	void GposzSet(float z){
		gun.transform.position = new Vector3 (stick.transform.position.x, 0, z);
	}

	void InvokeA(){
		can_Shot = false;
		isapper = false;
		iTween.ValueTo (gameObject, iTween.Hash ("from", -2.83f,"to",-5f,"time",0.6f, "easetype", "easeInBack","onupdate","GposzSet"));
	}

	void Shot(){
		bullet.transform.position = gun.transform.position + Vector3.forward * 0.1f;
		bs.SetTrue ();
	}
}
