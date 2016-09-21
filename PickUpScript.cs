using UnityEngine;
using System.Collections;

public class PickUpScript : Interactor {
	public string itemName = "!NameNotSet";

	public override void Interact() {

	}

	public override void AddToInventory(GameObject Target) {
		Target.gameObject.GetComponentInParent<InventoryController>().add(itemName);
		this.gameObject.SetActive(false);
	}
}
