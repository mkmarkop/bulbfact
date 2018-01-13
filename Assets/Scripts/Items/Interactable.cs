using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Interactable : MonoBehaviour {

	public struct InteractionInfo {
		public bool isSuccess;
		public InventoryItem usedItem;
	}

    public GameObject boundingPrefab;
	public InventoryItem requiredItem;
	public delegate void interactionHandler(InteractionInfo info);
	public static event interactionHandler onInteraction;

	private bool _isUsed = false;
    private GameObject _boundingBox;

    protected virtual void Start() {
        _boundingBox = Instantiate(boundingPrefab, transform);
        _boundingBox.SetActive(false);

        var parentBounds = GetComponent<Collider>().bounds.size;
        var childBounds = _boundingBox.GetComponent<Renderer>().bounds.size;

        var scale = new Vector3(parentBounds.x / childBounds.x, parentBounds.y / childBounds.y, parentBounds.z / childBounds.z);
        _boundingBox.transform.localScale = scale;

    }

    public void EnableHighlight() {
        _boundingBox.SetActive(true);
    }

    public void DisableHighlight() {
        _boundingBox.SetActive(false);
    }

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

	protected void setReuseable () {
		_isUsed = false;
	}	

	protected virtual void Interact() {
		GetComponent<Renderer> ().material.color = new Color (0, 255, 0);
	}
}
