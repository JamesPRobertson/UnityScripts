using UnityEngine;
using System.Collections;

public class BasicAIController : MonoBehaviour {
	Transform target;

	private float distance = -1;

	public float chaseDistance = 8.0f;
	public float attackRange = 7.5f;
	public float moveSpeed = 4.0f;
	public float rotationSmooth = 6.0f;

	private CharacterController controller;
	private float gravity = 90.0f;
    private Vector3 moveDirection = Vector3.zero;
	private float attackTime;
	private float attackRepeatTime = .75f;

	void Start () {
		controller = this.GetComponent<CharacterController>();
	}
	
	void Update () {	
		if(target != null) {
			distance = Vector3.Distance(target.position, transform.position);

			Creep();

			Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSmooth);

			if(distance < chaseDistance) {
				Chase();
			}

			if(distance <= attackRange) {
				if(Time.time > attackTime) {
					target.transform.SendMessage("applyDamage", 20, SendMessageOptions.DontRequireReceiver);
					attackTime = Time.time + attackRepeatTime;
				}
			}
		}
	}

	void Chase() {
		moveDirection = transform.forward;
		moveDirection *= moveSpeed;

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}

	void Creep() {
		moveDirection = transform.forward;
		moveDirection *= moveSpeed * 0.5f;

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Player")) {
			target = other.gameObject.transform;
		}
	}

	void OnTriggerExit(Collider other) {
		if(other.gameObject.CompareTag("Player")) {
			target = null;
		}
	}
}
