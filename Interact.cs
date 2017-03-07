using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {
	public GameObject player;
	public GameObject interactBtn;
	InteractScript inter;

	void Start()	{
		inter = player.GetComponent<InteractScript> ();
	}//start

	void Update () {	
//		print (inter.interact);
		if (inter.interact)
			interactBtn.gameObject.SetActive (true);
		else
			interactBtn.gameObject.SetActive (false);
//		print (inter.interact);
	}//update

}//class
