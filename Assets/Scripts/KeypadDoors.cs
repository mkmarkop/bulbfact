using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadDoors : MonoBehaviour {
    public Component Door;
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
            Door.GetComponent<Animator>().SetBool("open", true);
            DeactivateKeypad();
        }
        enteredKey = "";
    }	

	// Update is called once per frame
	void Update () {
        displayKey.text = enteredKey.ToString();
	}
}
