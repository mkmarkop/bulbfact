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

        var parentBounds = GetComponent<Collider>().bounds;
        var localMin = transform.InverseTransformPoint(parentBounds.min);
        var localMax = transform.InverseTransformPoint(parentBounds.max);

        var scale = new Vector3(localMax.x - localMin.x, localMax.y - localMin.y, localMax.z - localMin.z);

        _boundingBox.transform.localScale = scale;
        _boundingBox.transform.position = parentBounds.center;
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
