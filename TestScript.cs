//should be renamed to sword swinging script >.>

using UnityEngine;
using System.Collections;

public class TestScript: MonoBehaviour {
	private Transform swingingSwordTransform;
	private Vector3 restingSwordRotation;

	private bool swinging = false;

	void Start() {
		swingingSwordTransform = this.transform;
		restingSwordRotation = this.transform.localEulerAngles;
	}

	void Update() {
		if(swinging) {
			gameObject.GetComponent<BoxCollider>().enabled = true;
		} else {
			gameObject.GetComponent<BoxCollider>().enabled = false;
		}

		if(Input.GetKeyDown(KeyCode.Mouse0)) {
			swinging = true;
		}

		if(swinging) {
			swingingSwordTransform.transform.localEulerAngles = Vector3.Lerp(swingingSwordTransform.localEulerAngles, new Vector3(0, 90, 100), 0.4f);

			if(V3Equal(swingingSwordTransform.transform.localEulerAngles, new Vector3(0,90,100))) {
				swinging = false;
			}
		} else {
			swingingSwordTransform.transform.localEulerAngles = Vector3.Lerp(swingingSwordTransform.localEulerAngles, restingSwordRotation, 0.2f);
		}
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.GetComponent<CapsuleCollider>().enabled == true) {
			Physics.IgnoreCollision(GetComponent<BoxCollider>(), other.transform.root.GetComponent<CapsuleCollider>());
		}

		if(other.gameObject.GetComponent<CharacterController>().enabled == true) {
		Physics.IgnoreCollision(GetComponent<BoxCollider>(), other.transform.root.GetComponent<CharacterController>());
		}

		if(other.CompareTag("Hittable") || other.CompareTag("Enemy") || other.CompareTag("Player")){
			other.SendMessage("applyDamage",25,SendMessageOptions.DontRequireReceiver);
			this.gameObject.GetComponent<BoxCollider>().enabled = false;
		}
	}

	public bool V3Equal(Vector3 a, Vector3 b) {
		return Vector3.SqrMagnitude(a - b) < 0.0001;
	}
}
