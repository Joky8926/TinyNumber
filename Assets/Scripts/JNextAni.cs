using UnityEngine;
using System.Collections;

public class JNextAni : MonoBehaviour {

	public void ShowAni() {
		gameObject.SetActive (true);
		animation.Play ();
	}

	public void Hide() {
		gameObject.SetActive (false);
	}
}
