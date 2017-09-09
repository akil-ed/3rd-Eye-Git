using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TriLib;
using System.IO;
using Newtonsoft.Json;

public class AppManager : MonoBehaviour {
	public static AppManager instance;
	public List<Project> Projects = new List<Project> ();
	public string SaveFilePath;
	public Project SelectedProject;
	public OrbitCamera OrbitCam;
	public Transform City, Preview;
	public CameraOrbitSettings CitySettings,PreviewSettings,CustomSettings;
	void Awake(){
		instance = this;
	}
	// Use this for initialization
	void Start () {
		SaveFilePath = Application.dataPath + "/usersaves.json";
		print (SaveFilePath);
	//	NewProject ();
	//	UpdateSaveFile ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void NewProject(){
		SelectedProject = new Project ();
	}

	public void ShowCity(){
		OrbitCam.target = City;
		AssignOrbitCamSettings (OrbitCam, CitySettings);
	}

	public void ShowPreview(){
		OrbitCam.target = Preview;
		AssignOrbitCamSettings (OrbitCam, PreviewSettings);
		//LoadModel ("D:/ElectronicDreaming/Projects/3rd Eye/Building2.fbx");
	}

	public void UpdateSaveFile(){
		
		Projects.Add (SelectedProject);
		StreamWriter writer = new StreamWriter (SaveFilePath, false);
		print(JsonConvert.SerializeObject (Projects));
		writer.WriteLine (JsonConvert.SerializeObject (Projects));
		writer.Close ();

	}

	public void LoadModel(string path){
		using (var assetLoader = new AssetLoader())
		{
			try
			{
				var assetLoaderOptions = AssetLoaderOptions.CreateInstance();
				//assetLoaderOptions.RotationAngles = new Vector3(90f, 180f, 0f);
				//assetLoaderOptions.AutoPlayAnimations = true;
				var loadedGameObject = assetLoader.LoadFromFile(path, assetLoaderOptions);
				loadedGameObject.transform.SetParent (Preview);
				loadedGameObject.transform.localPosition = new Vector3(0.0f,0.0f,0.01f);
				loadedGameObject.transform.localRotation = Quaternion.Euler (-90,180,0);
				loadedGameObject.transform.localScale = new Vector3(0.004f,0.004f,0.004f);
				SelectedProject.model.modelSettings.modelPath = path;
				//loadedGameObject.transform.position = new Vector3(128f, 0f, 0f);
			}
			catch (Exception e)
			{
				Debug.LogError(e.ToString());
			}
		}

	}


	public void AssignOrbitCamSettings(OrbitCamera OrbitCam,CameraOrbitSettings CamSettings){
		OrbitCam.autoRotateOn = CamSettings.isAutoRotateOn;
		OrbitCam.autoRotateReverse = CamSettings.isAutoRotateReverse;
		OrbitCam.minDistance = CamSettings.minDistance;
		OrbitCam.maxDistance = CamSettings.maxDistance;
		OrbitCam.distance = CamSettings.distance;
		//OrbitCam.target = CamSettings.target;
		OrbitCam.targetDistance = CamSettings.targetDistance;
		OrbitCam.xMinLimit = CamSettings.minXangle;
		OrbitCam.xMaxLimit = CamSettings.maxXangle;
		OrbitCam.yMinLimit = CamSettings.minYangle;
		OrbitCam.yMaxLimit = CamSettings.maxYangle;
		OrbitCam.xSpeed = CamSettings.speedX;
		OrbitCam.ySpeed = CamSettings.speedY;
		OrbitCam.zoomSpeed = CamSettings.speedZoom;
		OrbitCam.transform.rotation = Quaternion.Euler (CamSettings.Xangle, CamSettings.Yangle, 0);
	}


}

[System.Serializable]
public class CameraOrbitSettings{
	public bool isAutoRotateOn = false;
	public bool isAutoRotateReverse = false;
	public float minDistance = 4;
	public float maxDistance = 25;
	public float distance = 21;
	//public Transform target = null;
	public string targetPath = "";
	public float targetDistance = 21;
	public float minXangle = 60;
	public float maxXangle = -60;
	public float Xangle = 28;
	public float minYangle = -20;
	public float maxYangle = 60;
	public float Yangle = 60;
	public float speedX = 1;
	public float speedY = 1;
	public float speedZoom = 2;

}

[System.Serializable]
public class ModelSettings{
	public string modelPath = "";
	public float posX,posY,posZ;
	public float rotX,rotY,rotZ;
	public float scaleX,scaleY,scaleZ;
}

[System.Serializable]
public class Project{
	public string Name = "New Project";
	public int index = 0;
	public Model3D model = new Model3D();
	public List<Image360> Rooms = new List<Image360>();

}

[System.Serializable]
public class Model3D{
	public ModelSettings modelSettings = new ModelSettings();
	public CameraOrbitSettings camOrbitSettings = new CameraOrbitSettings();
}

[System.Serializable]
public class Image360{
	public string Top = "";
	public string Bottom = "";
	public string Left = "";
	public string Right = "";
	public string Forward = "";
	public string Back = "";
}

