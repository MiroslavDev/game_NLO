using UnityEngine;
using System.Collections;


public class weaponsOption : MonoBehaviour {
	public int  switchs = 1; 

	void Update () {
		GameObject blaster = GameObject.Find ("Blaster");
		GameObject ak47 = GameObject.Find ("AK47");

		UITexture ak47Com = ak47.GetComponent<UITexture>();
		UITexture blasterCom = blaster.GetComponent<UITexture>();;

				if (switchs == 1) {
						blasterCom.enabled = true;
						ak47Com.enabled = false;
				} else if (switchs == 2) {
						blasterCom.enabled = false;
						ak47Com.enabled = true;
				}
					}

}
