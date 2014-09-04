using UnityEngine;
using System.Collections;

public class HP : MonoBehaviour {
	public AudioClip Fire2 = null;
	public GameObject location;
	public GameObject playerExplosion;
	void Update () {
	
	}
	public float HP1 = 100;

	public void DamageS(float damage)
	{
		HP1 = HP1 - damage;
		if (HP1 == 0) 
		{
			Network.Destroy( gameObject);
			Network.Instantiate(playerExplosion, location.transform.position, location.transform.rotation, 0);
		}
	}
}