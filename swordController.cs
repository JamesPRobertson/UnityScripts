using UnityEngine;
using System.Collections;

public class swordController : MonoBehaviour {

	private Animator anim;

	void Start () {
		anim = GetComponent<Animator>();
		anim.enabled = true;
	}
	
	void Update () {
		if(Input.GetButtonDown("Fire1")){
			anim.Play("Swing");
		} else {
			//anim.Stop();
		}
	}
}
