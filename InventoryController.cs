using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {
	public GameObject canvas;
	static ArrayList inventory;

	GameObject textHolder;
	GameObject textBackground;

	Text inventoryText;
	float timeSinceTab;

	void Start () {
		textBackground = GameObject.Find("UIInventoryBackground");
		inventory = new ArrayList();
		canvas = GameObject.Find("Canvas");

		textHolder = GameObject.Find("UIInventoryText");
		inventoryText = textHolder.GetComponent<Text>();

		textBackground.SetActive(false);
	}
	
	void Update () {
		if(Input.GetKeyDown("tab")) {
			DisplayInventory();
			timeSinceTab = Time.time;
		}

		if(timeSinceTab + 1.8f < Time.time) {
			EraseText();
		}
	}

	public void DisplayInventory() {
		textBackground.SetActive(true);
		inventoryText.text = "";

		if(inventory.Count == 0) {
			inventoryText.text = "Empty";
		} else {
			int counter = 1;

			foreach(string foo in inventory) {
				inventoryText.text += counter + ". " + foo + "\n";
				counter++;
			}
		} 

		
	}

	public void add(string name) {
		inventory.Add(name);
		Debug.Log(name + " added to inventory");
	}

	private void EraseText() {
		inventoryText.text = "";
		textBackground.SetActive(false);
	}
}
