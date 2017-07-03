using UnityEngine;
using System.Collections;

public class BaseAspect : MonoBehaviour {
	public GameObject _goNext;
	public GameObject _goScore;
	public GameObject _goBest;
	private float standard_width = 640f;        //初始宽度  
	private float standard_height = 960f;       //初始高度  
	private float device_width = 0f;                //当前设备宽度  
	private float device_height = 0f;               //当前设备高度  
	private float adjustor = 0f;         //屏幕矫正比例  
	private	ADBannerView m_banner;

	void Awake() {
		//获取设备宽高  
		device_width = Screen.width;  
		device_height = Screen.height;  
		//计算宽高比例  
		float standard_aspect = standard_width / standard_height;  
		float device_aspect = device_width / device_height;
		//计算矫正比例  
		if (device_aspect < standard_aspect)  
		{  
			adjustor = standard_aspect / device_aspect;
			SetButtonHeight(3);
		}
		if (adjustor < 2 && adjustor > 0)
		{  
			camera.orthographicSize = adjustor;  
		}
		m_banner = new ADBannerView (ADBannerView.Type.Banner, ADBannerView.Layout.Bottom);
		ADBannerView.onBannerWasClicked += OnBannerClicked;
		ADBannerView.onBannerWasLoaded += OnBannerLoaded;
	}

	void OnBannerClicked()
	{

	}
	
	void OnBannerLoaded()
	{
		m_banner.visible = true;
	}

	private void SetButtonHeight(int uNum) {
		_goNext.transform.localPosition += Vector3.up * 10 * uNum;
		_goScore.transform.localPosition += Vector3.up * 10 * uNum;
		_goBest.transform.localPosition += Vector3.up * 10 * uNum;
	}
}
