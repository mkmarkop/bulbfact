using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class PickableItem : MonoBehaviour {

	public InventoryItem inventoryItem;
	public delegate void itemHandler(InventoryItem item);
	public static event itemHandler onItemPicked;

	void OnTriggerEnter(Collider other) {
		if (!other.CompareTag ("Player")) {
			return;
		}

		if (onItemPicked != null && inventoryItem != null) {
			onItemPicked (inventoryItem);
		}

		Destroy (this.gameObject);
	}
}
