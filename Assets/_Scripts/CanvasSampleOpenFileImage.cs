using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using SFB;

[RequireComponent(typeof(Button))]
public class CanvasSampleOpenFileImage : MonoBehaviour, IPointerDownHandler {
    public string Title = "";
    public string FileName = "";
    public string Directory = "";
	public string Extension = "*.png;*.jpg;*.jpeg";
    public bool Multiselect = false;

    public RawImage output;
	public SpriteRenderer output360;
	public Renderer Target;

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
        if (paths.Length > 0) {
            StartCoroutine(OutputRoutine(new System.Uri(paths[0]).AbsoluteUri));
        }
    }
#endif

    private IEnumerator OutputRoutine(string url) {
        //Debug.Log("URL: " + url);
		WWW www = new WWW(url);
		yield return www;

		//Renderer renderer = GetComponent<Renderer>();
		Target.material.mainTexture = www.texture;
        var loader = new WWW(url);
        yield return loader;
        output.texture = loader.texture;
		//Target.material.mainTexture = loader.texture;
		float pixelScale = 100 + ((loader.texture.width - 2000)/20);
		output360.sprite = Sprite.Create (loader.texture, new Rect (0, 0, loader.texture.width, loader.texture.height), new Vector2(0.5f,0.5f),pixelScale,0,SpriteMeshType.FullRect,new Vector4(10,10,10,10));
		Sprite test;
		//test.packingMode = WrapMode.Clamp;
    }


}