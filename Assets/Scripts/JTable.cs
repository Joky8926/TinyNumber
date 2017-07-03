using UnityEngine;
using System.Collections;

public class JTable : MonoBehaviour {
	public GameObject _go;
	private JGrid[,] m_arrGrid = new JGrid[4, 4];

	void Awake() {
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 4; j++) {
				GameObject go = Instantiate(_go) as GameObject;
				go.transform.parent = transform;
				go.transform.localScale = Vector3.one;
				int uIndex = i * 4 + j;
				go.name = "Grid_" + uIndex;
				JGrid jGrid = go.GetComponent<JGrid>();
				jGrid.f_uIndex = uIndex;
				m_arrGrid[i, j] = jGrid;
			}
		}
	}

	public void Init(int num) {
		ResetAllGrid();
		int uIndex = Random.Range (0, 16);
		int i = uIndex / 4;
		int j = uIndex % 4;
		m_arrGrid[i, j].f_uValue = num;
	}

	private void ResetAllGrid() {
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 4; j++) {
				m_arrGrid[i, j].f_uValue = 0;
			}
		}
	}

	public bool CheckAroundGrid(int uIndex) {
		int uCount = 0;
		int i = uIndex / 4;
		int j = uIndex % 4;
		JGrid jGrid = m_arrGrid[i, j];
		int num = jGrid.f_uValue;
		if (Composite (i - 1, j, num)) {
			uCount++;
		}
		if (Composite (i + 1, j, num)) {
			uCount++;
		}
		if (Composite (i, j - 1, num)) {
			uCount++;
		}
		if (Composite (i, j + 1, num)) {
			uCount++;;
		}
		if (uCount > 0) {
			JMain.instance.f_uScore += jGrid.f_uValue;
			JMain.instance.AddNewNext(jGrid.f_uValue);
			jGrid.f_uValue *= 2;
			if (uCount > 1) {
				jGrid.ShowPlus();
			}
			CheckAroundGrid(uIndex);
			return true;
		}
		return false;
	}

	public bool CheckGameOver() {
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 4; j++) {
				if (m_arrGrid[i, j].f_uValue == 0) {
					return false;
				}
			}
		}
		return true;
	}

	private bool Composite(int i, int j, int num) {
		if (i < 0 || i > 3 || j < 0 || j > 3) {
			return false;
		}
		JGrid jGrid = m_arrGrid[i, j];
		if (jGrid.f_uValue == num) {
			JMain.instance.f_uScore += jGrid.f_uValue;
			jGrid.f_uValue = 0;
			return true;
		}
		return false;
	}
}
