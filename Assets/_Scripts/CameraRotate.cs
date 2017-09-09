using UnityEngine;
using System.Collections;

public class CameraRotate : MonoBehaviour {
//	[SerializeField]Transform[] Rooms;
	public int  speed=20;
	public float smooth;
	void Start(){


	//	Rooms [0].gameObject.layer=8;
	
	//	loadingTxt.gameObject.SetActive (true);
	//	Invoke ("LoadAll", 0.5f);
	
	}

	void LoadAll(){
        //for (int i=0; i<8; i++)
        //    transform.parent.GetComponent<XmlParser> ().SaveImage (i);

	}


	void Update ()
	{
		if(Input.GetMouseButton(0)){
			if (MouseHelper.mouseDelta.x != 0 || MouseHelper.mouseDelta.y != 0) {
				transform.Rotate (new Vector3 (-MouseHelper.mouseDelta.y, MouseHelper.mouseDelta.x, 0) * -speed * Time.deltaTime);

				transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler (transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0),smooth*Time.deltaTime);
			}
		}
		transform.rotation=Quaternion.Euler(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y,0);
	}
	
	
}
