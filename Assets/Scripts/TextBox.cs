using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextBox : MonoBehaviour {

	public GameObject textPanel;
	public Text textBox;
	float textDelay = 2;

	void Start(){
		textBox.text = "";
		textPanel.SetActive(false);
		textBox.enabled = false;
	}

	// show the given message
	public void showMessage(string line){
		StartCoroutine (show (line));
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {		
			showMessage("Hello Dude");
		}
	}

	IEnumerator show(string line){
		textBox.text = line;
		textPanel.SetActive(true);
		textBox.enabled = true;
		yield return new WaitForSeconds (textDelay);
		textPanel.SetActive(false);
		textBox.enabled = false;
		textBox.text = "";
	}
}
