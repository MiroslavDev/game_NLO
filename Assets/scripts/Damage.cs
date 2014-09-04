using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {
	public float damage = 20;
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Zombie") {
			col.gameObject.GetComponent<HP>().DamageS(damage);
			col.gameObject.GetComponent<GUIname>().CurHealth = col.gameObject.GetComponent<GUIname>().CurHealth-damage;
		}
	}

}
