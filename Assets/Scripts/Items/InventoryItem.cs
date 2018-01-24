using System.Collections;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

[CreateAssetMenu(fileName = "InventoryItem.asset", menuName = "Inventory/Item")]
#endif
public class InventoryItem : ScriptableObject {

	public Sprite itemIcon;
	public string itemName;
}
