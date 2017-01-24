using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour {
    public GameObject owner;
	//Drag in the Bullet Emitter from the Component Inspector.
	public GameObject Bullet_Emitter;

	//Drag in the Bullet Prefab from the Component Inspector.
	public GameObject Bullet;

	//Enter the Speed of the Bullet from the Component Inspector.
	public float Bullet_Forward_Force;

    public float fireRate = 1.0f;
    public float reloadTime = 5.0f;
    public int clipCount = 100;

    private float cooldown = 0.0f;
    private int usedRounds = 0;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Trigger") < 0.2f && Input.GetAxis("Trigger") > -0.2f)
        {
            
        }else
            {
            if (cooldown < fireRate && usedRounds < clipCount)
            {
                cooldown += Time.deltaTime;
            }
            else
            if (usedRounds >= clipCount)
            {
                if(cooldown > reloadTime)
                {
                    cooldown = 0.0f;
                    usedRounds = 0;
                }

                cooldown += Time.deltaTime;
            } else
            { 
                //The Bullet instantiation happens here.
                GameObject Temporary_Bullet_Handler;
                Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
                Temporary_Bullet_Handler.GetComponent<Ammo>().owner = owner;
                cooldown = 0.0f;
                ++usedRounds;
                //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
                //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
                Temporary_Bullet_Handler.transform.Rotate(new Vector3(0.0f, -90.0f, 0.0f));

                //Retrieve the Rigidbody component from the instantiated Bullet and control it.
                Rigidbody Temporary_RigidBody;
                Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

                //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
                Temporary_RigidBody.AddForce(-transform.right * Bullet_Forward_Force);

                //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
                Destroy(Temporary_Bullet_Handler, 10.0f);
            }
		}
	}
}
