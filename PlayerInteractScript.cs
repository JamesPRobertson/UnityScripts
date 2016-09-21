using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerInteractScript : MonoBehaviour {
	public float interactDistance = 5f;
	public Text interactText;

	void Start() {
		this.gameObject.GetComponentInChildren<Light>().enabled = false;
		interactText.enabled = false;
	}
	
	void Update () {
		Ray rayCast = new Ray(transform.position, transform.forward);
		RaycastHit rayHit;

		if(Physics.Raycast(rayCast, out rayHit, interactDistance)) {
			if(rayHit.collider.CompareTag("Door") || rayHit.collider.CompareTag("Interactable")) {
				interactText.enabled = true;
				interactText.text = "Click to Interact";
			} else if(rayHit.collider.CompareTag("PickUp")) {
				interactText.enabled = true;
				interactText.text = "Click to Pick Up";
			}
		} else {
			interactText.enabled = false;
		}

		if(Input.GetKeyDown(KeyCode.Mouse0)){
			if(Physics.Raycast(rayCast, out rayHit, interactDistance)) {
				if(rayHit.collider.CompareTag("Door")) {
					//rayHit.collider.transform.parent.GetComponent<DoorController>().opening = !rayHit.collider.transform.parent.GetComponent<DoorController>().opening;
					rayHit.collider.transform.parent.GetComponent<DoorController>().Interact();
				} else if(rayHit.collider.CompareTag("Interactable")) {
					rayHit.collider.gameObject.GetComponent<Interactor>().Interact();
				} else if(rayHit.collider.CompareTag("PickUp")) {
					rayHit.collider.gameObject.GetComponent<Interactor>().AddToInventory(this.gameObject);
				}
			}
		}

		if(Input.GetKeyDown("f")) {
			this.gameObject.GetComponentInChildren<Light>().enabled = !this.gameObject.GetComponentInChildren<Light>().enabled;
		}
	}
}
