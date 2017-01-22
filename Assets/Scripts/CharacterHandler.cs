using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHandler : MonoBehaviour {
    public float stepSize = 0.1f;
    public float sensitivityLX = 1.0f;
    public float sensitivityLY = 1.0f;

    // Use this for initialization
    void Start () {
	}

    private bool validateMovement(Vector3 input)
    {
        if (input.x > -0.1f && input.x < 0.1f)
        {
            return false;
        }

        if (input.z > -0.1f && input.z < 0.1f)
        {
            return false;
        }

        return true;
    }
	
    private void handleMovement()
    {
        Vector3 NextDir = new Vector3(Input.GetAxis("LeftStickX"), 0, Input.GetAxis("LeftStickY"));
        if (validateMovement(NextDir))
        {
            transform.rotation = Quaternion.LookRotation(NextDir * -1.0f);
            return;
        }

        NextDir = new Vector3(Input.GetAxis("RightStickX"), 0, Input.GetAxis("RightStickY"));
        if (validateMovement(NextDir))
        {
            transform.rotation = Quaternion.LookRotation(NextDir * -1.0f);
            gameObject.transform.Translate(Vector3.forward * stepSize * 0.01f);
        }
    }

	// Update is called once per frame
	void Update () {
        handleMovement();
    }
}
