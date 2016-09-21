//Now works for weird door angles!

using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {
	public bool opening;
	public float doorOpenAngle = -90;
	public float smooth = 2.0f;

	private Vector3 defaultRot;
	private Vector3 openRot;

	void Start () {
		defaultRot = this.transform.eulerAngles;

		if(defaultRot.y + doorOpenAngle > 360) {
			openRot = new Vector3(defaultRot.x, defaultRot.y + (doorOpenAngle - 180), defaultRot.z);
		} else {
			openRot = new Vector3(defaultRot.x, defaultRot.y + doorOpenAngle, defaultRot.z);
		}

		opening = false;
	}
	
	void Update () {
		this.Anim();
	}

	void Anim() {
		if(opening) {
			transform.eulerAngles = Vector3.Slerp(this.transform.eulerAngles, openRot, Time.deltaTime * smooth);
		} else {
			transform.eulerAngles = Vector3.Slerp(this.transform.eulerAngles, defaultRot, Time.deltaTime * smooth);
		}
	}

	public void Interact() {
		opening = !opening;
	}
}
