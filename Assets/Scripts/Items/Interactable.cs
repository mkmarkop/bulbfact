using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

	public struct InteractionInfo {
		public bool isSuccess;
		public InventoryItem usedItem;
	}

	public InventoryItem requiredItem;
	public delegate void interactionHandler(InteractionInfo info);
	public static event interactionHandler onInteraction;

	private bool _isUsed = false;

	public void Receive(InventoryItem item) {
		InteractionInfo info = new InteractionInfo ();
		info.usedItem = item;

		if (_isUsed || item != requiredItem) {
			info.isSuccess = false;
		} else {
			info.isSuccess = true;
			_isUsed = true;
		}

		if (onInteraction != null) {
			onInteraction (info);
		}

		if (info.isSuccess) {
			Interact ();
		}
	}

	protected virtual void Interact() {
		GetComponent<Renderer> ().material.color = new Color (0, 255, 0);
	}
}
