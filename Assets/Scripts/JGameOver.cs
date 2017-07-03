using UnityEngine;
using System.Collections;

public class JGameOver : MonoBehaviour {
	public static JGameOver instance;
	public UILabel _ScoreLabel;
	public GameObject _goScores;
	public GameObject _goHight;

	void Awake() {
		instance = this;
		ShowPanel(false);
	}

	public void OnGameOver(int uScore) {
		int uLastHightScore = PlayerPrefs.GetInt("HightScore");
		if (uLastHightScore < uScore) {
			PlayerPrefs.SetInt ("HightScore", uScore);
			SetIsHight (true);
		} else {
			SetIsHight(false);
		}
		ShowPanel(true);
		_ScoreLabel.text = uScore.ToString();
	}
	
	public void ShowPanel(bool bFlag) {
		gameObject.SetActive(bFlag);
	}

	private void SetIsHight(bool bFlag) {
		_goScores.SetActive(!bFlag);
		_goHight.SetActive(bFlag);
	}
}
