using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OrbitCameraSettings : MonoBehaviour {
	public Toggle[] _Toggles;
	public InputField[] Inputs;
	public AppManager _AppManager;
	void Start () {
		_AppManager = AppManager.instance;
		GetValue ();
	}

	// Update is called once per frame
	void Update () {
		//UpdateValues ();
	}

	public void GetValue(){
		_Toggles [0].isOn = _AppManager.CustomOrbitSettings.isAutoRotateOn;
		_Toggles [0].isOn = _AppManager.CustomOrbitSettings.isAutoRotateReverse;

		_AppManager.CustomOrbitSettings.distance = _AppManager.CustomOrbitSettings.targetDistance;

		Inputs [0].text = _AppManager.CustomOrbitSettings.minDistance.ToString ();
		Inputs [1].text = _AppManager.CustomOrbitSettings.maxDistance.ToString ();
		Inputs [2].text = _AppManager.CustomOrbitSettings.distance.ToString ();
		Inputs [3].text = _AppManager.CustomOrbitSettings.targetDistance.ToString ();

		Inputs [4].text = _AppManager.CustomOrbitSettings.Xangle.ToString ();
		Inputs [5].text = _AppManager.CustomOrbitSettings.Yangle.ToString ();
		Inputs [6].text = _AppManager.CustomOrbitSettings.minXangle.ToString ();
		Inputs [7].text = _AppManager.CustomOrbitSettings.maxXangle.ToString ();
		Inputs [8].text = _AppManager.CustomOrbitSettings.minYangle.ToString ();
		Inputs [9].text = _AppManager.CustomOrbitSettings.maxYangle.ToString ();

		Inputs [10].text = _AppManager.CustomOrbitSettings.speedX.ToString ();
		Inputs [11].text = _AppManager.CustomOrbitSettings.speedY.ToString ();
		Inputs [12].text = _AppManager.CustomOrbitSettings.speedZoom.ToString ();

		//UpdateValues ();
	}

	public void UpdateValues(){
		_AppManager.CustomOrbitSettings.isAutoRotateOn = _Toggles [0].isOn;
		_AppManager.CustomOrbitSettings.isAutoRotateReverse = _Toggles [1].isOn;

		try{
			_AppManager.CustomOrbitSettings.minDistance = float.Parse (Inputs [0].text);
			_AppManager.CustomOrbitSettings.maxDistance = float.Parse (Inputs [1].text);
			_AppManager.CustomOrbitSettings.distance = float.Parse (Inputs [2].text);
			_AppManager.CustomOrbitSettings.targetDistance = float.Parse (Inputs [3].text);

			_AppManager.CustomOrbitSettings.Xangle = float.Parse (Inputs [4].text);
			_AppManager.CustomOrbitSettings.Yangle = float.Parse (Inputs [5].text);
			_AppManager.CustomOrbitSettings.minXangle = float.Parse (Inputs [6].text);
			_AppManager.CustomOrbitSettings.maxXangle = float.Parse (Inputs [7].text);
			_AppManager.CustomOrbitSettings.minYangle = float.Parse (Inputs [8].text);
			_AppManager.CustomOrbitSettings.maxYangle = float.Parse (Inputs [9].text);

			_AppManager.CustomOrbitSettings.speedX = float.Parse (Inputs [10].text);
			_AppManager.CustomOrbitSettings.speedY = float.Parse (Inputs [11].text);
			_AppManager.CustomOrbitSettings.speedZoom = float.Parse (Inputs [12].text);
		}
		catch{

		}
		//_AppManager.UpdateModel ();
		_AppManager.UpdateOrbitSettings ();
		//	foreach (InputField IF in Inputs)
		//		if (IF.text == "")
		//			IF.text = "0";

	}
}
