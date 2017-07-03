using UnityEngine;
using System.Collections;

public class JNewGameBtn : MonoBehaviour {

	void OnClick() {
		JMain.instance.NewGame();
		JGameOver.instance.ShowPanel(false);
	}
}
