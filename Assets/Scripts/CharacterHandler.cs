using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHandler : MonoBehaviour {
    public float stepSize = 0.1f;
    public GameObject attachedCamera;

    private enum CharState
    {
        IDLE = 0,
        RUNNING,
        SHOOTING
    };

    private CharState currentState = CharState.IDLE;

    public Animator animator;

    // Use this for initialization
    void Start () {
        transform.Find("REVOLVER").GetComponent<Generate>().owner = gameObject;

        //animator = GetComponent<Animator>();
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
	
    private void handleAnimationState()
    {
        switch (currentState)
        {
            case CharState.IDLE:
                animator.SetBool("isIdle", true);
                break;
            case CharState.RUNNING:
                animator.SetBool("isRunning", true);
                break;
            case CharState.SHOOTING:
                animator.SetBool("isShooting", true);
                break;
            default:
                break;
        }
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
            Vector3 dir = gameObject.transform.position - attachedCamera.transform.position;
            dir.Normalize();
            Vector3 sanitized = new Vector3(dir.x, 0.0f, dir.z);
            attachedCamera.transform.Translate(sanitized * stepSize * 0.01f);
            
            currentState = CharState.RUNNING;
        }
    }

	// Update is called once per frame
	void Update () {
        handleMovement();

        if (Input.GetAxis("Trigger") < 0.2f && Input.GetAxis("Trigger") > -0.2f)
        {
            currentState = CharState.SHOOTING;
        }

        currentState = CharState.IDLE;
    }
}
