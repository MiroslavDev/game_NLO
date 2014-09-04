using UnityEngine;
using System.Collections;

public class respawnPlayers : MonoBehaviour {
	public Transform player;
	// Use this for initialization
	void Start () 
	{
		Network.Instantiate (player, transform.position + new Vector3(Random.Range(0, 5), 0, Random.Range(0, 5)), transform.rotation, 0);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
