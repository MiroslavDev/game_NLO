using UnityEngine;
using System.Collections;

public class playerSynchronization : MonoBehaviour {
	private Vector3 lastPos;
	private Quaternion lastRot;
	private Transform myTransform;

	// Use this for initialization
	void Start () {
		
		if (networkView.isMine) 
		{
			myTransform = transform;
		}
		else
		{
			enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Vector3.Distance (myTransform.position, lastPos) >= 0.05f)
		{
			lastPos = myTransform.position;
			networkView.RPC ("UpdateMovement", RPCMode.OthersBuffered, myTransform.position, myTransform.rotation);
		}
		if (Quaternion.Angle (myTransform.rotation, lastRot) >= 1) 
		{
			lastRot = myTransform.rotation;
			networkView.RPC ("UpdateMovement", RPCMode.OthersBuffered, myTransform.position, myTransform.rotation);
		}
	}
	[RPC]
	private void UpdateMovement(Vector3 newPos, Quaternion newRot)
	{
		transform.position = newPos;
		transform.rotation = newRot;
	}
}
