using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class camCHange : MonoBehaviour {
	public GameObject cam1;
	public GameObject cam2;

	public void camera1() {
		cam1.SetActive(true);
		cam2.SetActive (false);
	}

	public void camera2() {
		cam1.SetActive(false);
		cam2.SetActive (true);
	}
}