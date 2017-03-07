using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Dialogs : MonoBehaviour {

	Text dialog;
	public GameObject iBtn;
	void Start () {
		dialog = this.GetComponent<Text> ();
	}//Start
	
	// Update is called once per frame
	void Update () {
		dialog.text = iBtn.GetComponent<InteractBtnScript> ().dialog;
	}
}
