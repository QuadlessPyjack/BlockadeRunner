using UnityEngine;

public class ZoomSmooth : MonoBehaviour {

	public  float zoomStep = 0.2f;
    public float zoomCapMin = 1.0f;
    public float zoomCapMax = 10.0f;
	private float zoomAmount = 0.0f; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		zoomAmount = Camera.main.orthographicSize;

		if (Input.GetAxis("Mouse ScrollWheel") > 0 || Input.GetButton("ZoomIn"))
		{
			zoomAmount += zoomStep * (1 / Time.deltaTime);
		}

		if (Input.GetAxis("Mouse ScrollWheel") < 0 || Input.GetButton("ZoomOut"))
		{
			zoomAmount -= zoomStep * (1 / Time.deltaTime);
		}

		float ortographicSize = Vector2.Lerp(new Vector2(Camera.main.orthographicSize, 0.0f), new Vector2(zoomAmount, 0.0f), zoomStep).x;
        ortographicSize = Mathf.Clamp(ortographicSize, zoomCapMin, zoomCapMax);
        Camera.main.orthographicSize = ortographicSize;

    }
}
