using UnityEngine;
using System.Collections;

public class JGuide : MonoBehaviour {
	public UICenterOnChild _UICenter;
	public GameObject[] _arrGoChild;
	public UISprite[] _arrPageSprite;
	private bool m_bFirst = true;

	void Start () {
		ResetAllPage ();
		_UICenter.onCenter = OnCenterCallback;
	}
	
	private void OnCenterCallback(GameObject centeredObject) {
		if (m_bFirst) {
			m_bFirst = false;
			int uFinishGuid = PlayerPrefs.GetInt ("FinishGuid");
			if (uFinishGuid == 1) {
				_UICenter.CenterOn(_arrGoChild[4].transform);
				return;
			}
		}
		ResetAllPage ();
		for (int i = 0; i < _arrGoChild.Length; i++) {
			if (centeredObject == _arrGoChild[i]) {
				_arrPageSprite[i].spriteName = "curPage";
				break;
			}
		}
	}

	private void ResetAllPage() {
		for (int i = 0; i < _arrPageSprite.Length; i++) {
			_arrPageSprite[i].spriteName = "otherPage";
		}
	}
}
