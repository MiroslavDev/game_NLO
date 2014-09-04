using UnityEngine;
using System.Collections;

public class UMJDemo_Weapon : MonoBehaviour {	
	private int i;
	public AudioClip Fire = null;
	public GameObject MyBullet = null;		
	public Transform Muzzle = null;	
	private float ReadyTime = 0f;
	
	void Update() { }	
	
	public void Shooting()
	{
		ReadyTime += Time.deltaTime; 
		if ( ReadyTime > 0.15f )
		{	

			GameObject BulletCloneGO = ( GameObject ) Network.Instantiate( MyBullet, Muzzle.position, Muzzle.rotation, 0 ) as GameObject;			
			BulletCloneGO.rigidbody.velocity = Muzzle.transform.TransformDirection( Vector3.forward * 100f );
			ReadyTime = 0f;	
			audio.PlayOneShot(Fire);
			i++;
		}
	}
}