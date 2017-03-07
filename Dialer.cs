using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Dialer : MonoBehaviour {

	public Transform[] number;
	public Text[] numberTexts;
	public GameObject interactBtn;
	public GameObject safebox;
	Animator anim;
	InteractBtnScript iBtn;
	int dialNumber = 0;

	string passcode = "139214";
	string tryPass = "";
	int pass = 0;

	void Awake()	{
		iBtn = interactBtn.GetComponent<InteractBtnScript> ();
		anim = safebox.GetComponent<Animator> ();
	}//awake

	void Update()	{
		transform.position = number [dialNumber].position;
		transform.rotation = number [dialNumber].rotation;

		print (tryPass);
	}//update
	public void DialNext(bool left)	{
		if (left)
			dialNumber -= 1;
		
		if (!left)
			dialNumber += 1;

		if (dialNumber == 10)
			dialNumber = 0;

		if (dialNumber == -1)
			dialNumber = 9;
	}//DialNext

	public void Dial()	{
		numberTexts [pass].text = dialNumber.ToString();
		if (pass < 6) {
			tryPass += dialNumber;
		}//if

		else
			pass = 0;

		pass += 1;

		if(String.Compare(tryPass, passcode) == 0)	{
			print ("Correct passcode!");
			iBtn.SafeEvent(false);
			safebox.name = "safekey";
			anim.SetBool("Unlocked", true);

		}//if

		else if (pass == 6) {
			print ("Wrong password!");
			tryPass = "";
			dialNumber = 0;
			iBtn.SafeEvent(false);
			pass = 0;
			for (int i = 0; i < 6; i++)	{
				numberTexts[i].text = "";
			}//for
		}//if


	}//class



}//class
