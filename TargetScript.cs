using UnityEngine;
using System.Collections;
using System;

public class TargetScript : Interactor{
	Color defaultColor;
	Color hitColor;

	float timer;

	void Start () {
		defaultColor = this.gameObject.GetComponent<MeshRenderer>().material.color;
		hitColor = Color.red;
	}
	
	void Update () {
		if(timer + 2 < Time.time) {
			this.gameObject.GetComponent<MeshRenderer>().material.color = defaultColor;
		}
	}

	public override void Interact() {
		this.gameObject.GetComponent<MeshRenderer>().material.color = hitColor;
		timer = Time.time;
	}

	public override void AddToInventory(GameObject foo) {
		throw new NotImplementedException();
	}
}
