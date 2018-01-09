using System.Collections;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "InventoryItem.asset", menuName = "Inventory/Item")]
public class InventoryItem : ScriptableObject {

	public Sprite itemIcon;
	public string itemName;
}
