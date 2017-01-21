using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHandler : MonoBehaviour {
    private GameObject cameraGO;
    public float stepSize;
    // Use this for initialization
    void Start () {
        cameraGO = gameObject.transform.Find("Camera").gameObject;
        if(!cameraGO.GetComponent<Camera>())
        {
            Debug.LogError(gameObject.name + " has no Camera!");
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("MOVE_DOWN"))
        {
            gameObject.transform.Translate(new Vector3(0.0f, 0.0f, -stepSize));
        }

        if (Input.GetButton("MOVE_UP"))
        {
            gameObject.transform.Translate(new Vector3(0.0f, 0.0f, stepSize));
        }

        if (Input.GetButton("MOVE_LEFT"))
        {
            gameObject.transform.Translate(new Vector3(-stepSize, 0.0f, 0.0f));
        }

        if (Input.GetButton("MOVE_RIGHT"))
        {
            gameObject.transform.Translate(new Vector3(stepSize, 0.0f, 0.0f));
        }
    }
}
