using UnityEngine;
using System.Collections;

public class JGrid : MonoBehaviour {
	public UILabel _Lable;
	public UISprite	_Sprite;
	public GameObject _GoPlus;
	private int m_uIndex;
	private int m_uValue;
	private const int GOOD_NUM = 256;

	void OnClick() {
		if (f_uValue != 0) {
			return;
		}
		JMain.instance.PlayAudio (0);
		f_uValue = JMain.instance.f_uNextNum;
		JMain.instance.CheckAroundGrid(m_uIndex);
	}

	public int f_uIndex {
		set {
			m_uIndex = value;
		}
	}

	public int f_uValue {
		get {
			return m_uValue;
		}
		set {
			_GoPlus.SetActive(false);
			m_uValue = value;
			if (value == 0) {
				_Lable.text = "";
				_Sprite.spriteName = "xiaofangdi";
			} else {
				_Lable.text = value.ToString();
				if (value >= GOOD_NUM) {
					_Sprite.spriteName = "xiaofangte";
					_Lable.color = new Color(1f, 48 / 255f, 0f);
				} else {
					_Sprite.spriteName = "xiaofangpu";
					_Lable.color = new Color(1f, 210 / 255f, 0f);
				}
			}
		}
	}

	public void ShowPlus() {
		_GoPlus.SetActive(true);
	}
}
