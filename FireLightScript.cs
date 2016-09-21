using UnityEngine;
using System.Collections;
using System;

public class FireLightScript : Interactor {
	Light light;

	void Start () {
		light = this.GetComponent<Light>();
	}

	public override void Interact() {
		light.enabled = !light.enabled;
	}

	public override void AddToInventory(GameObject foo) {

	}
}
