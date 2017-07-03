using UnityEngine;
using System.Collections.Generic;

public class JMain : MonoBehaviour {
	public static JMain instance;
	public UILabel _NextLabel;
	public UILabel _ScoreLabel;
	public UILabel _HighestLabel;
	public JTable _Table;
	public JNextAni _NextAni;
	public AudioClip[] _arrAudioClip;
	private int m_uNextNum;
	private int m_uScore;
	private int m_uHighest;
	private List<int> m_lstNextNum = new List<int> ();

	void Start() {
		instance = this;
		NewGame();
	}

	public void NewGame() {
		m_lstNextNum.Clear ();
		m_lstNextNum.Add (1);
		m_lstNextNum.Add (2);
		ResetNext();
		f_uScore = 0;
		f_uHighest = PlayerPrefs.GetInt("HightScore");
		_Table.Init(m_uNextNum);
	}

	public void CheckAroundGrid(int uIndex) {
		bool bFlag = _Table.CheckAroundGrid(uIndex);
		if (!bFlag) {
			bool bOver = _Table.CheckGameOver ();
			if (bOver) {
				JGameOver.instance.OnGameOver (f_uScore);
			}
		} else {
			PlayAudio(1);
		}
	}

	private void ResetNext() {
		int uIndex = Random.Range (0, m_lstNextNum.Count);
		m_uNextNum = m_lstNextNum [uIndex];
		_NextLabel.text = m_uNextNum.ToString();
		_NextAni.ShowAni ();
	}

	public int f_uNextNum {
		get {
			int num = m_uNextNum;
			ResetNext();
			return num;
		}
	}

	public int f_uScore {
		get {
			return m_uScore;
		}
		set {
			m_uScore = value;
			_ScoreLabel.text = m_uScore.ToString();
			if (m_uHighest < f_uScore) {
				f_uHighest = f_uScore;
			}
		}
	}

	private int f_uHighest {
		set {
			m_uHighest = value;
			_HighestLabel.text = m_uHighest.ToString();
		}
	}

	public void PlayAudio(int uIndex) {
		audio.Stop ();
		audio.PlayOneShot (_arrAudioClip[uIndex]);
	}

	public void AddNewNext(int uNum) {
		if (!m_lstNextNum.Contains (uNum)) {
			m_lstNextNum.Add(uNum);
		}
	}
}
