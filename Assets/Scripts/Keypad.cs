using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(DoorScript))]
public class Keypad : MonoBehaviour {
    public DoorScript Door;
    public int Key;
    public Canvas keypadCanvas;
    private string enteredKey;
    public Text displayKey;


	// Use this for initialization
	void Start () {
        enteredKey = "";
	}
    void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Activate"))
        {
            if (Door.isOpen()) { return; }
            ActivateKeypad();
        }
}

    void ActivateKeypad()
    {
        keypadCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void DeactivateKeypad()
    {
        keypadCanvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void GetPressedKey(int number)
    {
        if (enteredKey.Length == 4) { return; }
        enteredKey = enteredKey + number.ToString();
    }

    public void OnEnterPress()
    {
        if (Key.ToString() == enteredKey){
            Door.Open();
            DeactivateKeypad();
        }
        enteredKey = "";
    }	

	// Update is called once per frame
	void Update () {
        displayKey.text = enteredKey.ToString();
	}
}
