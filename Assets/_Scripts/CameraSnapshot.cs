using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class CameraSnapshot : MonoBehaviour
{
    [SerializeField]
    RenderTexture CameraTexture3D;  
    [SerializeField]
    Camera camera3D; 

	public void OnSave(){
		StartCoroutine(SaveCameraView());
	}

    public IEnumerator SaveCameraView()
    {
        yield return new WaitForEndOfFrame();

        // get the camera's render texture
        RenderTexture rendText = RenderTexture.active;
		RenderTexture.active = camera3D.targetTexture;

        // render the texture
		camera3D.Render();

        // create a new Texture2D with the camera's texture, using its height and width
		Texture2D cameraImage = new Texture2D(camera3D.targetTexture.width, camera3D.targetTexture.height, TextureFormat.RGB24, false);
		cameraImage.ReadPixels(new Rect(0, 0, camera3D.targetTexture.width, camera3D.targetTexture.height), 0, 0);
        cameraImage.Apply();
        RenderTexture.active = rendText;

        // store the texture into a .PNG file
        byte[] bytes = cameraImage.EncodeToPNG();


        // save the encoded image to a file
        System.IO.File.WriteAllBytes(Application.persistentDataPath + "/camera_image.png", bytes);

    }
}
