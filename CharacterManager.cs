using UnityEngine;
using System.Collections;

public class CharacterManager : MonoBehaviour {
	//GameObject Sword;
	GameObject rifle;
	RifleController shootyScript;

	void Start () {
		//this.GetComponentInChildren<RifleController>().enabled = false;
		rifle = GameObject.Find("Rifle");
		shootyScript = rifle.GetComponent<RifleController>();

		shootyScript.enabled = false;
		rifle.SetActive(false);
		//this.GetComponentInChildren<TestScript>().enabled = false;
		//Sword = GameObject.Find("Sword");
		//Sword.SetActive(false);
	}
	
	void Update () {
		if(Input.GetKeyDown("q")) {
			shootyScript.enabled = !shootyScript.enabled;
			rifle.SetActive(!rifle.activeSelf);

			this.GetComponentInChildren<PlayerInteractScript>().enabled = !shootyScript.enabled;
			//this.GetComponentInChildren<TestScript>(true).enabled = !this.GetComponentInChildren<TestScript>(true).enabled;
			//Sword.SetActive(!Sword.activeSelf);

			//.GetComponentInChildren<PlayerInteractScript>().enabled = !this.GetComponentInChildren<TestScript>(true).enabled;
		}
	}
}
