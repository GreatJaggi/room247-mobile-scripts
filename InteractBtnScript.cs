using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InteractBtnScript : MonoBehaviour {

	public int doorState;
	public GameObject dBox;
	public GameObject DLS;
	public GameObject door;
	public GameObject BGM;
	public GameObject jumpscareSFX;
	public GameObject jumpscarePic;
	public GameObject lockedSFX;
	public GameObject DLS2;

	public GameObject fpsCanvas;
	public GameObject player;
	public GameObject safeboxOrig;

	public GameObject safeBoxEventCanvas;
	public GameObject safeBoxItemEvent;
	public GameObject safeEvent;

	public GameObject scareCam;
	public GameObject girl;

	public GameObject key;



	InteractScript playerInteract;
	Interact canvasInteract;

//	public string dialog = "The door is locked. There must be a key somewhere here.";
	public string dialog = "Ola mende pendejo!!!";

	void Awake()	{
		canvasInteract = fpsCanvas.GetComponent<Interact> ();
		playerInteract = player.GetComponent<InteractScript> ();
	}//awake

	void Update()	{
		print (playerInteract.hitName);
		if (dBox.GetComponent<Animator> ().GetBool ("DBox"))
			StartCoroutine (WaitForDBox ());
	}//update

	IEnumerator WaitForDBox()	{
		yield return new WaitForSeconds (.1f);
		dBox.GetComponent<Animator> ().SetBool ("DBox", false);
	}//Wait

	public void Events()	{
		if (playerInteract.hitName == "Door" && !playerInteract.hasKey) {
			dBox.GetComponent<Animator> ().SetBool ("DBox", true);
			lockedSFX.GetComponent<AudioSource>().Play();
			dialog = "The door is locked. There must be a key somewhere here.";
			playerInteract.doorChecked = true;

//			player.transform.LookAt(safeboxOrig.transform);
//			player.GetComponent<Animation>().Play();
		}//if

		else if(playerInteract.hitName == "Door" && playerInteract.hasKey) {
//			dBox.GetComponent<Animator> ().SetBool ("DBox", true);
//			dialog = "*Jumpscare* Oops! I hope you got scared.";
			door.GetComponent<Animator>().SetBool("Unlocked", true);
//			jumpscareSFX.GetComponent<AudioSource>().Play();
//			jumpscarePic.SetActive(true);

			DLS.GetComponent<Animator>().SetBool("Scare", true);
			player.SetActive(false);
			scareCam.SetActive(true);
			girl.GetComponent<Animator>().SetBool("Attack", true);
			fpsCanvas.SetActive(false);

		}//else

		if (playerInteract.hitName == "safebox" && playerInteract.safeLocked) {
			SafeEvent(true);
		}//if

		if (playerInteract.hitName == "safekey") {
						playerInteract.hasKey = true;

			Destroy(key);
			Destroy(safeEvent);
			Destroy (safeBoxEventCanvas);
			Destroy(safeBoxItemEvent);
			dialog = "You got a key.";
			dBox.GetComponent<Animator> ().SetBool ("DBox", true);

						DLS.GetComponent<Animator>().SetBool("Flick", true);
						DLS2.SetActive(false);
						door.GetComponent<AudioSource>().Play();
						BGM.GetComponent<AudioSource>().Play();
		}//if
	}//doorEvent

	public void SafeEvent(bool eventTrigger)	{
		player.SetActive(!eventTrigger);
		fpsCanvas.SetActive(!eventTrigger);
		safeboxOrig.SetActive(!eventTrigger);
		
		safeBoxItemEvent.SetActive(eventTrigger);
		safeEvent.SetActive(eventTrigger);
		safeBoxEventCanvas.SetActive(eventTrigger);
	}//SafeEvent

}
