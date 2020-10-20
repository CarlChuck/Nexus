using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
        public Vector3 rotationOffset;
	public Camera mainCamera;

	public void Start()
	{
		mainCamera = Camera.main;
	}

	public void Update()
	{

		transform.LookAt(mainCamera.transform);
		transform.Rotate(rotationOffset);
	}

}