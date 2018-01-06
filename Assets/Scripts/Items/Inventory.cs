using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	public Image[] itemImages = new Image[maxItems];
	private InventoryItem[] _items = new InventoryItem[maxItems];
	public const int maxItems = 4;

	public int _currentItem = -1;
	public int _previousItem = -1;
	public int _totalItems = 0;

	void OnEnable() {
		PickableItem.onItemPicked += AddItem;
	}

	void OnDisable() {
		PickableItem.onItemPicked -= AddItem;
	}

	void Awake() {
		for (int i = 0; i < itemImages.Length; i++) {
			itemImages [i].enabled = false;
		}
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.K)) {
			NextItem ();
			ChangeIcon ();
		} else if (Input.GetKeyDown(KeyCode.J)) {
			PreviousItem ();
			ChangeIcon ();
		} else if (Input.GetKeyDown(KeyCode.E) && _totalItems > 0) {
			RemoveItem (_currentItem);
		}
	}

	void PreviousItem() {
		_previousItem = _currentItem;
		if (_currentItem < 0) {
			_currentItem = _totalItems - 1;
		} else {
			_currentItem--;
		}
	}

	void NextItem() {
		_previousItem = _currentItem;
		if (_currentItem >= _totalItems - 1) {
			_currentItem = -1;
		} else {
			_currentItem++;
		}
	}

	void DeselectItem(int index) {
		if (index < 0 || index >= _totalItems)
			return;

		Color color = itemImages [index].color;
		color.a = 0.5f;
		itemImages [index].color = color;
	}

	void SelectItem(int index) {
		if (index < 0 || index >= _totalItems)
			return;

		Color color = itemImages [index].color;
		color.a = 1f;
		itemImages [index].color = color;
	}

	void ChangeIcon() {
		DeselectItem (_previousItem);
		SelectItem (_currentItem);
	}

	void AddItem(InventoryItem item) {
		for (int i = 0; i < _items.Length; i++) {
			if (_items [i] == null) {
				_items [i] = item;
				itemImages [i].sprite = item.itemIcon;
				itemImages [i].enabled = true;
				_totalItems++;
				DeselectItem (i);
				return;
			}
		}
	}

	void RemoveItem(int index) {
		if (index < 0 || index >= _totalItems)
			return;
		
		DeselectItem (index);

		for (int i = index; i < _totalItems - 1; i++) {
			_items [index] = _items [index + 1];
			itemImages [index].sprite = itemImages [index + 1].sprite;
			itemImages [index].enabled = itemImages [index + 1].enabled;
		}

		_items [_totalItems - 1] = null;
		itemImages [_totalItems - 1].sprite = null;
		itemImages [_totalItems - 1].enabled = false;
		_totalItems--;

		_currentItem = -1;
		_previousItem = -1;
	}
}
