using UnityEngine;
using System.Collections;

public class SunController : MonoBehaviour {
	public float RotationSpeed;

	void Start () {
	}
	

	void Update () {
		transform.Rotate(.1f * RotationSpeed, .05f * RotationSpeed, 0);
	}
}

