using UnityEngine;
using System.Collections;

public class JPlayBtn : MonoBehaviour {
	public GameObject _goGuide;

	void OnClick() {
		PlayerPrefs.SetInt ("FinishGuid", 1);
		JMain.instance.NewGame();
		Destroy (_goGuide);
	}
}
