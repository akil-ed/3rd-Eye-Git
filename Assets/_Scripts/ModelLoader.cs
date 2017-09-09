using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using SFB;

[RequireComponent(typeof(Button))]
public class ModelLoader : MonoBehaviour, IPointerDownHandler {
	public string Title = "";
	public string FileName = "";
	public string Directory = "";
	public string Extension = "*.3d;*.3ds;*.3mf;*.ac;*.ac3d;*.acc;*.amf;*.ase;*.ask;*.assbin;*.b3d;*.blend;*.bvh;*.cob;*.csm;*.dae;*.dxf;*.enff;*.fbx;*.glb;*.gltf;*.hmp;*.ifc;*.ifczip;*.irr;*.irrmesh;*.lwo;*.lws;*.lxo;*.md2;*.md3;*.md5anim;*.md5camera;*.md5mesh;*.mdc;*.mdl;*.mesh;*.mesh.xml;*.mot;*.ms3d;*.ndo;*.nff;*.obj;*.off;*.ogex;*.pk3;*.ply;*.pmx;*.prj;*.q3o;*.q3s;*.raw;*.scn;*.sib;*.smd;*.stl;*.stp;*.ter;*.uc;*.vta;*.x;*.x3d;*.x3db;*.xgl;*.xml;*.zgl";
	public bool Multiselect = false;


	#if UNITY_WEBGL && !UNITY_EDITOR

	#else
	//
	// Standalone platforms & editor
	//
	public void OnPointerDown(PointerEventData eventData) { }

	void Start() {
		var button = GetComponent<Button>();
		button.onClick.AddListener(OnClick);
	}

	private void OnClick() {
		var paths = StandaloneFileBrowser.OpenFilePanel(Title, Directory, Extension, Multiselect);
		//print (paths [0]);
		if (paths.Length > 0) {
			OutputRoutine(paths [0]);
		}
	}
	#endif

	void OutputRoutine(string url) {

		AppManager.instance.LoadModel (url);

	}
}