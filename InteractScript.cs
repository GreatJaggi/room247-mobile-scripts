using UnityEngine;
using System.Collections;

public class InteractScript : MonoBehaviour {

	public bool interact = false;
	public GameObject[] interactObjects;
	public string hitName;

	public bool doorChecked = false;
	public bool hasKey = false;

	public bool safeLocked;

	void Awake()	{
		safeLocked = true;
		doorChecked = false;
		hasKey = false;
	}//awake

	public GameObject camera;
	void Update () {
//		print (interact);
		Ray ray = Camera.main.ViewportPointToRay (new Vector3(0.5f,0.5f,0f));
		Vector3 fwd = camera.transform.forward;
		RaycastHit hit = new RaycastHit ();

		if (Physics.Raycast (ray, out hit, 1f)) {
			interact = HitInstance (hit);
		}//iff
		else {
			hitName = "zero";
			interact = false;
		}//else
		if(interact)
			Debug.DrawRay(camera.transform.position, camera.transform.forward, Color.yellow, 1f);
		//				print (interactObjects[i].name);
	}//update

	public bool HitInstance(RaycastHit hit)	{
		for (int i = 0; i < interactObjects.Length; i++) {

			if(hit.collider.name == "safekey" && hasKey)	{
				hitName = "zero";
				return false;
			}//if

			if (hit.collider.name == interactObjects [i].name)	{
				hitName = hit.collider.name;
				return true;
			}//if
		}//for

		return false;
	}//checkCollision

}//class