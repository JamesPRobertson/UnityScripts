using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {
	public int health = 100;
	public float hitRepeatTime = 1;

	private Color baseColor;

	float hitTime;

	void Start() {
	}

	void Update () {
		if(health <= 0) {
			GameObject.Destroy(gameObject);
		}
	}

	void applyDamage(int damage) {
		if(Time.time > hitTime) {
			health -= damage;
			Debug.Log(gameObject + "Was hit for: " + damage + " has " + health + " health left.");
			hitTime = Time.time + hitRepeatTime;	
		}
	}
}
