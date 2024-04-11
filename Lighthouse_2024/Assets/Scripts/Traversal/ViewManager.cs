using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
	public Camera startCamera;

	private Camera currentCamera;

	private Dictionary<string, string> traversalDict = new Dictionary<string, string>
	{
		{"Camera_1left", "Camera_4"},
		{"Camera_1right", "Camera_2"},
		{"Camera_2left", "Camera_1"},
		{"Camera_2right", "Camera_3"},
		{"Camera_3left", "Camera_2"},
		{"Camera_3right", "Camera_4"},
		{"Camera_4left", "Camera_3"},
		{"Camera_4right", "Camera_1"}
	};

	void Start()
	{
		foreach (Camera c in Camera.allCameras)
		{
			c.enabled = false;
		}
		currentCamera = startCamera;
		SwitchToCamera(startCamera);
		Debug.Log(startCamera.enabled);
	}

	public void SwitchToCamera(Camera newCam)
	{
		currentCamera.enabled = false;
		currentCamera.GetComponent<AudioListener>().enabled = false;
		currentCamera = newCam;
		currentCamera.enabled = true;
		currentCamera.GetComponent<AudioListener>().enabled = true;
	}

	public void PerformButtonClick(string direction)
	{
		// lookup is camera name plus direction, e.g. MainLighthouse3left
		string lookup = currentCamera.name + direction;
		SwitchToCamera(GameObject.Find(traversalDict[lookup]).GetComponent<Camera>());
	}
}
