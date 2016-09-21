using UnityEngine;
using System.Collections;
using System;

public class InteractionScript: Interactor {
	Color defaultColor;

	void Start() {
		defaultColor = this.gameObject.GetComponent<MeshRenderer>().material.color;
	}

	void Update() {
		
	}

	public override void Interact() {
		if(this.gameObject.GetComponent<MeshRenderer>().material.color != defaultColor) {
			this.gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", defaultColor);
		} else {
			this.gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.blue);
		}
	}

	public override void AddToInventory(GameObject foo) {

	}
}
