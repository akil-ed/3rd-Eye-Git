using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FileImportSettings : MonoBehaviour {
	public InputField[] Inputs;
	public AppManager _AppManager;
	// Use this for initialization
	void Start () {
		_AppManager = AppManager.instance;
		GetValue ();
	}
	
	// Update is called once per frame
	void Update () {
		//UpdateValues ();
	}

	public void GetValue(){
		Inputs [0].text = _AppManager.CustomFileImportSettings.posX.ToString ();
		Inputs [1].text = _AppManager.CustomFileImportSettings.posY.ToString ();
		Inputs [2].text = _AppManager.CustomFileImportSettings.posZ.ToString ();

		Inputs [3].text = _AppManager.CustomFileImportSettings.rotX.ToString ();
		Inputs [4].text = _AppManager.CustomFileImportSettings.rotY.ToString ();
		Inputs [5].text = _AppManager.CustomFileImportSettings.rotZ.ToString ();

		Inputs [6].text = _AppManager.CustomFileImportSettings.scaleX.ToString ();
		Inputs [7].text = _AppManager.CustomFileImportSettings.scaleY.ToString ();
		Inputs [8].text = _AppManager.CustomFileImportSettings.scaleZ.ToString ();

		//UpdateValues ();
	}

	public void UpdateValues(){


		try{
		_AppManager.CustomFileImportSettings.posX = float.Parse (Inputs [0].text);
		_AppManager.CustomFileImportSettings.posY = float.Parse (Inputs [1].text);
		_AppManager.CustomFileImportSettings.posZ = float.Parse (Inputs [2].text);

		_AppManager.CustomFileImportSettings.rotX = float.Parse (Inputs [3].text);
		_AppManager.CustomFileImportSettings.rotY = float.Parse (Inputs [4].text);
		_AppManager.CustomFileImportSettings.rotZ = float.Parse (Inputs [5].text);

		_AppManager.CustomFileImportSettings.scaleX = float.Parse (Inputs [6].text);
		_AppManager.CustomFileImportSettings.scaleY = float.Parse (Inputs [7].text);
		_AppManager.CustomFileImportSettings.scaleZ = float.Parse (Inputs [8].text);
		}
		catch{

		}
		_AppManager.UpdateModel ();
	//	foreach (InputField IF in Inputs)
	//		if (IF.text == "")
	//			IF.text = "0";

	}
}
