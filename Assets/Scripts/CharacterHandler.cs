using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHandler : MonoBehaviour {
    public float stepSize = 0.1f;
    public float sensitivityX = 1.0f;
    public float sensitivityY = 1.0f;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 reference = gameObject.transform.position;
        Vector3 rotationReference = gameObject.transform.eulerAngles;
        bool hasMoved = false;
        float deltaX = 0.0f;
        float deltaY = 0.0f;

        deltaX = Input.GetAxis("Horizontal") * sensitivityX;
        deltaY = Input.GetAxis("Vertical") * sensitivityY;

        Debug.Log("HAxis: " + deltaX);
        Debug.Log("VAxis: " + deltaY);
        Vector3 targetRotation = transform.rotation.eulerAngles;
        transform.Translate(Input.GetAxis("LeftStickX") * stepSize * Time.deltaTime, 0, Input.GetAxis("LeftStickY") * stepSize * Time.deltaTime);
        transform.Rotate(Input.GetAxis("RightStickY") * Vector3.up * Time.deltaTime * stepSize);
        //if (deltaY != 0)
        //{
        //    targetRotation = new Vector3(transform.rotation.eulerAngles.x, -deltaY, transform.rotation.eulerAngles.z);
        //    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRotation), .1f);
        //}

        //if (Input.GetButton("MOVE_DOWN"))
        //{
        //    //gameObject.transform.LookAt(new Vector3(reference.x, reference.y, -1000));
        //    gameObject.transform.LookAt(new Vector3(-1000, 0.0f, 0.0f));
        //    hasMoved = true;
        //}

        //if (Input.GetButton("MOVE_UP"))
        //{
        //    gameObject.transform.LookAt(new Vector3(1000, 0.0f, 0.0f));
        //    hasMoved = true;
        //    //gameObject.transform.Translate(Vector3.forward);
        //}

        //if (Input.GetButton("MOVE_LEFT"))
        //{
        //    gameObject.transform.LookAt(new Vector3(0.0f, 0.0f, 1000));
        //    hasMoved = true;
        //    //gameObject.transform.LookAt(new Vector3(-1000, reference.y, reference.z));
        //}

        //if (Input.GetButton("MOVE_RIGHT"))
        //{
        //    gameObject.transform.LookAt(new Vector3(0.0f, 0.0f, -1000));
        //    hasMoved = true;
        //    //gameObject.transform.LookAt(new Vector3(1000, reference.y, reference.z));
        //}

        if (hasMoved)
        {
            gameObject.transform.Translate(Vector3.forward * stepSize);
            //cameraGO.transform.rotation = cameraRotation;
            hasMoved = false;
        }
    }
}
