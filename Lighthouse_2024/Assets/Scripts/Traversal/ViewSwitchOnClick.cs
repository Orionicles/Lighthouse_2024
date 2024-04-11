using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewSwitchOnClick : MonoBehaviour
{
	public Camera cameraToEnable;
	public ViewManager viewManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ClickDetection();
    }

	void ClickDetection()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 mousePosition = Input.mousePosition;

			Camera currentCamera = Camera.allCameras[0];

			Ray ray = currentCamera.ScreenPointToRay(mousePosition);
			if (Physics.Raycast(ray, out RaycastHit hit))
			{
				if (GameObject.ReferenceEquals(hit.collider.gameObject, gameObject)) // if hit is me
				{
					DoCameraSwitch();
				}
			}
		}
	}

	void DoCameraSwitch()
	{
		viewManager.SwitchToCamera(cameraToEnable);
	}
}
