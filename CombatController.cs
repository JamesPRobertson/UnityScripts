using UnityEngine;
using System.Collections;

public class CombatController: MonoBehaviour {
	public bool swinging;
	public float swingAngle = 90;
	public float smooth = 8.0f;

	private Vector3 restingRot;
	private Vector3 swingRot;

	int state;

	void Start() {
		restingRot = this.transform.eulerAngles;
		swingRot = new Vector3(restingRot.x, restingRot.y, restingRot.z + swingAngle);
		swinging = false;
		state = 0;
	}

	void Update() {
		if(state == (int)State.StartSwing) {
			restingRot = this.transform.eulerAngles;
			state = (int)State.Swinging;
		}

		
		swingRot = new Vector3(0, 90, restingRot.z + swingAngle);

		
	}

	void Anim() {
		if(state == (int)State.Swinging) {
			Debug.Log("eulerAngles.z ==  " + this.transform.eulerAngles.z);

			this.transform.Rotate(0, 0, 90,Space.Self);

			if(this.transform.eulerAngles.z == 90) {
				Debug.Log("We got here");

				this.transform.Rotate(0, 0, 0, Space.Self);
			}
		}

		/*
		if(swinging) {
			transform.eulerAngles = Vector3.Lerp(this.transform.eulerAngles, swingRot, Time.deltaTime * smooth);
		} else {
			transform.eulerAngles = Vector3.Lerp(this.transform.eulerAngles, restingRot, Time.deltaTime * smooth);
		}
		*/
	}

	public void setSwingState() { 
		Debug.Log("Clicky " + state);

		if(state == (int)State.Swinging) {
			state = (int)State.Resting;
		} else if(state == (int)State.Resting || state == (int)State.Swinging) {
			state = (int)State.Swinging;
		}
		this.Anim();
	}

	enum State {
		Resting, Swinging, StartSwing
	}
}
