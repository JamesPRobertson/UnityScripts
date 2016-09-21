using UnityEngine;
using System.Collections;

public abstract class Interactor : MonoBehaviour {
	public abstract void Interact();
	public abstract void AddToInventory(GameObject foo);
}
