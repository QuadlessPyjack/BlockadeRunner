using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomSmooth : MonoBehaviour {

	public  float zoomStep = 1.0f;
	private float zoomAmount = 0.0f; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		zoomAmount = Camera.main.orthographicSize;

		if (Input.GetAxis("Mouse ScrollWheel") > 0)
		{
			zoomAmount += zoomStep * Time.deltaTime;
		}

		if (Input.GetAxis("Mouse ScrollWheel") < 0)
		{
			zoomAmount -= zoomStep * Time.deltaTime;
		}

		Camera.main.orthographicSize = Vector2.Lerp(new Vector2(Camera.main.orthographicSize, 0.0f), new Vector2(zoomAmount, 0.0f), 10).x;
	}
}
