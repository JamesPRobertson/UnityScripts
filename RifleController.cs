using UnityEngine;
using System.Collections;

public class RifleController : MonoBehaviour {
	Camera fpsCamera;
	Vector3 defaultTransform;
	Vector3 defaultRotation;
	Vector3 ironSights;
	bool aiming;
	bool recoiling;

	public float recoil = 2f;

	public float smoothing = 1f;

	void Start () {
		fpsCamera = this.GetComponentInParent<Camera>();
		defaultTransform = this.transform.localPosition;
		defaultRotation = this.transform.localEulerAngles;
		ironSights = new Vector3(0, -.48f, .454f);

		aiming = false;
		recoiling = false;
	}
	
	void Update () {
		if(Input.GetButton("Fire2")) {
			aiming = true;
		} else {
			aiming = false;
		}

		if(Input.GetButtonDown("Fire1")) {
			recoiling = true;
		} else if(recoiling == true && V3Equal(this.transform.localEulerAngles, new Vector3(352,0,0))) {
			recoiling = false;
		}

		Anim();
		Shoot();
		Recoil();
	}

	void Anim() {
		//if(!aiming) {
		//	this.transform.localPosition = Vector3.Slerp(defaultTransform, ironSights, Time.deltaTime * smoothing);
		//} else {
		//	this.transform.localPosition = Vector3.Slerp(ironSights, defaultTransform, Time.deltaTime * smoothing);
		//}

		if(aiming) {
			this.GetComponentInParent<Camera>().fieldOfView = Mathf.Lerp(this.GetComponentInParent<Camera>().fieldOfView, 67, Time.deltaTime * 2);
			this.transform.localPosition = Vector3.Slerp(this.transform.localPosition, ironSights, Time.deltaTime * smoothing);
		} else {
			this.GetComponentInParent<Camera>().fieldOfView = Mathf.Lerp(this.GetComponentInParent<Camera>().fieldOfView, 80, Time.deltaTime * 4);
			this.transform.localPosition = Vector3.Slerp(this.transform.localPosition, defaultTransform, Time.deltaTime * smoothing);
		}

		//if(V3Equal(this.transform.localPosition, defaultTransform)) {
		//	this.transform.localPosition = defaultTransform;
		//} else if(V3Equal(this.transform.localPosition, ironSights)) {
		//	this.transform.localPosition = ironSights;
		//}

	}
	
	//LOCAL EULER ANGLES AND NEGATIVES ARE THE DEVIL
	void Recoil() {
		if(recoiling) {
			//Vector3 currentCameraRotation = fpsCamera.transform.localEulerAngles;
			//fpsCamera.transform.localEulerAngles = Vector3.Slerp(currentCameraRotation, new Vector3(currentCameraRotation.x - 6, currentCameraRotation.y, currentCameraRotation.z),6);
			//fpsCamera.transform.localEulerAngles = new Vector3(currentCameraRotation.x - 6, currentCameraRotation.y, currentCameraRotation.z);
			//fpsCamera.transform.rotation = Quaternion.Slerp(fpsCamera.transform.rotation, Quaternion.Euler(new Vector3(currentCameraRotation.x + 30, currentCameraRotation.y, currentCameraRotation.z)), Time.deltaTime * 2);
			//ApplyRecoil();
			this.transform.localEulerAngles = Vector3.Lerp(this.transform.localEulerAngles, new Vector3(352,0,0), Time.deltaTime * recoil * 2);
		} else {
			this.transform.localEulerAngles = Vector3.Slerp(this.transform.localEulerAngles, defaultRotation, Time.deltaTime * (recoil / 3.5f));
		}
			
		if(V3Equal(this.transform.localEulerAngles, defaultRotation)) {
			this.transform.localEulerAngles = defaultRotation;
		}

		//if(V3Equal(this.transform.localEulerAngles, new Vector3(6, 0, 0))){
		//	recoiling = false;
		//}
	}

	void Shoot() {
		if(Input.GetButtonDown("Fire1")) {
			Debug.Log("Clicky Clicky");

			Ray rayOut = new Ray(transform.position, transform.forward);
			RaycastHit rayHit;

			if(Physics.Raycast(rayOut, out rayHit, 250)) {
				Debug.Log("We hit!");
				if(rayHit.collider.gameObject.CompareTag("Enemy") || rayHit.collider.gameObject.CompareTag("Player")) {
					rayHit.collider.gameObject.SendMessage("applyDamage", 60, SendMessageOptions.DontRequireReceiver);
				} else if(rayHit.collider.gameObject.CompareTag("Target")) {
					Debug.Log("We hit a target!");
					rayHit.collider.gameObject.GetComponent<Interactor>().Interact();
				}
			}
		}
	}

	void ApplyRecoil() {
		fpsCamera.transform.rotation *= Quaternion.Slerp(fpsCamera.transform.rotation, Quaternion.Euler(10, 0, 0), Time.deltaTime);
	}

	bool V3Equal(Vector3 a, Vector3 b) {
		return Vector3.SqrMagnitude(a - b) < 0.0001;
	}

	bool V3EqualInaccurate(Vector3 a, Vector3 b) {
		return Vector3.SqrMagnitude(a - b) < 0.01;
	}
}
