using UnityEngine;
using System.Collections;

public class CanvasFade : MonoBehaviour {

	public GameObject scareCam;
	CanvasGroup can;
	bool done;
	void Awake()	{
		done = false;
		can = this.GetComponent<CanvasGroup> ();
		FadeOut ();
	}//awake()

	void Update()	{
		if (scareCam.activeSelf && !done) {
			done = true;
			FadeIn ();
		}//if
	

	}//update


	public void FadeIn()	{
		StartCoroutine (DoFadeIn ());
	}//FadeIn();

	public void FadeOut()	{
		StartCoroutine (DoFadeOut ());
	}//FadeOut();

	IEnumerator DoFadeIn()	{
		yield return new WaitForSeconds(4);
		while(can.alpha < .99f)	{
			can.alpha += Time.deltaTime /4;
			yield return null;
		}//while
		can.alpha = 1;
		can.interactable = false;
		Application.LoadLevel (2);
		yield return null;
	}//DoFadeIn();

	IEnumerator DoFadeOut()	{
		while(can.alpha > 0)	{
			can.alpha -= Time.deltaTime /4;
			yield return null;
		}//while
		can.interactable = false;
		yield return null;

	}//DoFadeOut();

}//class
